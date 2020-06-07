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
            string[] args = entercmd.Split(' ');


            //ユーザー名コマンド（引数なし）
            if (entercmd == "username")
            {
                Console.WriteLine(msg.Username_help());
            }

            //ユーザー名コマンド（引数あり）
            else if (args[0] == "username")
            {
                //ユーザー名変更
                if (args[1] == "change")
                {
                    msg.Username_register();
                }

                //ユーザー名初期化
                else if (args[1] == "reset")
                {
                    msg.Username_reset();
                }

                //ユーザー名取得
                else if (args[1] == "show")
                {
                    Console.WriteLine(msg.Username_show());
                }
                //それ以外（ヘルプ表示）
                else
                {
                    Console.WriteLine(msg.Username_help());
                }
            }

            // DOSコマンド
            else if (entercmd == "dos")
            {
                Console.WriteLine(msg.Dos_help());
            }
            else if (args[0] == "dos")
            {
                string[] doscmd = new string[args.Length - 1];
                string cmd;

                Array.Copy(args, 1, doscmd, 0, args.Length - 1);
                cmd = string.Join(" ", doscmd);

                msg.Dos(cmd);
            }


            // バージョン情報表示
            else if (entercmd == "version")
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

            // テキスト読み込み
            else if (entercmd == "txtread")
            {
                Console.Write("ファイルのパスを入力（\"/c\"でキャンセル）:");
                string path = Console.ReadLine();
                if (path == "/c")
                {
                    //何もせずに終了
                }
                else
                {
                    msg.Txtread(path);
                }
            }

            // Webサーバー構築
            else if (entercmd == "server")
            {
                Console.WriteLine(msg.Server_help());
            }
            else if (args[0] == "server")
            {
                // サーバー開始
                if (args[1] == "-o")
                {

                    Task task = Task.Run(() =>
                    {
                        msg.Server_start();
                    });
                }
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
