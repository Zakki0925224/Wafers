using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Wafers.Web;

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
            return  "dos [DOSコマンド] - 入力したDOSコマンドを実行\n" +
                    "exit - Wafersを終了\n" +
                    "server [引数] - サーバー処理を実行\n" +
                    "txtread [パス] - 指定したパスのテキストファイルを表示\n" +
                    "username [引数] - ユーザー名処理を実行\n"+
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
        /// txtreadヘルプ
        /// </summary>
        /// <returns></returns>
        public string Txtread_help()
        {
            return "ファイルパスが指定されていません。詳細は\"help\"または\"?\"を入力して確認できます。";
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
            Properties.Settings.Default.Username = "user";
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
            return "使い方: username [引数]\n" +
                    "-c - ユーザー名を変更します。\n" +
                    "-r - ユーザー名を初期化します。\n" +
                    "-s - 現在設定されているユーザー名を取得します。";
        }

        /// <summary>
        /// dosコマンドを実行
        /// 結果を返す
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public void Dos(string cmd)
        {
            //Processオブジェクトを作成
            Process p = new Process();
            //出力とエラーをストリームに書き込むようにする
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            //OutputDataReceivedとErrorDataReceivedイベントハンドラを追加
            p.OutputDataReceived += p_OutputDataReceived;
            p.ErrorDataReceived += p_ErrorDataReceived;

            p.StartInfo.FileName = Environment.GetEnvironmentVariable("ComSpec");
            p.StartInfo.RedirectStandardInput = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.Arguments = @"/c "+cmd;

            //起動
            p.Start();

            //非同期で出力とエラーの読み取りを開始
            p.BeginOutputReadLine();
            p.BeginErrorReadLine();

            p.WaitForExit();
            p.Close();
            
        }

        /// <summary>
        /// OutoutDataReceivedイベントハンドラ
        /// 行が出力されるたびに呼び出される
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void p_OutputDataReceived(object sender,DataReceivedEventArgs e)
        {
            //出力された文字列を表示する
            Console.WriteLine(e.Data);
        }

        /// <summary>
        /// ErrorDataReceivedイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void p_ErrorDataReceived(object sender,DataReceivedEventArgs e)
        {
            //エラー出力された文字列を表示する
            Console.WriteLine(e.Data);

        }

        /// <summary>
        /// DOSコマンドヘルプ
        /// </summary>
        /// <returns></returns>
        public string Dos_help()
        {
            return "DOSコマンドを入力してください。";
        }

        /// <summary>
        /// サーバーヘルプ
        /// </summary>
        /// <returns></returns>
        public string Server_help()
        {
            return "使い方: server [引数]\n" +
                    "-a - 設定されているアドレスを表示します。\n" +
                    "-c - サーバーを終了します（サーバーコンソール内のみで有効）\n" +
                    "-o - サーバーを開きます。\n" +
                    "-p - 設定されているサーバーディレクトリを表示します。";
        }

        /// <summary>
        /// Webサーバー開始します
        /// </summary>
        public void Server_start()
        {
            string place = Properties.Settings.Default.Serverplace;

            Server server = new Server();
            server.Main(place);
        }

        /// <summary>
        /// サーバーアドレスを返します
        /// </summary>
        /// <returns></returns>
        public string Server_add()
        {
            string address = Properties.Settings.Default.Serveraddress;
            return address;
        }

        /// <summary>
        /// サーバーディレクトリを返します
        /// </summary>
        /// <returns></returns>
        public string Server_dir()
        {
            string dir = Properties.Settings.Default.Serverplace;
            return dir;
        }
    }
}
