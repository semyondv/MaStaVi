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

        protected static List<Border> Dividers = new List<Border> { };
        private static List<double> FormList(Dictionary<string, Dictionary<string, double>> US)
        {
            List<double> result = new List<double> { };
            foreach (var item in US)
            {
                result.Add(item.Value.First().Value);
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
                while (e != tosort.Count)
                {
                    Dividers.Add(new Border(tosort[s], tosort[e]));
                    s = e; e = e + n1;
                }
                Dividers[0] = new Border(double.MinValue, Dividers[0].min);
                Dividers[Dividers.Count - 1] = new Border(Dividers[Dividers.Count - 1].min, double.MaxValue);
            }

        }
        //Переделать под нужды отрисовки!
        private static int GetColorByDividers(double q)//Для подборки цвета.
        {
            foreach (var p in Dividers)
            {
                if ((q >= p.min) && (q < p.max))
                {
                    return 0;
                }
            }
            return 0;
        }



        private static string TryFind(string s, InputModule.InputText.KeyValues KeyVals)//A stripped-down auto corrector. Lowercases and exchanges " " on "_"
        {
            string s1= s.ToLower().Replace(" ", "_");
            string res = "";
            if (KeyVals.Dict.ContainsKey(s1))
            {
                res = s1;
                return res;
            }
            return res;
        }

        //Работает. Пропускает неопределенные значения
        public static Dictionary<int, Dictionary<InputModule.Point, int>> ToDrawer(Dictionary<string, Dictionary<string, double>> US, InputModule.InputText.KeyValues KeyVals, int n = 2)
        {
            Dictionary<int, Dictionary<InputModule.Point, int>> q = new Dictionary<int, Dictionary<InputModule.Point, int>> { };
            if (Dividers.Count == 0)
            {
                GenerateDividers(US, n);
            }
            foreach (var item in US)
            {
                int ser = (Convert.ToInt32(item.Key));
                q.Add(ser, new Dictionary<InputModule.Point, int> { });
                foreach (var item1 in item.Value)
                {
                    if (KeyVals.Dict.ContainsKey(item1.Key))
                    {
                        q[ser].Add(KeyVals.Dict[item1.Key], GetColorByDividers(item1.Value));
                    }
                    else
                    {
                        string s1 = TryFind(item1.Key, KeyVals);
                        q[ser].Add(KeyVals.Dict[s1], GetColorByDividers(item1.Value));
                    }
                }
            }

            return q;

        }

    }
}