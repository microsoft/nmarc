// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;

namespace NMARC.Models
{
    public class LastAccessed
    {
        public DateTime Value { get; set; }

        public override string ToString()
        {
            if (Value == DateTime.MinValue)
            {
                return "Never";
            }

            return Value.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK");
        }
    }
}