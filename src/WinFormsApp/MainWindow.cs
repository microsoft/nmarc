// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using NMARC.Models;
using NMARC.Serialization;
using System;
using System.Windows.Forms;

namespace NMARC
{
    public partial class FrmNativeModeConc : Form
    {
        private string fileExtension= ".CSV";
        private string outputSeparator = ",";

        public FrmNativeModeConc()
        {
            InitializeComponent();
        }

        private void LoadYamlFile_Click(object sender, EventArgs e)
        {
            if (dlgOpenYaml.ShowDialog() == DialogResult.OK)
            {
                txtYamlInputPath.Text = dlgOpenYaml.FileName;
                txtResultsBox.Text = "";
            }
        }

        private void BtnSetOutputDir_Click(object sender, EventArgs e)
        {
            if (DlgSelectOutputFolder.ShowDialog() == DialogResult.OK)
            {
                TxtOutputPath.Text = DlgSelectOutputFolder.SelectedPath;
                btnConvert.Enabled = true;
            }
        }

        private void BtnOptions_Click(object sender, EventArgs e)
        {
            using (var dialog = new OptionsDialog(fileExtension, outputSeparator))
            {
                var result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    fileExtension = dialog.FileExtension;
                    outputSeparator = dialog.OutputSeparator;
                    Console.WriteLine($"File Extension: {dialog.FileExtension}\r\nOutput Separator: {dialog.OutputSeparator}");
                }
            }
        }

        private void BtnConvert_Click(object sender, EventArgs e)
        {
            txtResultsBox.Text += "Started conversion...\n\r\n";

            try
            {
                var report = AlignmentReportParser.ParseAlignmentReport(txtYamlInputPath.Text);
                
                txtResultsBox.Text += "YAML file loaded and parsed.\n\r\n";
                txtResultsBox.Text += $"Found:\n\r\n";

                if (report.Groups != null)
                {
                    txtResultsBox.Text += GenerateResultLine("groups", report.Groups.Count);
                }
                if (report.Users != null)
                {
                    txtResultsBox.Text += GenerateResultLine("users", report.Users.Count);
                }
                if (report.GroupLevelGuests != null)
                {
                    txtResultsBox.Text += GenerateResultLine("guests", report.GroupLevelGuests.Count);
                }
                
                if (report.Groups.Count == 0 && report.Users.Count == 0)
                {
                    txtResultsBox.Text += $"No items to export.\n\r\n";
                }
                else
                { 
                    txtResultsBox.Text += $"Exporting to {TxtOutputPath.Text}.\n\r\n";
                    ExportReport(report, DlgSelectOutputFolder.SelectedPath, fileExtension, outputSeparator);
                    txtResultsBox.Text += "Export complete.\n\r\n";
                }
            }
            catch (Exception exception)
            {
                txtResultsBox.Text += exception;

                txtResultsBox.Text +=
                    "\n\r\n\n\r\nAn error occurred. Please report the messages listed above after removing any sensitive data.\n\r\n";
            }
        }

        /// <summary>
        /// Exports the alignment report to multiple files in a specific folder.
        /// </summary>
        /// <param name="report">AlignmentReport instance containing deserialized data.</param>
        private void ExportReport(AlignmentReport report, string path, string extension, string separator)
        {
            // TODO: Refactoring the code in this method requires some extra work:
            //       * Headers match up with the models. Use reflection, or something newer in C#, to get these automatically.
            //       * Manually parse the YAML, so that we don't have to deal with the dictionaries at the top-level.
            //       * Warn about path not being selected.

            separator = separator.Replace("\\t", "\t"); // Permit tabs in output

            Console.WriteLine("Write...");

            var reportWriter = new ReportWriter(report, separator);
            reportWriter.Write(path, extension);
        }

        /// <summary>
        /// Formats lines about the object counts.
        /// </summary>
        /// <param name="name">Name of the object.</param>
        /// <param name="count">Count of objects.</param>
        /// <returns></returns>
        public string GenerateResultLine(string name, long count)
        {
            return $"{count} {name}\n\r\n"; ;
        }
    }
}