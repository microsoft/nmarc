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
        public AlignmentReport Report { get; }
        public string BasePath { get; }
        public string Extension { get; }
        public string Separator { get; }

        public ReportWriter(AlignmentReport report, string basePath, string extension, string separator)
        {
            Report = report;
            BasePath = basePath;
            Extension = extension;
            Separator = separator;
        }

        public void WriteGroupAdminsReport()
        {
            var groupAdminOutput = new StringBuilder();
            groupAdminOutput.AppendLine($"GroupID{Separator}CreationRightsState{Separator}Email");

            foreach (var group in Report.Groups)
            {
                var admins = group.Administrators;

                if (!(admins is string))
                {
                    var convAdmins = (Dictionary<object, object>)admins;

                    foreach (KeyValuePair<object, object> entry in convAdmins)
                    {
                        var key = entry.Key as string;
                        var vals = (List<object>)entry.Value;

                        foreach (var adminEmail in vals)
                        {
                            var email = (string)adminEmail;
                            groupAdminOutput.AppendLine($"{group.Id}{Separator}{key}{Separator}{email}");
                        }
                    }
                }
                else
                {
                    groupAdminOutput.AppendLine($"{group.Id},,No Admins");
                }
            }

            Utilities.WriteFile($@"{BasePath}\groupadmins{Extension}", groupAdminOutput);
        }

        public void WriteActiveCommunityGuestsReport()
        {
            var communityGuestOutput = new StringBuilder();
            communityGuestOutput.AppendLine($"GroupID{Separator}Email");

            foreach (var group in Report.Groups)
            {
                if (group.ActiveCommunityGuests != null)
                {
                    if (group.ActiveCommunityGuests.Count > 0)
                    {
                        foreach (var guest in group.ActiveCommunityGuests)
                        {
                            communityGuestOutput.AppendLine($"{group.Id}{Separator}{guest}");
                        }
                    }
                }
            }

            Utilities.WriteFile($@"{BasePath}\communityguests{Extension}", communityGuestOutput);
        }

        public void WriteOtherCommunityGuestsReport()
        {
            var communityGuestOutput = new StringBuilder();
            communityGuestOutput.AppendLine($"GroupID{Separator}Email");

            foreach (var group in Report.Groups)
            {
                if (group.OtherCommunityGuests != null)
                {
                    if (group.OtherCommunityGuests.Count > 0)
                    {
                        foreach (var guest in group.OtherCommunityGuests)
                        {
                            communityGuestOutput.AppendLine($"{group.Id}{Separator}{guest}");
                        }
                    }
                }
            }

            Utilities.WriteFile($@"{BasePath}\othercommunityguests{Extension}", communityGuestOutput);
        }

        public void WriteUsersReport()
        {
            // USERS
            var userOutput = new StringBuilder();
            userOutput.AppendLine(
                $"Email{Separator}Internal{Separator}State{Separator}PrivateFileCount{Separator}PublicMessageCount{Separator}PrivateMessageCount{Separator}LastAccessed{Separator}AAD_State");

            foreach (var user in Report.Users)
            {
                userOutput.AppendLine(FormatUserLine(user, Separator));
            }

            Utilities.WriteFile($@"{BasePath}\users{Extension}", userOutput);
        }

        public void WriteGroupsReport()
        {
            // GROUPS
            var groupOutput = new StringBuilder();

            groupOutput.AppendLine(
                $"Id{Separator}Name{Separator}Type{Separator}PrivacySetting{Separator}State{Separator}MessageCount{Separator}LastMessageDate{Separator}ConnectedToO365{Separator}Memberships.External{Separator}Memberships.Internal{Separator}Uploads.SharePoint{Separator}Uploads.Yammer");
            
            foreach (var group in Report.Groups)
            {
                groupOutput.AppendLine(FormatGroupLine(@group, Separator));
            }

            Utilities.WriteFile($@"{BasePath}\groups{Extension}", groupOutput);
        }

        /// <summary>
        /// Gets a representation of the user as a row of CSV
        /// </summary>
        /// <returns>String containing CSV.</returns>
        public string FormatUserLine(User user, string separator)
        {
            return
                $@"{user.Email}{separator}{user.Internal}{separator}{user.State}{separator}{user.PrivateFileCount}{separator}{user.PublicMessageCount}{separator}{user.PrivateMessageCount}{separator}{user.LastAccessed}{separator}{user.AzureADState}";
        }

        /// <summary>
        /// Gets a representation of the group as a row of CSV
        /// </summary>
        /// <returns>String containing CSV.</returns>
        public string FormatGroupLine(Group group, string separator)
        {
            return
                $@"{group.Id}{separator}{group.Name}{separator}{group.Type}{separator}{group.PrivacySetting}{separator}{group.State}{separator}{group.MessageCount}{separator}{group.LastMessageDate}{separator}{group.ConnectedToO365}{separator}{group.Memberships.External}{separator}{group.Memberships.Internal}{separator}{group.Uploads.SharePoint}{separator}{group.Uploads.Yammer}";
        }
    }
}
