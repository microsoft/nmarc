// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace NMARC.Models
{
    public class GroupsContainer
    {
        [YamlMember(Alias = ":GROUPS", ApplyNamingConventions = false)]
        public Dictionary<long, Group> Groups { get; set; }
    }
}
