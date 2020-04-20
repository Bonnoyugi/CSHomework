using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCrawler {
  class SimpleCrawler {
    private Hashtable urls = new Hashtable();
    private int count = 0;
        string startUrl = null;
        string domain;
        string domainBac;
    static void Main(string[] args) {
      SimpleCrawler myCrawler = new SimpleCrawler();
      myCrawler.startUrl = "http://www.cnblogs.com/dstang2000/";
      if (args.Length >= 1) myCrawler.startUrl = args[0];
      myCrawler.urls.Add(myCrawler.startUrl, false);//加入初始页面
            myCrawler.domain = new Regex("^((http://)|(https://))?[^/]*").Match(myCrawler.startUrl).ToString();
            Console.WriteLine("域名："+myCrawler.domain);
            myCrawler.domainBac = new Regex("^https://").Replace(myCrawler.domain, "http://");
            myCrawler.domainBac = new Regex("^http://").Replace(myCrawler.domain, "https://");
      new Thread(myCrawler.Crawl).Start();
    }

    private void Crawl() {
      Console.WriteLine("开始爬行了.... ");
      while (true) {
        string current = null;
        foreach (string url in urls.Keys) {
                    if ((bool)urls[url])
                        continue;
                    current = url;
                    break;
        }

        if (current == null || count > 100) break;
        Console.WriteLine("爬行" + current + "页面!");
        string html = DownLoad(current); // 下载
        urls[current] = true;
        count++;
        Parse(html);//解析,并加入新的链接
        Console.WriteLine("爬行结束");
      }
    }

    public string DownLoad(string url) {
      try {
        WebClient webClient = new WebClient();
        webClient.Encoding = Encoding.UTF8;
        string html = webClient.DownloadString(url);
        string fileName = count.ToString();
        File.WriteAllText(fileName, html, Encoding.UTF8);
        return html;
      }
      catch (Exception ex) {
        Console.WriteLine(ex.Message);
        return "";
      }
    }

    private void Parse(string html) {
      string strRefInDomain = @"(href|HREF)[]*=[]*[""']("+domain+"|"+domainBac+@")[^""'#>]+(.html|.htm)[""']";
            string strRelRef = @"(href|HREF)[]*=[]*/[""'][^""'#>]+(.html|htm)[""']";
            MatchCollection matches = new Regex(strRefInDomain).Matches(html);
      foreach (Match match in matches) {
        strRefInDomain = match.Value.Substring(match.Value.IndexOf('=') + 1)
                  .Trim('"', '\"', '#', '>');
        if (strRefInDomain.Length == 0) continue;
        if (urls[strRefInDomain] == null) urls[strRefInDomain] = false;
      }
            matches = new Regex(strRelRef).Matches(html);
            foreach (Match match in matches)
            {
                strRelRef = match.Value.Substring(match.Value.IndexOf('=') + 1)
                          .Trim('"', '\"', '#', '>');
                strRelRef = match.Value.Insert(0, domain);
                if (strRelRef.Length == 0) continue;
                if (urls[strRelRef] == null) urls[strRelRef] = false;
            }
        }
  }
}
