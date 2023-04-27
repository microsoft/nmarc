// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace NMARC.Models
{
    //TODO: fix this
    public class GroupLevelGuest
    {
        [YamlMember(Alias = "name", ApplyNamingConventions = false)] public string Name { get; set; }
        [YamlMember(Alias = "id", ApplyNamingConventions = false)] public long Id { get; set; }
        [YamlMember(Alias = "id", ApplyNamingConventions = false)] public List<long> approved_in_groups { get; set; }
        [YamlMember(Alias = "id", ApplyNamingConventions = false)] public List<long> pending_in_groups { get; set; }
        [YamlMember(Alias = "id", ApplyNamingConventions = false)] public List<long> invited_in_groups { get; set; }
    }
}
