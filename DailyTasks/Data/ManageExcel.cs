using DailyTasks.Data.Models;
using Excel = Microsoft.Office.Interop.Excel;


namespace DailyTasks.Data
{
    public class ManageExcel
    {
        private static string ConnectionPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private static string SavedFilesFolder = "MonthlyReports";
        private static string FolderPath = Path.Combine(ConnectionPath, SavedFilesFolder);
        private Excel.Application _App;
        public Excel.Workbook _Workbook { get; set; }
        
        private Excel.Application ExcelConnection()
        {
            Excel.Application app = new();
            app.Visible = false;
            return app;
        }
        private void Initialize()
        {
            if (!Directory.Exists(FolderPath)) Directory.CreateDirectory(FolderPath);
        }
        private void CheckPath()
        {
            if (!Path.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }
        }
        private bool CheckFileExists(string fileName, Excel.Application app)
        {
            CheckPath();
            if (!Path.Exists(Path.Combine(FolderPath, fileName)))
            {
                Excel.Workbook workbook = app.Workbooks.Add();
                workbook.SaveAs(Path.Combine(FolderPath, fileName));
                var ws = (Excel.Worksheet)workbook.ActiveSheet;
                ws.Cells[1, 1] = "DATE";
                ws.Cells[1, 2] = "TITLE";
                ws.Cells[1, 3] = "DESCRIPTION";
                ws.Cells[1, 4] = "STATUS";
                ws.Cells[1, 5] = "THREATS";
                return false;
            }
            return true;
        }
        private Excel.Worksheet ConnectToWorkBook(string fileName = null)
        {
            _App = ExcelConnection();
            Initialize();
            if (string.IsNullOrEmpty(fileName))
            {
                var month = DateTime.Now.ToString("MMMM");
                var year = DateTime.Now.ToString("yyyy");
                fileName = $"Reports.{month}{year}.xlsx";
            }
            CheckFileExists(fileName, _App);
            _Workbook = _App.Workbooks.Open(Path.Combine(FolderPath, fileName));
            return (Excel.Worksheet) _Workbook.ActiveSheet;
        }

        public List<string> GetAllReportFiles()
        {
            CheckPath();
            List<string> result = new();
            var files = Directory.GetFiles(FolderPath).ToList();
            files.ForEach(x => result.Add(Path.GetFileName(x)));
            return result;
        }
        private int GetNextRow(Excel.Range r) => r.Cells.Find("*", System.Reflection.Missing.Value,
                     System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                     Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlPrevious,
                     false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Row;
        private void SaveTask(DailyTask task, Excel.Range ws = null)
        {
            bool isMultiple = true;
            if (ws == null)
            {
                ws = ConnectToWorkBook().Cells;
                isMultiple = false;
            }
            int lr = GetNextRow(ws);
            ws[lr, 1] = task.Date;
            ws[lr, 2] = task.Title;
            ws[lr, 3] = task.Description;
            ws[GetNextRow(ws), 2] = $"STATUS: {task.Status}";
            ws[GetNextRow(ws), 2] = $"THREATS: {task.Threats}";
            if(!isMultiple) { _App.Quit(); }
        }
        public void CreateReport(List<DailyTask> tasks)
        {
            var ws = ConnectToWorkBook().Cells;
            tasks.ForEach(task => SaveTask(task,ws));
            _Workbook.Save();
            ws.Application.Quit();
        }
    }
}
