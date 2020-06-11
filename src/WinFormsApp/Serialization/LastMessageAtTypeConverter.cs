// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using NMARC.Models;
using YamlDotNet.Core;
using YamlDotNet.Serialization;

namespace NMARC.Serialization
{
    /// <summary>
    /// Converter to help with last message posted dates. The last_date_accessed value is either a real date, or the
    /// value "never". The latter doesn't parse well by default, so you end up using object to represent it in
    /// a simple implementation. This type converter handles valid dates and sets DateTime.MinValue for any
    /// instances where it's not parseable.
    /// </summary>
    public class LastMessageAtTypeConverter : IYamlTypeConverter
    {
        private static readonly Type LastMessageAtNodeType = typeof(LastMessageAt);

        public bool Accepts(Type type)
        {
            return type == LastMessageAtNodeType;
        }

        public object ReadYaml(IParser parser, Type type)
        {
            // Set to MinValue explicitly - https://stackoverflow.com/a/305169/636.
            var result = new LastMessageAt() { Value = DateTime.MinValue };

            // Get the actual value out of the current location in the YAML
            var value = Utilities.GetScalarValue(parser);

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
    }
}
