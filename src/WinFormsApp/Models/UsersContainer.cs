// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace NMARC.Models
{
    public class UsersContainer
    {
        [YamlMember(Alias = "USERS", ApplyNamingConventions = false)]
        public Dictionary<long, User> Users { get; set; }
    }
}
