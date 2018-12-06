namespace AoC {
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.IO;

    public class ChronalCoordinates {
        private static IEnumerable<Coord> UnitDirections = new[] { new Coord(0, 1), new Coord(1, 0), new Coord(0, -1), new Coord(-1, 0) };

        public static void Solve() {
            var input = File.ReadAllLines("AoC/Day6/input.txt");
            var groups = input.Select(s => s.Split(", ").Select(int.Parse).ToArray()).Select(a => new Coord(a[0], a[1]));
        }
    }

    public class Coord {
        public int X { get; }

        public int Y { get; }

        public Coord(int x, int y) {
            this.X = x;
            this.Y = y;
        }

        public int ManhattanDistance(Coord coord) {
            return Math.Abs(this.X - coord.X) + Math.Abs(this.Y - coord.Y);
        }

        public override bool Equals(object obj) {
            if (obj != null && obj is Coord c) {
                return this.X == c.X && this.Y == c.Y;
            }
            return base.Equals(obj);
        }

        public static Coord operator +(Coord c, Coord c1) {
            return new Coord(c.X + c1.X, c.Y + c1.Y);
        }
    }
}