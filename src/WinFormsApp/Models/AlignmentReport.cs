// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace NMARC.Models
{
    /// <summary>
    /// Represents the complete alignment report returned in the Native Mode YAML.
    /// </summary>
    public class AlignmentReport
    {
        [YamlMember(Alias = "groups")]
        public Dictionary<long, Group> Groups { get; set; }
        [YamlMember(Alias = "users")]
        public Dictionary<long, User> Users { get; set; }
    }
}
