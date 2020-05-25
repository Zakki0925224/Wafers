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
    /// メッセージ（システムメッセージ）管理クラス
    /// </summary>
    class Msg
    {
        /// <summary>
        /// バージョン表示）
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
    }
}
