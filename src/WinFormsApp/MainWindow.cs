// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Collections.Generic;
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
            
            WriteGroupsReport(report, basePath);

            WriteUsersReport(report, basePath);

            WriteGroupAdminsReport(report, basePath);

            WriteActiveCommunityGuestsReport(report, basePath);

            WriteOtherCommunityGuestsReport(report, basePath);
        }

        private static void WriteGroupAdminsReport(AlignmentReport report, string basePath)
        {
            var groupAdminOutput = new StringBuilder();
            groupAdminOutput.AppendLine("GroupID,CreationRightsState,Email");

            foreach (var group in report.Groups)
            {
                var admins = group.Administrators;

                if (!(admins is string))
                {
                    Console.WriteLine($@"Group:{group.Administrators}");
                    var convAdmins = (Dictionary<object, object>) admins;

                    foreach (KeyValuePair<object, object> entry in convAdmins)
                    {
                        var key = entry.Key as string;
                        var vals = (List<object>)entry.Value;

                        foreach (var adminEmail in vals)
                        {
                            var email = (string) adminEmail;
                            groupAdminOutput.AppendLine( $"{group.Id},{key},{email}");
                        }
                    }
                }
                else
                {
                    groupAdminOutput.AppendLine($"{group.Id},,No Admins");
                }
            }

            Utilities.WriteFile($@"{basePath}\groupadmins.txt", groupAdminOutput);
        }

        private static void WriteActiveCommunityGuestsReport(AlignmentReport report, string basePath)
        {
            var communityGuestOutput = new StringBuilder();
            communityGuestOutput.AppendLine("GroupID,Email");

            foreach (var group in report.Groups)
            {
                if(group.ActiveCommunityGuests != null) { 
                    if(group.ActiveCommunityGuests.Count > 0)
                    {
                        foreach (var guest in group.ActiveCommunityGuests)
                        {
                            communityGuestOutput.AppendLine($"{group.Id},{guest}");
                        }
                    }
                }
            }

            Utilities.WriteFile($@"{basePath}\communityguests.txt", communityGuestOutput);
        }

        private static void WriteOtherCommunityGuestsReport(AlignmentReport report, string basePath)
        {
            var communityGuestOutput = new StringBuilder();
            communityGuestOutput.AppendLine("GroupID,Email");

            foreach (var group in report.Groups)
            {
                if (group.OtherCommunityGuests != null)
                {
                    if (group.OtherCommunityGuests.Count > 0)
                    {
                        foreach (var guest in group.OtherCommunityGuests)
                        {
                            communityGuestOutput.AppendLine($"{group.Id},{guest}");
                        }
                    }
                }
            }

            Utilities.WriteFile($@"{basePath}\othercommunityguests.txt", communityGuestOutput);
        }

        private static void WriteUsersReport(AlignmentReport report, string basePath)
        {
            // USERS
            var userOutput = new StringBuilder();
            userOutput.AppendLine(
                "Email,Internal,State,PrivateFileCount,PublicMessageCount,PrivateMessageCount,LastAccessed,AAD_State");
            foreach (var user in report.Users)
            {
                Console.WriteLine($"{user.Id}:{user.Email}");

                userOutput.AppendLine(user.GetCsv());
            }

            Utilities.WriteFile($@"{basePath}\users.txt", userOutput);
        }

        private static void WriteGroupsReport(AlignmentReport report, string basePath)
        {
            // GROUPS
            var groupOutput = new StringBuilder();

            groupOutput.AppendLine(
                "Id,Name,Type,PrivacySetting,State,MessageCount,LastMessageDate,ConnectedToO365,Memberships.External,Memberships.Internal,Uploads.SharePoint,Uploads.Yammer");
            foreach (var group in report.Groups)
            {
                Console.WriteLine($"{@group.Id}:{@group.Name}");

                groupOutput.AppendLine(@group.GetCsv());
            }

            Utilities.WriteFile($@"{basePath}\groups.txt", groupOutput);
        }
    }
}