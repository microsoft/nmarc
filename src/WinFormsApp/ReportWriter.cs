// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using NMARC.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NMARC
{
    public class ReportWriter
    {
        public static void WriteGroupAdminsReport(AlignmentReport report, string basePath, string extension, string separator)
        {
            var groupAdminOutput = new StringBuilder();
            groupAdminOutput.AppendLine($"GroupID{separator}CreationRightsState{separator}Email");

            foreach (var group in report.Groups)
            {
                var admins = group.Administrators;

                if (!(admins is string))
                {
                    Console.WriteLine($@"Group:{group.Administrators}");
                    var convAdmins = (Dictionary<object, object>)admins;

                    foreach (KeyValuePair<object, object> entry in convAdmins)
                    {
                        var key = entry.Key as string;
                        var vals = (List<object>)entry.Value;

                        foreach (var adminEmail in vals)
                        {
                            var email = (string)adminEmail;
                            groupAdminOutput.AppendLine($"{group.Id}{separator}{key}{separator}{email}");
                        }
                    }
                }
                else
                {
                    groupAdminOutput.AppendLine($"{group.Id},,No Admins");
                }
            }

            Utilities.WriteFile($@"{basePath}\groupadmins{extension}", groupAdminOutput);
        }

        public static void WriteActiveCommunityGuestsReport(AlignmentReport report, string basePath, string extension, string separator)
        {
            var communityGuestOutput = new StringBuilder();
            communityGuestOutput.AppendLine($"GroupID{separator}Email");

            foreach (var group in report.Groups)
            {
                if (group.ActiveCommunityGuests != null)
                {
                    if (group.ActiveCommunityGuests.Count > 0)
                    {
                        foreach (var guest in group.ActiveCommunityGuests)
                        {
                            communityGuestOutput.AppendLine($"{group.Id}{separator}{guest}");
                        }
                    }
                }
            }

            Utilities.WriteFile($@"{basePath}\communityguests{extension}", communityGuestOutput);
        }

        public static void WriteOtherCommunityGuestsReport(AlignmentReport report, string basePath, string extension, string separator)
        {
            var communityGuestOutput = new StringBuilder();
            communityGuestOutput.AppendLine($"GroupID{separator}Email");

            foreach (var group in report.Groups)
            {
                if (group.OtherCommunityGuests != null)
                {
                    if (group.OtherCommunityGuests.Count > 0)
                    {
                        foreach (var guest in group.OtherCommunityGuests)
                        {
                            communityGuestOutput.AppendLine($"{group.Id}{separator}{guest}");
                        }
                    }
                }
            }

            Utilities.WriteFile($@"{basePath}\othercommunityguests{extension}", communityGuestOutput);
        }

        public static void WriteUsersReport(AlignmentReport report, string basePath, string extension, string separator)
        {
            // USERS
            var userOutput = new StringBuilder();
            userOutput.AppendLine(
                $"Email{separator}Internal{separator}State{separator}PrivateFileCount{separator}PublicMessageCount{separator}PrivateMessageCount{separator}LastAccessed{separator}AAD_State");

            foreach (var user in report.Users)
            {
                Console.WriteLine($"{user.Id}:{user.Email}");

                userOutput.AppendLine(user.GetCsv(separator));
            }

            Utilities.WriteFile($@"{basePath}\users{extension}", userOutput);
        }

        public static void WriteGroupsReport(AlignmentReport report, string basePath, string extension, string separator)
        {
            // GROUPS
            var groupOutput = new StringBuilder();

            groupOutput.AppendLine(
                $"Id{separator}Name{separator}Type{separator}PrivacySetting{separator}State{separator}MessageCount{separator}LastMessageDate{separator}ConnectedToO365{separator}Memberships.External{separator}Memberships.Internal{separator}Uploads.SharePoint{separator}Uploads.Yammer");
            foreach (var group in report.Groups)
            {
                Console.WriteLine($"{@group.Id}:{@group.Name}");

                groupOutput.AppendLine(@group.GetCsv(separator));
            }

            Utilities.WriteFile($@"{basePath}\groups{extension}", groupOutput);
        }
    }
}
