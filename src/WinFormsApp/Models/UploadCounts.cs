// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using YamlDotNet.Serialization;

namespace NMARC.Models
{
    /// <summary>
    /// Represents user upload counts for Yammer and SPO files returned in the Native Mode YAML.
    /// </summary>
    public class UploadCounts
    {
        [YamlMember(Alias = "yammer_files", ApplyNamingConventions = false)]
        public long Yammer { get; set; }

        [YamlMember(Alias = "sharepoint_files", ApplyNamingConventions = false)]
        public long SharePoint { get; set; }
    }
}