using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NillertronNotes.Static
{
    public static class StaticHelpers
    {
        public static string ReplaceToHtmlTags(string s)
        {
            s = s.Replace("/F", "<b>");
            s = s.Replace("F\\", "</b>");

            s = s.Replace("/U", "<u>");
            s = s.Replace("U\\", "</u>");

            s = s.Replace("/IMG", "<img src=\"");
            s = s.Replace("IMG\\", "\" class=\"img-thumbnail\" />");
            s = s.Replace("/LINK", "<a href=\"http://");
            s = s.Replace("LINK\\", "\" target=\"_blank\">Link</a>");
            s = s.Replace("/I", "<i>");
            s = s.Replace("I\\", "</i>");

            return s;
        }
        /// <summary>
        /// Used to display text on a c# level, for exmaple loaded data from database that's in html format with html tags. This method Converts the html tags to plain text.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ReplaceToPlainText(string s)
        {
            s = s.Replace("<b>", "/F");
            s = s.Replace("</b>", "F\\");

            s = s.Replace("<u>", "/U");
            s = s.Replace("</u>", "U\\");

            s = s.Replace("<img src=\"", "/IMG");
            s = s.Replace("\" class=\"img-thumbnail\" />", "IMG\\");
            s = s.Replace("<a href=\"http://", "/LINK");
            s = s.Replace("\" target=\"_blank\">Link</a>", "LINK\\");
            s = s.Replace("<i>", "/I");
            s = s.Replace("</i>", "I\\");

            s = s.Replace("<br />", "\n");
            s = s.Replace("<p>", "");
            s = s.Replace("</p>", "\n");

            s = s.Replace("&quot;", "\"");

            return s;
        }
        public static string CheckFileExistsReplaceName(string path, string fileName)
        {
            var count = 1;
            var originalPath = path;

            path = Path.Combine(path, fileName);
            var originalFileName = fileName;
            while (File.Exists(path))
            {
                for (int i = 0; i < fileName.Length; i++)
                {
                    if (fileName[i] == '.')
                    {
                        fileName = originalFileName;
                        var temp = fileName.Substring(0, i);
                        var rest = fileName.Substring(i + 1, fileName.Length - i - 1);
                        temp += $"{count}.";
                        temp += rest;
                        path = Path.Combine(originalPath, temp);
                        break;
                    }
                }
                count++;
            }
            return path;
        }
    }
}
