// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using YamlDotNet.Serialization;

namespace NMARC.Models
{
    /// <summary>
    /// Represents a group returned in the Native Mode YAML.
    /// </summary>
    public class Group
    {
        [YamlMember(Alias = "name", ApplyNamingConventions = false)] public string Name { get; set; }
        [YamlMember(Alias = "id", ApplyNamingConventions = false)] public long Id { get; set; }

        [YamlMember(Alias = "type")] public string Type { get; set; }

        [YamlMember(Alias = "privacy_setting", ApplyNamingConventions = false)]
        public string PrivacySetting { get; set; }

        [YamlMember(Alias = "state", ApplyNamingConventions = false)]
        public string State { get; set; }

        [YamlMember(Alias = "approximate_messages_count", ApplyNamingConventions = false)]
        public long MessageCount { get; set; }

        [YamlMember(Alias = "last_message_at", ApplyNamingConventions = false)]
        public LastMessageAt LastMessageDate { get; set; }

        [YamlMember(Alias = "o365_connected", ApplyNamingConventions = false)]
        public bool ConnectedToO365 { get; set; }

        [YamlMember(Alias = "member_counts", ApplyNamingConventions = false)]
        public MemberCounts /*object*/ Memberships { get; set; } //null?

        [YamlMember(Alias = "uploaded_file_counts", ApplyNamingConventions = false)]
        public UploadCounts Uploads { get; set; }

        [YamlMember(Alias = "group_admins", ApplyNamingConventions = false)]
        public object Administrators { get; set; }

        /// <summary>
        /// Gets a representation of the group as a row of CSV
        /// </summary>
        /// <returns>String containing CSV.</returns>
        public string GetCsv()
        {
            return
                $@"{Id},{Name},{Type},{PrivacySetting},{State},{MessageCount},{LastMessageDate},{ConnectedToO365},{Administrators},{Memberships.External},{Memberships.Internal},{Uploads.SharePoint},{Uploads.Yammer}";
        }
    }
}
