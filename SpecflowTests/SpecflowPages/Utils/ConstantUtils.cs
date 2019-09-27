using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SpecflowPages
{
    public class ConstantUtils
    {
        //Base Url
        public static string Url = "http://www.skillswap.pro/";

        //ScreenshotPath
        public static string ScreenshotPath = Directory.GetCurrentDirectory() + @"SpecflowPages\TestReports\Screenshots\";

        //ExtentReportsPath
        public static string ReportsPath = Directory.GetCurrentDirectory() + @"\SpecflowPages\TestReports\ReportHTML.html\";

        //ReportXML Path
        public static string ReportXMLPath = Directory.GetCurrentDirectory() + @"SpecflowPages\TestReports\ReportXML.xml\";
    }
}
