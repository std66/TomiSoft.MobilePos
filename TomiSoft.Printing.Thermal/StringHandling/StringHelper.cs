using System;
using System.Collections.Generic;
using System.Linq;

namespace TomiSoft.Printing.Thermal.StringHandling {
    internal static class StringHelper {
        internal static string AlignCenter(string input, int width) {
            if (input.Length > width)
                throw new ArgumentException($"The input string is longer than the maximum allowed width.");

            if (input.Length == width)
                return input;

            int padding = width / 2 - input.Length / 2;
            return new string(' ', padding) + input;
        }

        internal static IReadOnlyList<string> DivideToMultipleLines(string input, int width, char separator = ' ') {
            var words = input.Split(separator);
            return
                words
                    .Skip(1)
                    .Aggregate(
                        words.Take(1).ToList(),
                        (a, w) => {
                            var last = a.Last();
                            while (last.Length > width) {
                                a[a.Count() - 1] = last.Substring(0, width);
                                last = last.Substring(width);
                                a.Add(last);
                            }
                            var test = last + " " + w;
                            if (test.Length > width) {
                                a.Add(w);
                            }
                            else {
                                a[a.Count() - 1] = test;
                            }
                            return a;
                        });
        }
    }
}
