// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using YamlDotNet.Serialization;

namespace NMARC.Models
{
    /// <summary>
    /// Represents membership counts for internal and external groups returned in the Native Mode YAML.
    /// </summary>
    public class MemberCounts
    {
        [YamlMember(Alias = "internal", ApplyNamingConventions = false)]
        public long Internal { get; set; }

        [YamlMember(Alias = "external", ApplyNamingConventions = false)]
        public long External { get; set; }
    }
}