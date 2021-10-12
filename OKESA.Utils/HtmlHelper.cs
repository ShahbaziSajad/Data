using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OKESA.Utils
{
    public static class HtmlHelper
    {
        public static HtmlDocument GetHtmlDocument(string template)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(template);
            return doc;
        }

        public static string GetAllText(string template)
        {
            HtmlDocument doc = GetHtmlDocument(template);
            return HtmlEntity.DeEntitize(doc.DocumentNode.InnerText);
        }

        public static string DictionaryToHtmlTable(IEnumerable<IDictionary<string, object>> pairs)
        {

            if (!pairs.Any()) return "<table></table>";

            var ths = pairs.First().Select(a => $@"<th bgcolor='#252525' style='border: 1px solid #EEEEEE; border-collapse: collapse;text-align:center; font-family: Verdana, Geneva, Helvetica, Arial, sans-serif; font-size: 12px; color: #EEEEEE; padding:10px; padding-left:0;'>{a.Key}</th>");
            var firstRow = $"<tr>{string.Join("", ths)}</tr>";

            var trs = "";
            foreach (var pair in pairs)
            {
                var tds = pair.Select(a => $"<td style='font-family: Verdana, Geneva, Helvetica, Arial, sans-serif; font-size: 13px;text-align:right;border: 1px solid #252525;border-collapse: collapse;padding:2px;'>{a.Value}</td>");
                trs += $"<tr>{string.Join("", tds)}</tr>";
            }
            return $"<table align='right' dir='rtl' width='94%' border='0' cellpadding='0' cellspacing='0'>{firstRow}{trs}</table>";

        }

        public static string ReplaceNode(string template, string keyword, string html)
        {
            HtmlDocument doc = GetHtmlDocument(template);
            var nodes = doc.DocumentNode.SelectNodes($"//*[text()[contains(., '{keyword}')]]");
            var newNode = HtmlNode.CreateNode(html);
            foreach (var item in nodes)
            {
                item.ParentNode.ReplaceChild(newNode, item);
            }
            return doc.DocumentNode.OuterHtml;
        }
    }
}
