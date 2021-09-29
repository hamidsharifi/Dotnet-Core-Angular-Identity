using DevExpress.Compatibility.System.Web;
using DevExpress.DataAccess.Excel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Web.ReportDesigner;
using Microsoft.AspNetCore.Mvc;

namespace Avery.LabelManager.Controllers {
    [Route("api/[controller]")]
    public class ReportDesignerController: Controller {
        [HttpPost("[action]")]
        public object GetReportDesignerModel([FromForm]string reportUrl) 
        {
            ExcelDataSource excelDataSource = new ExcelDataSource();
            excelDataSource.FileName = "..//Data//ExcelFiles//Numeric1SideTab.csv";

            // Specify import settings.
            CsvSourceOptions csvSourceOptions = new CsvSourceOptions();
            csvSourceOptions.DetectEncoding = true;
            csvSourceOptions.DetectNewlineType = true;
            csvSourceOptions.DetectValueSeparator = true;
            excelDataSource.SourceOptions = csvSourceOptions;

            // Define the data source schema.
            FieldInfo fileNumber = new FieldInfo { Name = "FileNumber", Type = typeof(string), Selected = false };
            FieldInfo year = new FieldInfo { Name = "Year", Type = typeof(int) };
            FieldInfo colourBar = new FieldInfo { Name = "Colour Bar", Type = typeof(string) };
            // Add the created fields to the data source schema in the order that matches the column order in the source file.
            excelDataSource.Schema.AddRange(new FieldInfo[] { fileNumber, year, colourBar });


            string modelJsonScript = new ReportDesignerClientSideModelGenerator(HttpContext.RequestServices).GetJsonModelScript(reportUrl, null, "/DXXRD", "/DXXRDV", "/DXXQB");
            var result = new JavaScriptSerializer().Deserialize<object>(modelJsonScript);
            return result;
        }
    }
}