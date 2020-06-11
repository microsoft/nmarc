// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using NMARC.Models;
using NMARC.Serialization;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;

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
            }
        }

        private void BtnSetOutputDir_Click(object sender, EventArgs e)
        {
            if (DlgSelectOutputFolder.ShowDialog() == DialogResult.OK)
            {
                TxtOutputPath.Text = DlgSelectOutputFolder.SelectedPath;
            }
        }

        private void BtnConvert_Click(object sender, EventArgs e)
        {
            txtResultsBox.Text += "Started conversion...\n\r\n";

            try
            {
                using (var sr = new StreamReader(txtYamlInputPath.Text))
                {
                    //var report = ParseAlignmentReport(sr);
                    var report = ParseAlignmentReportReal(txtYamlInputPath.Text);
                    

                    txtResultsBox.Text += "YAML file loaded and parsed.\n\r\n";
                    txtResultsBox.Text += $"Found {report.Groups.Count} groups and {report.Users.Count} users.\n\r\n";
                    txtResultsBox.Text += "Exporting to multiple files in output directory.\n\r\n";
                    ExportReport(report);
                }
            }
            catch (Exception exception)
            {
                txtResultsBox.Text += exception;

                txtResultsBox.Text +=
                    "Conversion error. Please report the messages listed above after removing any sensitive data.\n\r\n";
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


        /// <summary>
        /// Deserializes the alignment report into useful objects we can work with.
        /// </summary>
        /// <param name="alignmentReportYaml"></param>
        /// <returns>AlignmentReport containing all data from the YAML</returns>
        private static AlignmentReport ParseAlignmentReport(TextReader alignmentReportYaml)
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .WithTypeConverter(new LastAccessedTypeConverter())
                .Build();

            var report = deserializer.Deserialize<AlignmentReport>(alignmentReportYaml);

            return report;
        }

        private static AlignmentReport ParseAlignmentReportReal(string path)
        {
            DocumentStart documentStartEvent;
            var report = new AlignmentReport();

            using (var input = new StreamReader(path))
            {
                int iteration = 0; // Manually tracking this to map document to model
                var parser = new Parser(input);

                // Consume the stream start event "manually"
                parser.Consume<StreamStart>();

                // Parse each document in the stream
                while (parser.TryConsume(out documentStartEvent))
                {
                    // We expect a message header line document, but actual content in later documents.
                    if (parser.Current.GetType() == typeof(Scalar))
                    {
                        var deserializer = new DeserializerBuilder().Build();
                        var scalar = deserializer.Deserialize<string>(parser);
                        Console.WriteLine(scalar);
                        parser.MoveNext();
                        iteration += 1;
                        continue;
                    }

                    // Handle documents with content
                    switch (iteration)
                    {
                        case 1:
                            report.Groups = ParseGroups(parser);
                            Console.WriteLine($"Groups: {report.Groups.Count}");
                            break;
                        case 2:
                            report.Users = ParseUsers(parser);
                            Console.WriteLine($"Users: {report.Users.Count}");
                            break;
                        default:
                            Console.WriteLine("Unknown document.");
                            break;
                    }

                    parser.MoveNext();
                    iteration += 1;
                }
            }

            return report;
        }

        private static List<Group> ParseGroups(Parser parser)
        {
            var deserializer = new DeserializerBuilder().Build();
            var doc = deserializer.Deserialize<GroupsContainer>(parser);
            return doc.Groups.Values.ToList();
        }
        private static List<User> ParseUsers(Parser parser)
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .WithTypeConverter(new LastAccessedTypeConverter())
                .Build();
            var doc = deserializer.Deserialize<UsersContainer>(parser);

            return doc.Users.Values.ToList();
        }
    }
}