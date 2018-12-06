namespace AoC {
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.IO;

    public class ChronalCoordinates {
        public Coord origin { get; private set; }
        public int Id { get; }

        private static int id = 0;

        public ChronalCoordinates(Coord origin) {
            this.origin = origin;
            this.Id = id++;
        }

        private static int[][] GenerateBoard(IEnumerable<ChronalCoordinates> groups, int offset = 0) {
            var xMax = groups.Select(c => c.origin.X).Max();
            var yMax = groups.Select(c => c.origin.Y).Max();
            var board = new int[yMax + 2 * offset][];
            for (var i = 0; i < xMax; i++) {
                board[i] = new int[xMax + 2 * offset];
            }
            foreach (var group in groups) {
                board[group.origin.Y + offset][group.origin.X + offset] = group.Id;
            }
            
            for (var i = 0; i < board.Length; i++) {
                for (var j = 0; j < board[0].Length; j++) {
                    MarkWithNearestId(board, i, j);
                }
            }

            return board;
        }
        private static void MarkWithNearestId(int[][] board, int i, int j) {
            var here = new Coord(j, i);
            var spread = new[] {here};
            while (spread.All(c => GetValueAt(board, c) == 0)) {
                spread = spread.SelectMany(c => UnitDirections.Select(c1 => c1 + c)).Distinct().ToArray();
                var nonEmpty = spread.Where(c => GetValueAt(board, c) != 0);
                if (nonEmpty.Any()) {
                    
                }
            }
        }


        private static IEnumerable<Coord> UnitDirections = new[] { new Coord(0, 1), new Coord(1, 0), new Coord(0, -1), new Coord(-1, 0) };

        private static int GetValueAt(int[][] board, Coord c) {
            var yMax = board.Length;
            var xMax = board[0].Length;

            if (c.Y < 0 || c.Y >= yMax || c.X < 0 || c.X >= xMax) return 0;
            else return board[c.Y][c.X];
        }
        public static void Solve() {
            var input = File.ReadAllLines("AoC/Day6/input.txt");
            var groups = input.Select(s => s.Split(", ").Select(int.Parse).ToArray()).Select(a => new ChronalCoordinates(new Coord(a[0], a[1])));
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