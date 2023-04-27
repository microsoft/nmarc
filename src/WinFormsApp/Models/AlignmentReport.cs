// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using NativeModeReportViewer.Models;
using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace NMARC.Models
{
    /// <summary>
    /// Represents the complete alignment report returned in the Native Mode YAML.
    /// </summary>
    public class AlignmentReport
    {
        [YamlMember(Alias = "GROUPS", ApplyNamingConventions = false)]
        public List<Group> Groups { get; set; }

        [YamlMember(Alias = "USERS", ApplyNamingConventions = false)]
        public List<User> Users { get; set; }

        [YamlMember(Alias = ":GROUP_LEVEL_GUESTS", ApplyNamingConventions = false)]
        public List<Guest> GroupLevelGuests { get; set; }

    }
}
