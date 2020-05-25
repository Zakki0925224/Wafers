using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
            return  "　　　　ｍ9\n" +
                    "　　　　 ﾉ\n" +
                    "ﾌﾟｷﾞｬｰ (^Д^)\n" +
                    "　　　　( (9ｍ\n" +
                    "　　　　<　＼\n" +
                    "\n\n" +
                    "　 　 9ｍ\n" +
                    "　　　 ＼＼\n" +
                    "　　　∧∧｜\n" +
                    "　　 (^Д^)　ﾌﾟｷﾞｬｰ\n" +
                    "　　 /　　ヽ\n" +
                    "　 〈〈)　 |　 ｍ9\n" +
                    "　　 ＼ｍ9ノ　　ﾉ\n" +
                    "　　／／＼＼　(^Д^)\n" +
                    "`_／／　／／　 ( (9ｍ\n" +
                    "(＿ﾉ　 (＿)　　<　＼";
        }
    }
}
