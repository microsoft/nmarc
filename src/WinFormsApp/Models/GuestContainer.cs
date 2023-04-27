// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using YamlDotNet.Serialization;

namespace NativeModeReportViewer.Models
{
    public class Guest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        [YamlMember(Alias = "approved_in_groups", ApplyNamingConventions = false)]
        public long[] ApprovedInGroups { get; set; } = Array.Empty<long>();
        [YamlMember(Alias = "pending_in_groups", ApplyNamingConventions = false)]
        public long[] PendingInGroups { get; set; } = Array.Empty<long>();
        [YamlMember(Alias = "invited_in_groups", ApplyNamingConventions = false)]
        public long[] InvitedInGroups { get; set; } = Array.Empty<long>();
    }
}
