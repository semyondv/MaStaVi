using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
namespace SorterModule
{
    public class Sorter
    {
        protected struct Border
        {
            public double min;
            public double max;
            public Border(double s, double e)
            {
                this.min = s;
                this.max = e;
            }
        }

        static int Rstep = 0;
        static int Gstep = 0;
        static int Bstep = 0;

        protected static List<Border> Dividers = new List<Border> { };
        private static List<double> FormList(Dictionary<string, Dictionary<string, double>> US)
        {
            List<double> result = new List<double> { };
            foreach (var item in US.First().Value)
            {
                result.Add(item.Value);
            }
            return result;
        }

        private static void GenerateDividers(Dictionary<string, Dictionary<string, double>> US, int n)
        {
            List<double> tosort = null;
            tosort = FormList(US);
            tosort.Distinct();
            tosort.OrderBy(q => q);
            if (tosort.Count <= 1)
            {

            }
            else
            {
                int n1 = Math.Min((int)Math.Floor((decimal)(tosort.Count() / n)), tosort.Count());

                List<Border> res = new List<Border> { };
                int s = 0;
                int e = n1;
                while (e <= tosort.Count)
                {
                    Dividers.Add(new Border(tosort[s], tosort[e]));
                    s = e; e = e + n1;
                }
                Dividers[0] = new Border(double.MinValue, Dividers[0].min);
                Dividers[Dividers.Count - 1] = new Border(Dividers[Dividers.Count - 1].min, double.MaxValue);
            }

        }

        static void CRstep(int Rstart, int Rend)
        {
            if (Dividers.Count != 0)
            { Rstep = ((Rend - Rstart) / Dividers.Count); }
            else Rstep = 0;
        }

        static void CGstep(int Gstart, int Gend)
        {
            if (Dividers.Count != 0)
            { Gstep = (Gend - Gstart) / Dividers.Count; }
            else Gstep = 0;
        }

       static void CBstep(int Bstart, int Bend)
        {
            if (Dividers.Count != 0)
            { Bstep = (Bend - Bstart) / Dividers.Count; }
            else
                Bstep = 0;
        }


        private static Tuple<int,int,int> GetColor (double q, int Rstart,int Gstart,int Bstart, int Rend, int Gend, int Bend)
        {
            int z = 0;
            foreach (var p in Dividers)
            {
                if ((q >= p.min) && (q < p.max))
                {
                    z =  Dividers.IndexOf(p);
                    break;
                }
            }
            int rf = Rstart + z * Rstep;
            int gf = Gstart + z * Gstep;
            int bf = Bstart + z * Bstep;
            return new Tuple<int, int, int>(Math.Min(Rstart + z * Rstep, Rend),
             Math.Min(Gstart + z * Gstep, Gend),
             Math.Min(Bstart + z * Bstep, Bend));
           

        }

        /*public static List<int> GetSplitList( int b, int e)//For paint
        {
            List<int> res = new List<int> { };
            double serv2 = (b + e) / (Dividers.Count);
            int serv = Convert.ToInt32(Math.Ceiling(serv2));
            int k = b;
            while (k <= e)
            {
                res.Add(k);
                k += serv;
            }
            return res;
        }

        //Переделать под нужды отрисовки!
        public static int GetColorByDividers(double q, List <int> l1)//Для подборки цвета.
        {
            foreach (var p in Dividers)
            {
                if ((q >= p.min) && (q < p.max))
                {
                    return l1[Dividers.IndexOf(p)];
                }
            }
            return 0;
        }*/



        private static string TryFind(string s, InputModule.InputText.KeyValues KeyVals)//A stripped-down auto corrector. Lowercases and exchanges " " on "_"
        {
            string s1= s.Replace(" ", "_");
            s1 = s1.ToLower();
            string res = "";
            if (KeyVals.Dict.ContainsKey(s1))
            {
                res = s1;
                return res;
            }
            return res;
        }

        //Работает. Пропускает неопределенные значения
        public static List<Tuple<int[],int[],int[],int[],int[]>> ToDrawer(Dictionary<string, Dictionary<string, double>> US, InputModule.InputText.KeyValues KeyVals,int Rstart,int Gstart,int Bstart, int Rend, int Gend, int Bend)
        {
            CRstep(Rstart, Rend);
            CBstep(Bstart, Bend);
            CGstep(Gstart, Gend);
            List<Tuple<int[], int[], int[], int[], int[]>> res = new List<Tuple<int[], int[], int[], int[], int[]>> { };
            int n = US.Count;
            if ( US.First().Value.Count < 30)
            {
                n = Math.Min(US.Count, 5);
            }
            if (US.First().Value.Count >= 30)
            {
                n = 10;
            }
 
            
            if (Dividers.Count == 0)
            {
                GenerateDividers(US, n);
            }
            CRstep(Rstart, Rend);
            CBstep(Bstart, Bend);
            CGstep(Gstart, Gend);
            foreach (var item in US)
            {
                
                int ser = (Convert.ToInt32(item.Key));
                int[] q1 = new int[US[item.Key].Count];
                int[] q2 = new int[US[item.Key].Count];
                int[] q3 = new int[US[item.Key].Count];
                int[] q4 = new int[US[item.Key].Count];
                int[] q5 = new int[US[item.Key].Count];
                int i = 0;
                foreach (var item1 in item.Value)
                {
                    if (KeyVals.Dict.ContainsKey(item1.Key))
                    {
                        q1[i] = KeyVals.Dict[item1.Key].X;
                        q2[i] = KeyVals.Dict[item1.Key].Y;
                        var t = GetColor(item1.Value, Rstart, Gstart, Bstart, Rend, Gend, Bend);
                        q3[i] = t.Item1;
                        q4[i] = t.Item2;
                        q5[i] = t.Item3;

                    }
                    else
                    {
                        string s1 = TryFind(item1.Key, KeyVals);
                        if (s1 != "")
                        {
                            q1[i] = KeyVals.Dict[s1].X;
                            q2[i] = KeyVals.Dict[s1].Y;
                            var t = GetColor(item1.Value, Rstart, Gstart, Bstart, Rend, Gend, Bend);
                            q3[i] = t.Item1;
                            q4[i] = t.Item2;
                            q5[i] = t.Item3;
                        }
                        else
                        {
                            q1[i] = 0;
                            q2[i] = 0;
                            q3[i] = 0;
                            q4[i] = 0;
                            q5[i] = 0;
                        }
                    }
                    i += 1;
                }
                res.Add(new Tuple<int[], int[], int[], int[], int[]>(q1, q2, q3, q4, q5));
            }

            return res;

        }

    }
}