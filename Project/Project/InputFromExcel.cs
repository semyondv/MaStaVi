using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
namespace InputModule
{
    public class Input
    {
        class RetPair
        {
            public Dictionary<string, Dictionary<string, double>> Det;
            public Dictionary<string, Dictionary<string, double>> Undet;
            public RetPair()
            {
                this.Det = new Dictionary<string, Dictionary<string, double>> { };
                this.Undet = new Dictionary<string, Dictionary<string, double>> { };

            }
        }

        public static string nam = "";

        public static List<SorterModule.Sorter.Border> Divs = new List<SorterModule.Sorter.Border> { };

        class KWNotFound : Exception
        {
            public KWNotFound()
                : base("KeyWord Not Found. Check if you have it somewhere!")
            { }
        }

        class EmptyTable : Exception
        {
            public EmptyTable()
                : base("Check if the table is misplaced or you forgot to write it! ")
            { }
        }

        class EmptyCell : Exception
        {
            public EmptyCell(int i, int i1, Excel.Worksheet ws)
                : base("Check the redded cell!")
            {
                ws.Cells[i, i1].Interior.ColorIndex = 3;
            }
        }
        

        //!!!!Формат Дата <Регион, Значение> !!!!
        private static Dictionary<string, Dictionary<string, double>> ReadFromExcelFile(string FilePath)//Already works!
        {

            Excel.Application excelApp = new Excel.Application();
            bool flag = false;
            Excel.Workbook excelWB = null;
            Dictionary<string, Dictionary<string, double>> result = new Dictionary<string, Dictionary<string, double>> { };
            try
            {

                excelWB = excelApp.Workbooks.Open(FilePath);
            Excel.Worksheet ws = excelWB.Sheets[1];
            var excelcells = ws.Cells.Find("!Table!", Missing.Value, Missing.Value, Excel.XlLookAt.xlPart, Missing.Value,
   Excel.XlSearchDirection.xlNext,
   Missing.Value, Missing.Value, Missing.Value);
            if (excelcells == null)
            {
                throw new KWNotFound();
            }
            if (!Project.DialogSettings.AutoGen)
            {
                   Divs = InputDividers(ws, Project.Font1.x);
            }
            int colst = excelcells.Column + 1;
            int rowst = excelcells.Row + 2;
            nam = ws.Cells[rowst-1, colst-1].Text();
            int colend = colst;
            int rowend = rowst;
            // Excel.Range r = ws.Range[ws.Cells[rowst,colst],ws.Cells[rowst+1000,colst + 1000]];
            while (true)
            {
                if (ws.Cells[rowst, colend].Text != "")
                {
                    colend += 1;
                }
                else
                {
                    break;
                }
            }

            while (true)
            {
                if (ws.Cells[rowend, colst].Text != "")
                {
                    rowend += 1;
                }
                else
                {
                    break;
                }
            }
            if ((colend == colst) || (rowend == rowst))
            {
                throw new EmptyTable();
            }
            /*Excel.Range r = ws.Range[ws.Cells[rowst,colst],ws.Cells[rowend,colend]];
            object[,] arr = r.Value2;*/

            for (int i = colst; i < colend; i++)
            {
                string currstr = "";
                if ((ws.Cells[rowst - 1, i].Text != ""))
                {
                    currstr = ws.Cells[rowst - 1, i].Value2.ToString();
                }
                else
                {
                    throw new EmptyCell(rowst - 1, i, ws);
                }
                result.Add(currstr, new Dictionary<string, double> { });
                for (int i1 = rowst; i1 < rowend; i1++)
                {
                    string currstrins = "";
                    if ((ws.Cells[i1, colst - 1].Text != ""))
                    {
                        currstrins = ws.Cells[i1, colst - 1].Value2.ToString();
                    }
                    else
                    {
                        throw new EmptyCell(i1, colst - 1, ws);
                    }

                    if (!(result[currstr].ContainsKey(currstrins)))
                    {
                        if ((ws.Cells[i1, i].Text != ""))
                        {
                            result[currstr].Add(currstrins, ws.Cells[i1, i].Value2);
                        }
                        else
                        {
                            throw new EmptyCell(i1, i, ws);
                        }

                    }
                }

            }
            }



            catch (System.Runtime.InteropServices.COMException e)
            {
                flag = true;
            }
            catch (KWNotFound e)
            {
                flag = true;
                excelWB.Close(false);
            }
            catch (EmptyTable e)
            {
                flag = true;
                excelWB.Close(false);
            }
            catch (EmptyCell e)
            {
                flag = true;
                excelWB.Close(true);
            }

            finally
            {
                excelApp.Quit();
                GC.Collect();

            }
            if (flag) System.Environment.Exit(0);
            return result;
        }
        // Модуль автокоррекции опечаток надо переделать. Пока просто пропускаем неопределенные значения в сортировщике.
        private static RetPair FilterByDetection(Dictionary<string, Dictionary<string, double>> unsorted, InputModule.InputText.KeyValues InsertedValues)
        {
            RetPair result = new RetPair();
            foreach (var item in unsorted)
            {
                if (InsertedValues.Dict.ContainsKey(item.Key))
                {
                    result.Det.Add(item.Key, item.Value);
                }
                else
                {
                    result.Undet.Add(item.Key, item.Value);
                }
            }
            return result;
        }

