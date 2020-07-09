// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NMARC.Models;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace NMARC.Serialization
{
    public class AlignmentReportParser
    {
        /// <summary>
        /// Deserializes the alignment report into useful objects we can work with.
        /// </summary>
        /// <param name="path">Path to file containing YAML</param>
        /// <returns>AlignmentReport containing all data from the YAML</returns>
        public static AlignmentReport ParseAlignmentReport(string path)
        {
            DocumentStart documentStartEvent;
            var report = new AlignmentReport();

            using (var input = new StreamReader(path))
            {
                int iteration = 0; // Manually tracking this to map document to model
                var parser = new Parser(input);

                // Consume the stream start event "manually"
                parser.Consume<StreamStart>();

                // Parse each document in the stream
                while (parser.TryConsume(out documentStartEvent))
                {
                    // We expect a message header line document, but actual content in later documents.
                    if (parser.Current.GetType() == typeof(Scalar))
                    {
                        var deserializer = new DeserializerBuilder().Build();
                        var scalar = deserializer.Deserialize<string>(parser);
                        Console.WriteLine(scalar);
                        parser.MoveNext();
                        iteration += 1;
                        continue;
                    }

                    // Handle documents with content
                    switch (iteration)
                    {
                        case 1:
                            report.Groups = ParseGroups(parser);
                            Console.WriteLine($"Groups: {report.Groups.Count}");
                            break;
                        case 2:
                            report.Users = ParseUsers(parser);
                            Console.WriteLine($"Users: {report.Users.Count}");
                            break;
                        case 3:
                            report.GroupLevelGuests = ParseGuests(parser);
                            Console.WriteLine($"Group Level Guests: {report.GroupLevelGuests.Count}");
                            break;
                        default:
                            Console.WriteLine("Unknown document type.");
                            break;
                    }

                    parser.MoveNext();
                    iteration += 1;
                }
            }

            return report;
        }

        public static List<Group> ParseGroups(Parser parser)
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .WithTypeConverter(new LastMessageAtTypeConverter())
                .IgnoreUnmatchedProperties()
                .Build();

            var doc = deserializer.Deserialize<GroupsContainer>(parser);

            return doc.Groups.Values.ToList();
        }

        public static List<User> ParseUsers(Parser parser)
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .WithTypeConverter(new LastAccessedTypeConverter())
                .IgnoreUnmatchedProperties()
                .Build();

            var doc = deserializer.Deserialize<UsersContainer>(parser);

            return doc.Users.Values.ToList();
        }

        public static List<GroupLevelGuest> ParseGuests(Parser parser)
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .WithTypeConverter(new LastAccessedTypeConverter())
                .IgnoreUnmatchedProperties()
                .Build();

            var doc = deserializer.Deserialize<GroupLevelGuestContainer>(parser);

            return doc.GroupLevelGuests.Values.ToList();
        }
    }
}
