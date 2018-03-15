using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shit
{
    public partial class OldClass : Form
    {
        private int partNumberLength = 13;
        private int SelectedEnv { get; set; }
        private string ThirdCharacter { get; set; }
        private string EnvLine { get; set; }
        public string ResultingQuery { get; set; }
        public string ClipboardInput { get; set; }

        private List<String> TreatedIdentifiers = new List<string>();
        private string partLine = "PART_LIST;S_PART_NUMBER;WITH;ReplaceMe;;";
        private string envLine = "#CDMA.CATCON.ReplaceMe.PART";
        private static string savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\resultingQuery.qry";

        public MainForm()
        {
            InitializeComponent();


            // Select DEFINITN (0), DESIGN(
            using (var form = new TypeSelectorForm())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    SelectedEnv = form.EnvironmentType;
                }
            }

            ClipboardInput = Clipboard.GetText();

            // Depending on the selected environment, set the first line content and the third character
            // that'll be checked in the parts.
            switch (SelectedEnv)
            {
                case 1: // DEFINITN
                    ThirdCharacter = "0";
                    EnvLine = envLine.Replace("ReplaceMe", "DEFINITN");

                    break;

                case 2: // DESIGN
                    ThirdCharacter = "D";
                    EnvLine = envLine.Replace("ReplaceMe", "DESIGN");

                    break;

                case 3: // COMMERCE
                    ThirdCharacter = "R";
                    EnvLine = envLine.Replace("ReplaceMe", "COMMERCE");

                    break;
            }

            // Filter the text content of the clipboard.
            foreach (string str in ClipboardInput.Split())
            {
                if (!(str.Length == partNumberLength && str.Substring(2, 1) == ThirdCharacter))
                {
                    continue;
                }
                TreatedIdentifiers.Add(str);
            }

            // Check if there's anything to process:
            if (TreatedIdentifiers == null || TreatedIdentifiers.Count == 0)
            {
                this.mainButton.Enabled = false;
                this.mainButton.Text = "No matching results";
                MessageBox.Show("There were no matching results in your clipboard\nExiting", "Sorry...");

                if (System.Windows.Forms.Application.MessageLoop)
                {
                    System.Windows.Forms.Application.Exit();
                }
                else
                {
                    System.Environment.Exit(1);
                }
            }

            if (TreatedIdentifiers.Count == 1)
            {
                ResultingQuery += EnvLine + "\n" + partLine.Replace("ReplaceMe", TreatedIdentifiers[0]) + "\n";
                this.mainButton.Enabled = PrintResults(savePath, ResultingQuery);
                this.mainButton.Text = "Open query location";
                return;
            }

            ////// Prepare the output file:
            // insert the Environment line
            ResultingQuery += EnvLine + "\n";
            // insert all the lines
            foreach (string partCode in TreatedIdentifiers)
            {
                ResultingQuery += partLine.Replace("ReplaceMe", partCode) + "\n";
            }
            // Fill using Reversed Poish Notation with OR statements

            foreach (int i in Enumerable.Range(1, TreatedIdentifiers.Count - 1))
            {
                ResultingQuery += "OR\n";
            }

            // TestQuery
            this.mainButton.Enabled = PrintResults(savePath, ResultingQuery);
            this.secondaryButton.Enabled = this.mainButton.Enabled;
            this.pathLabel.Text = "Saved to Desktop as resultingQuery.qry";
            this.mainButton.Text = "Open query location\nand exit";
        }

        private static bool PrintResults(String path, String query)
        {
            System.IO.File.WriteAllText(path, query);

            try
            {
                System.IO.File.WriteAllText(path, query);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private void mainButton_Click(object sender, EventArgs e)
        {
            Process.Start(new FileInfo(savePath).Directory.FullName);
            if (System.Windows.Forms.Application.MessageLoop)
            {
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                System.Environment.Exit(1);
            }
        }

        private void secondaryButton_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.MessageLoop)
            {
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                System.Environment.Exit(1);
            }
        }
    }
}