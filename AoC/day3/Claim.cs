namespace AoC {
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
    public class Claim {
        private string info;

        public int Id { get; set; }
        public Claim(string init) {
            this.info = init;
            this.Id = int.Parse(init.Substring(1, init.IndexOf("@") - 2));
        }

        public IEnumerable<string> Coords => GetCoords();

        private IEnumerable<string> GetCoords() {
            var search = new Regex(@"@ (\d+,\d+): (\d+x\d+)");
            var matches = search.Match(this.info);
            var coords = matches.Groups[1].Value.Split(",").Select(int.Parse).ToArray();
            var x = coords[0];
            var y = coords[1];

            var dimensions = matches.Groups[2].Value.Split("x").Select(int.Parse).ToArray();
            var w = dimensions[0];
            var h = dimensions[1];
 
            return Enumerable.Range(0, w).Select(i => i + x).SelectMany(i => Enumerable.Range(0, h).Select(j => $"{i}:{j + y}"));
        }

        public static IEnumerable<Claim> FromFile() {
            return File.ReadAllLines("AoC/day3/input.txt").Select(l => new Claim(l));
        }

        public static void GetOverlaps() {
            var claims = Claim.FromFile();
            var claimCoords = new HashSet<string>();
            var overlaps = new HashSet<string>();
            foreach (var claim in claims) {
                foreach (var coord in claim.Coords) {
                    if (!claimCoords.Contains(coord)) {
                        claimCoords.Add(coord);
                        continue;
                    }

                    if (!overlaps.Contains(coord)) {
                        overlaps.Add(coord);
                    }

                }
            }

            Console.WriteLine($"Overlaps: {overlaps.Count}");
        }
    }
}
