using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Main
{
    

    class Program
    {
        static void Main(string[] args)
        {
           InputModule.InputText.KeyValues PictureMap =  InputModule.InputText.EnterValues();
           Dictionary<string,Dictionary<string,double>> q = InputModule.Input.RunInputModule("C:\\Users\\Sokolov\\Documents\\Visual Studio 2017\\Projects\\InputModule\\InputModule\\Test.xlsx", PictureMap);
           SorterModule.Sorter.ToDrawer(q, PictureMap,0,0,0,0,0,256);
        }
    }
}
