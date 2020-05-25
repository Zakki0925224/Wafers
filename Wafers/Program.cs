using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wafers.Core;

namespace Wafers
{
    class Program
    {
        static void Main(string[] args)
        {
            //ウィンドウタイトルの初期化
            Console.Title = "Wafers";

            Display disp = new Display();
            disp.View();
        }
    }
}
