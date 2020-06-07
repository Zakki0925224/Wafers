using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using Wafers.Core;

namespace Wafers.Web
{
    class Server
    {

        /// <summary>
        /// サーバー実行メソッドの呼び出し
        /// </summary>
        public void Main(string place)
        {

            try
            {
                WebServer(@place, "8080");
            }
            catch (Exception ex)
            {
                WebServerLog("Error: " + ex.Message);
                WebServerLog("サーバーは終了しました。");
            }
        }

        /// <summary>
        /// サーバー実行メソッド
        /// </summary>
        public void WebServer(string place, string port)
        {

            //ドキュメントルート(docroot)
            string docroot = place;

            HttpListener listener = new HttpListener();
            string url = "http://127.0.0.1:" + port + "/";

            // URLを設定に保存
            Properties.Settings.Default.Serveraddress = url;

            listener.Prefixes.Add(url);
            listener.Start();

            WebServerLog("サーバーは\""+url+"\"で実行されています。ルートフォルダは\""+place+"\"です。");
            System.Diagnostics.Process.Start(url);

            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest req = context.Request;
                HttpListenerResponse res = context.Response;

                //URL
                string urlPath = req.RawUrl;
                if (urlPath == "/")
                    urlPath = "/index.html";

                //実際のローカルファイルパス
                string path = docroot + urlPath.Replace("/", "\\");

                //ファイル内容を出力
                try
                {
                    res.StatusCode = 200;
                    byte[] content = File.ReadAllBytes(path);
                    res.OutputStream.Write(content, 0, content.Length);
                    WebServerLog("\""+path+"\"は正常に処理されました。");
                }
                catch (Exception ex)
                {
                    res.StatusCode = 500;
                    byte[] content = Encoding.Default.GetBytes(ex.Message);
                    res.OutputStream.Write(content, 0, content.Length);
                    WebServerLog(ex.Message);
                }

                res.Close();
            }
        }

        /// <summary>
        /// 実行中のサーバーのログを表示
        /// </summary>
        public void WebServerLog(string message)
        {
            DateTime dt = DateTime.Now;
            string time = dt.ToString("HH:mm:ss");

            Console.WriteLine("[{0}] {1}", time, message);

        }
    }
}