        public static List<SorterModule.Sorter.Border> InputDividers(Excel.Worksheet ws,int n)
        {
            List<SorterModule.Sorter.Border> Divs = new List<SorterModule.Sorter.Border> { };
            var excelcells = ws.Cells.Find("!Dividers!", Missing.Value, Missing.Value, Excel.XlLookAt.xlPart, Missing.Value,
   Excel.XlSearchDirection.xlNext,
   Missing.Value, Missing.Value, Missing.Value);
            if (excelcells == null)
            {
                throw new KWNotFound();
            }
            int colst = excelcells.Column;
            int rowst = excelcells.Row + 1;
            int colend = colst;
            int rowend = rowst;
         
            // Excel.Range r = ws.Range[ws.Cells[rowst,colst],ws.Cells[rowst+1000,colst + 1000]];
            for (int i = 0; i < n; i++)
            {
                Divs.Add(new SorterModule.Sorter.Border(ws.Cells[rowst + i, colst ].Value2, ws.Cells[rowst + i, colst + 1].Value2));
            }
            return Divs;
         
        }
       

        public static Dictionary<string, Dictionary<string, double>> RunInputModule(string FilePath, InputModule.InputText.KeyValues InsertedValues)
        {
            Dictionary<string, Dictionary<string, double>> Unsorted = ReadFromExcelFile(FilePath);
            /*RetPair afterFirstSort = FilterByDetection(Unsorted, InsertedValues);*/
            return Unsorted;


        }

    }
}


/*for (int i = rowst; i < rowend; i++)
{
    string currstr = "";
    if ((ws.Cells[i, colst - 1].Text != ""))
    {
        currstr = ws.Cells[i, colst - 1].Value2.ToString();
    }
    else
    {
        throw new EmptyCell(i, colst - 1, ws);
    }
    result.Add(currstr, new Dictionary<string, double> { });
    for (int i1 = colst; i1 < colend; i1++)
    {
        string currstrins = "";
        if ((ws.Cells[rowst - 1, i1].Text != ""))
        {
            currstrins = ws.Cells[rowst - 1, i1].Value2.ToString();
        }
        else
        {
            throw new EmptyCell(rowst - 1, i1, ws);
        }

        if (!(result[currstr].ContainsKey(currstrins)))
        {
            if ((ws.Cells[i, i1].Text != ""))
            {
                result[currstr].Add(currstrins, ws.Cells[i, i1].Value2);
            }
            else
            {
                throw new EmptyCell(i, i1, ws);
            }

        }
    }

}*/
