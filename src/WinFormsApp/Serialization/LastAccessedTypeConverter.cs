// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using System.IO;
using NMARC.Models;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace NMARC.Serialization
{
    /// <summary>
    /// Converter to help with last accessed dates. The last_date_accessed value is either a real date, or the
    /// value "never". The latter doesn't parse well by default, so you end up using object to represent it in
    /// a simple implementation. This type converter handles valid dates and sets DateTime.MinValue for any
    /// instances where it's not parseable.
    /// </summary>
    public class LastAccessedTypeConverter : IYamlTypeConverter
    {
        private static readonly Type LastAccessedNodeType = typeof(LastAccessed);

        public bool Accepts(Type type)
        {
            return type == LastAccessedNodeType;
        }

        public object ReadYaml(IParser parser, Type type)
        {
            // Set to MinValue explicitly - https://stackoverflow.com/a/305169/636.
            var result = new LastAccessed() {Value = DateTime.MinValue};

            // Get the actual value out of the current location in the YAML
            var value = this.GetScalarValue(parser);

            // Put it in our custom type.
            var dateParsed = DateTime.TryParse(value, out var parsedDateValue);

            if (dateParsed)
            {
                result.Value = parsedDateValue;
            }

            // We need to advance to the next event, or the parser gets out of sync!
            parser.MoveNext();

            Console.WriteLine(result);

            return result;
        }

        public void WriteYaml(IEmitter emitter, object value, Type type)
        {
            throw new NotImplementedException();
        }

        private string GetScalarValue(IParser parser)
        {
            Scalar scalar;
            scalar = parser.Current as Scalar;

            if (scalar == null)
            {
                throw new InvalidDataException("Failed to retrieve scalar value.");
            }

            return scalar.Value;
        }
    }
}