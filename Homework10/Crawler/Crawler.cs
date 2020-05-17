using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Crawler
{
    class Crawler
    {
        //
        public event Action<Crawler, int, string, string> PageDownloaded;
        //targetUrls主要的作用就是防止重复爬取网页，记录已经爬取过的网页
        private ConcurrentDictionary<string, bool> targetUrls = new ConcurrentDictionary<string, bool>();

        private ConcurrentQueue<string> pending = new ConcurrentQueue<string>();

        private static readonly string urlDetectRegex = @"(href|HREF)\s*=\s*[""'](?<url>[^""'#>]+)[""']";

        public static readonly string urlParseRegex = @"^(?<site>https?://(?<host>[\w\d.]+)(:\d+)?($|/))([\w\d]+/)*(?<file>[^#?]*)";

        public string startUrl;

        private int index = 0;

        public Crawler()
        {

        }

        public void Start()
        {
            targetUrls.Clear();
            pending.Enqueue(startUrl);
            List<Task> tasks = new List<Task>();
            index = 1;

            while(pending.TryDequeue(out string url))
            {
                Task task = Task.Run(() => DownloadAndParse(url));
                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());
        }

        private void DownloadAndParse(string url)
        {
            try
            {
                string html = Download(url);
                targetUrls[url] = true;
                Parse(html, url);
            }catch(Exception e)
            {
                PageDownloaded(this, -1, url, "failed");//索引应当按照老师的做法直接在参数中给明才好
            }
        }

        private string Download(string url)
        {
            WebClient webClient = new WebClient();
            string html = webClient.DownloadString(url);
            File.WriteAllText(index+".html", html);
            PageDownloaded(this, index, url, "success");
            index++;
            return html;
        }

        //分析url检查是不是html
        private void Parse(string html, string pageUrl)
        {
            MatchCollection matches = new Regex(urlDetectRegex).Matches(html);
            foreach(Match match in matches)
            {
                string url = match.Groups["url"].Value;
                Match urlMatch = new Regex(urlParseRegex).Match(url);
                string host = urlMatch.Groups["host"].Value;
                string file = urlMatch.Groups["file"].Value;
                if (file == "") file = "index.html";
                if (Regex.IsMatch(file, @".html?$") && !targetUrls.ContainsKey(url))
                {
                    pending.Enqueue(url);
                    targetUrls.TryAdd(url, false);
                }
            }
        }

        //static private string FixUrl();
    }
}
