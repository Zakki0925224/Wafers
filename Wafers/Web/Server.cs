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
                Console.WriteLine("Error: " + ex.Message);
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

            listener.Prefixes.Add(url);
            listener.Start();
            

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
                }
                catch (Exception ex)
                {
                    res.StatusCode = 500;
                    byte[] content = Encoding.Default.GetBytes(ex.Message);
                    res.OutputStream.Write(content, 0, content.Length);
                }
                res.Close();
            }
        }

        /// <summary>
        /// 実行中のサーバーのステータスを表示
        /// </summary>
        public void Status()
        {

        }
    }
}
