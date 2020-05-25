using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wafers.Core;
namespace Wafers.Core
{
    /// <summary>
    /// 描画処理クラス
    /// </summary>
    class Display
    {
        /// <summary>
        /// コマンドラインUIを描画
        /// </summary>
        public void View()
        {
            // 初期のバージョン表示
            Msg msg = new Msg();
            Console.WriteLine(msg.Ver());

            while (true)
            {
                Console.Write("\n" + msg.AppTitle() + ">");

                // コマンドを読み取ってCmdクラスに渡す
                string command = Console.ReadLine();
                Cmd cmd = new Cmd();
                cmd.Command(command);
            }
        }
    }
}
