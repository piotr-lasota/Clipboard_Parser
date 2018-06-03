using System;
using System.Windows;

namespace DMA_Clipboard_Grabber
{
    public class QueryPrinter
    {
        string query;

        public QueryPrinter(string query)
        {
            this.query = query;
        }

        public void PrintToPointedLocation()
        {
            Microsoft.Win32.SaveFileDialog SaveDialog = new Microsoft.Win32.SaveFileDialog();
            SaveDialog.FileName = "resultingQuery";
            SaveDialog.DefaultExt = ".qry";
            SaveDialog.Filter = "DMA stored queries|*.qry";
            SaveDialog.FilterIndex = 1;

            if (SaveDialog.ShowDialog() == true)
            {
                System.IO.File.WriteAllText(SaveDialog.FileName, query);
            }
        }

        public void PrintToDesktop()
        {
            System.IO.File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+@"\resultingQuery.qry", query);
        }
    }
}
