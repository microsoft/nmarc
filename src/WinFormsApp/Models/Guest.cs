// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace NativeModeReportViewer.Models
{
    public class Guests
    {
        [YamlMember(Alias = ":GROUP_LEVEL_GUESTS", ApplyNamingConventions = false)]
        public Dictionary<string, Guest> GroupLevelGuests { get; set; }
    }
}
