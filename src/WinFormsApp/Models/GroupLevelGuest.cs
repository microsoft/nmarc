// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace NMARC.Models
{
    public class GroupLevelGuest
    {
        [YamlMember(Alias = "name", ApplyNamingConventions = false)] public string Name { get; set; }
        [YamlMember(Alias = "id", ApplyNamingConventions = false)] public long Id { get; set; }
    }
}
