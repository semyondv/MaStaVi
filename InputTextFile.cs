using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
namespace InputModule
{
    public struct Point
    {
        public int X;
        public int Y;
    }
    public class InputText
    {
        
        public class KeyValues
        {

            public Dictionary<string, Point> Dict;
            public KeyValues()
            {
                Dict = new Dictionary<string, Point> { };
            }
           

        }

       public static KeyValues EnterValues()
        {
            KeyValues Res = new KeyValues();
            string line; 
            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader("apc.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] arr = line.Split(' ');
                Point z;
                z.X = Convert.ToInt32(arr[1]);
                z.Y = Convert.ToInt32(arr[2]);
                Res.Dict.Add(arr[0].ToLower(), z);
            }
            file.Close();
            return Res;
        }
    }
}