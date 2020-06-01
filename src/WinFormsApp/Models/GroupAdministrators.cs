// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace NMARC.Models
{
    public class GroupAdministrators
    {
        public string Message { get; set; }

        [YamlMember(Alias = "with_o365_creation_rights", ApplyNamingConventions = false)]
        public List<string> WithCreationRights { get; set; }

        [YamlMember(Alias = "without_o365_creation_rights", ApplyNamingConventions = false)]
        public List<string> WithoutCreationRights { get; set; }

        public override string ToString()
        {
            return "Need to work out how to format these for CSV.";
        }
    }
}