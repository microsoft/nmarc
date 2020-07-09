// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Windows.Forms;
using NMARC.Models;
using NMARC.Serialization;

namespace NMARC
{
    public partial class FrmNativeModeConc : Form
    {
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

        private void BtnConvert_Click(object sender, EventArgs e)
        {
            txtResultsBox.Text += "Started conversion...\n\r\n";

            try
            {
                var report = AlignmentReportParser.ParseAlignmentReport(txtYamlInputPath.Text);
                
                txtResultsBox.Text += "YAML file loaded and parsed.\n\r\n";
                txtResultsBox.Text += $"Found {report.Groups.Count} groups and {report.Users.Count} users.\n\r\n";
                
                if (report.Groups.Count == 0 && report.Users.Count == 0)
                {
                    txtResultsBox.Text += $"No items to export.\n\r\n";
                }
                else
                { 
                    txtResultsBox.Text += $"Exporting to {TxtOutputPath.Text}.\n\r\n";
                    ExportReport(report);
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
        private void ExportReport(AlignmentReport report)
        {
            // TODO: Refactoring the code in this method requires some extra work:
            //       * Headers match up with the models. Use reflection, or something newer in C#, to get these automatically.
            //       * Manually parse the YAML, so that we don't have to deal with the dictionaries at the top-level.
            //       * Warn about path not being selected.

            string basePath = DlgSelectOutputFolder.SelectedPath;

            Console.WriteLine("Write...");
            
            // GROUPS
            var groupOutput = new StringBuilder();

            groupOutput.AppendLine(
                "Id,Name,Type,PrivacySetting,State,MessageCount,LastMessageDate,ConnectedToO365,GroupAdministrators,Memberships.External,Memberships.Internal,Uploads.SharePoint,Uploads.Yammer");
            foreach (var group in report.Groups)
            {
                Console.WriteLine($"{group.Id}:{group.Name}");

                groupOutput.AppendLine(group.GetCsv());
            }

            Utilities.WriteFile($@"{basePath}\groups.txt", groupOutput);

            // USERS
            var userOutput = new StringBuilder();
            userOutput.AppendLine(
                "Email,Internal,State,PrivateFileCount,IsUserMapped,PublicMessageCount,PrivateMessageCount,LastAccessed");
            foreach (var user in report.Users)
            {
                Console.WriteLine($"{user.Id}:{user.Email}");

                userOutput.AppendLine(user.GetCsv());
            }

            Utilities.WriteFile($@"{basePath}\users.txt", userOutput);
        }
    }
}