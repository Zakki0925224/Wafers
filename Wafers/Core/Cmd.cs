using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wafers.Core;

namespace Wafers.Core
{
    /// <summary>
    /// コマンド管理クラス
    /// </summary>
    class Cmd
    {
        /// <summary>
        /// 入力されたコマンドに対して、特定のメッセージを返す
        /// </summary>
        /// <param name="entercmd"></param>
        public void Command(string entercmd)
        {
            Msg msg = new Msg();

            // バージョン情報表示
            if (entercmd == "version")
            {
                Console.WriteLine(msg.Ver());
                
            }

            // ヘルプ
            else if (entercmd == "help" || entercmd == "?")
            {
                Console.WriteLine(msg.Help());
            }

            // アプリケーション終了
            else if (entercmd == "exit")
            {
                msg.Exit();
            }

            // プギャー（隠しコマンド）
            else if (entercmd == "pugya-!")
            {
                Console.WriteLine(msg.Pugyaa());
            }

            // 空白またはなにも入力されなかった場合
            else if (entercmd == "" || entercmd == " " || entercmd == "　")
            {
                //何もせずに戻る
            }

            // すべて当てはまらない場合
            else
            {
                Console.WriteLine(msg.Non_existing_cmd(entercmd));
            }
        }
    }
}
