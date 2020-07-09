// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace NMARC.Models
{
    public class GroupLevelGuestContainer
    {
        [YamlMember(Alias = "GROUP_LEVEL_GUESTS", ApplyNamingConventions = false)]
        public Dictionary<string, GroupLevelGuest> GroupLevelGuests { get; set; }
    }
}
