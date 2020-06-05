using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Wafers.Core
{
    /// <summary>
    /// メッセージ（コマンドの内部処理）管理クラス
    /// </summary>
    class Msg
    {
        /// <summary>
        /// バージョン表示
        /// </summary>
        /// <returns></returns>
        public string Ver()
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName();
            var fileVersionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);

            string appTitle = assemblyName.Name;
            string appVersion = assemblyName.Version.ToString();
            string copyright = fileVersionInfo.LegalCopyright;

            return appTitle + " - " + appVersion + " " + copyright;
        }


        /// <summary>
        /// アプリケーション名だけ表示
        /// </summary>
        /// <returns></returns>
        public string AppTitle()
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName();
            return assemblyName.Name;
        }


        /// <summary>
        /// 存在しないコマンドが入力された時のエラー表示
        /// </summary>
        public string Non_existing_cmd(string cmd)
        {
            return "\"" + cmd + "\"" + "は存在しないコマンドです。コマンドは\"help\"または\"?\"を入力して確認できます。";
        }


        /// <summary>
        /// ヘルプを表示
        /// </summary>
        /// <returns></returns>
        public string Help()
        {
            return  "exit - Wafersを終了\n" +
                    "txtread - 指定したパスでテキストを表示\n" +
                    "username change - ユーザー名を変更\n"+
                    "username reset - ユーザー名を初期化\n" +
                    "username show - 現在のユーザー名を取得\n" +
                    "version - バージョン情報を表示";
        }


        /// <summary>
        /// アプリケーション終了
        /// </summary>
        public void Exit()
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// プギャーコマンド
        /// </summary>
        /// <returns></returns>
        public string Pugyaa()
        {
            return  @"　　　　ｍ9
                    　　　　 ﾉ
                    ﾌﾟｷﾞｬｰ (^Д^)
                    　　　　( (9ｍ
                    　　　　<　＼
                    
                    　 　 9ｍ
                    　　　 ＼＼
                    　　　∧∧｜
                    　　 (^Д^)　ﾌﾟｷﾞｬｰ
                    　　 /　　ヽ
                    　 〈〈)　 |　 ｍ9
                    　　 ＼ｍ9ノ　　ﾉ
                    　　／／＼＼　(^Д^)
                    `_／／　／／　 ( (9ｍ
                    (＿ﾉ　 (＿)　　<　＼";
        }


        /// <summary>
        /// テキストファイルを読み込んで表示するコマンド
        /// </summary>
        public void Txtread(string path)
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(@path, Encoding.GetEncoding("utf-8")))
                {
                    string text = sr.ReadToEnd();

                    Console.WriteLine("----------\n");
                    Console.WriteLine(text);
                }
            }
            else
            {
                Console.WriteLine("ファイルが存在しません。");
            }

            
        }


        /// <summary>
        /// ユーザー名を登録する
        /// </summary>
        public void Username_register()
        {
            while(true)
            {
                Console.Write("登録したいユーザー名を入力:");
                string username = Console.ReadLine();

                if (username == "" || username == " " || username == "　")
                {
                    Console.WriteLine("入力されたユーザー名は適用できません。");
                }
                else
                {
                    Properties.Settings.Default.Username = username;
                    Properties.Settings.Default.Save();
                    break;
                }
            }
            
        }


        /// <summary>
        /// ユーザー名を初期化
        /// </summary>
        public void Username_reset()
        {
            Properties.Settings.Default.Username = "";
            Properties.Settings.Default.Save();
            Console.WriteLine("ユーザー名の初期化が完了しました。");
        }

        /// <summary>
        /// ユーザー名を取得
        /// </summary>
        public string Username_show()
        {
            string name = Properties.Settings.Default.Username;

            return name;
        }

        /// <summary>
        /// ユーザー名コマンドヘルプ
        /// </summary>
        /// <returns></returns>
        public string Username_help()
        {
            return "引数が指定されてないか、入力された引数は対応していません。コマンドは\"help\"または\"?\"を入力して確認できます。";
        }

        /// <summary>
        /// カイル君
        /// </summary>
        /// <returns></returns>
        public string Dolphin()
        {
            return "　　　＿_／|_\n　＿／　　　 ＼\n〈―― ●　　　＼\n　￣＼_＿＿　　　ヽ\n　　 /＞―｜ヽ―-､|\n　　　　　 ＼|￣＼|_\n　　　　　　　　(人_)";
        }
    }
}
