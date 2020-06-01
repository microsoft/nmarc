// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.IO;
using System.Text;
using YamlDotNet.Serialization;

namespace NMARC
{
    public class Utilities
    {
        /// <summary>
        /// Converts YAML to JSON format.
        /// </summary>
        /// <param name="yamlString">A TextReader containing YAML.</param>
        /// <returns>A string containing JSON.</returns>
        private static string ConvertYamlStringToJson(TextReader yamlString)
        {
            var deserializer = new DeserializerBuilder().Build();
            var yamlObject = deserializer.Deserialize(yamlString);

            var serializer = new SerializerBuilder()
                .JsonCompatible()
                .Build();

            var json = serializer.Serialize(yamlObject);
            return json;
        }

        /// <summary>
        /// Writes a string to a text file.
        /// </summary>
        /// <param name="path">Absolute file path to be written.</param>
        /// <param name="text">String containing text to write to the file.</param>
        public static void WriteFile(string path, StringBuilder text)
        {
            if (File.Exists(path))
            {
                throw new IOException("A file exists at {path}. Please select another output directory, or delete the exist file first.");
            }
            else
            {
                File.WriteAllText(path, text.ToString());
            }
        }
    }
}