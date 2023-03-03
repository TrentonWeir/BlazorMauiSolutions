
using Microsoft.Office.Interop.Word;

namespace GoogleSheets
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string ConnectionPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string SavedFilesFolder = "MonthlyReports";
            string FolderPath = Path.Combine(ConnectionPath, SavedFilesFolder);
            string FileName = Path.Combine(FolderPath, "TestDocument.doc");

            Application wordApp = new Application();
            Document doc;
            if(!Path.Exists(FileName)) 
            {
                // Create a new document
                doc = wordApp.Documents.Add();
                doc.SaveAs2(FileName, true);
                doc.Close();
                
            }
            doc = wordApp.Documents.Open(FileName);

            var p = doc.Content.Paragraphs.Add();
            p.Range.ListFormat.ApplyBulletDefault();
            for(var i = 0; i < 100; i++)
            {
                p.Range.InsertBefore($"Bulletin: {i}");
                p.Range.InsertParagraphAfter();
            }

            doc.Save();

            // Close the document and application
            doc.Close();
            wordApp.Quit();
        }
    }
}



