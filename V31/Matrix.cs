using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
// ReSharper disable All

namespace V31
{
    public class Matrix
    {
        public Cel[][] Rooster { get; set; }

        public void DisplayMatrix()
        {
            for (int i = 0; i < Rooster.Length; i++)
            {
                for (int j = 0; j < Rooster.Length; j++)
                {
                    Rooster[i][j].DisplayCell();
                    Console.Write(" | ");
                }
                Console.WriteLine();
            }
        }

        public List<string> NavigateMatrix(Tuple<int, int> startPosition, int depth)
        {

            var startCel = Rooster[startPosition.Item1][startPosition.Item2];
            return NavigateFrom(startCel, depth);

        }

        private List<string> NavigateFrom(Cel startCel, in int depth)
        {
            var listAndstring = new LijstAndString()
            {
                VisitedCellen = new List<Cel>()
                {
                    startCel
                },
                ResultString = startCel.Letter
            };
            var resultList = new List<LijstAndString>();

            resultList.AddRange(Navigate(listAndstring, depth));

            return resultList.Select(x => x.ResultString).ToList();
        }

        public class LijstAndString
        {
            public List<Cel> VisitedCellen { get; set; }
            public string ResultString { get; set; }
        }

        private List<LijstAndString> Navigate(LijstAndString lijstAndstring, in int depth)
        {
            var resultStrings = new List<LijstAndString>();
            var cells = GetAllPossibleCellsForCel(lijstAndstring);
            var depthCopy = depth;
            if (--depthCopy > 0)
            {
                foreach (var cell in cells)
                {
                    lijstAndstring.ResultString += cell.Letter;
                    lijstAndstring.VisitedCellen.Add(cell);
                    var nextCells = Navigate(lijstAndstring, depthCopy);
                    resultStrings.AddRange(nextCells);
                }
            }
            else
            {
                foreach (var cell in cells)
                {
                    lijstAndstring.ResultString += cell.Letter;
                    resultStrings.Add(lijstAndstring);
                }
            }

            return resultStrings;
        }

        private IList<Cel> GetAllPossibleCellsForCel(LijstAndString lijstEnString)
        {
            switch (lijstEnString.VisitedCellen.LastOrDefault().Direction)
            {
                case Direction.B:
                    return NagiveerVoorCell(lijstEnString, null, true);
                case Direction.RB:
                    return NagiveerVoorCell(lijstEnString, true, true);
                case Direction.R:
                    return NagiveerVoorCell(lijstEnString, true, null);
                case Direction.RO:
                    return NagiveerVoorCell(lijstEnString, true, false);
                case Direction.O:
                    return NagiveerVoorCell(lijstEnString, null, false);
                case Direction.LO:
                    return NagiveerVoorCell(lijstEnString, false, false);
                case Direction.L:
                    return NagiveerVoorCell(lijstEnString, false, null);
                case Direction.LB:
                    return NagiveerVoorCell(lijstEnString, false, true);
            }
            return new List<Cel>();
        }

        private IList<Cel> NagiveerVoorCell(LijstAndString lijst, bool? isRechts, bool? isUp)
        {
            var startCel = lijst.VisitedCellen.LastOrDefault();

            var minKolom = 0;
            var minRij = 0;

            var kolom = startCel.Kolom;
            var rij = startCel.Rij;

            var maxKolom = Rooster[0].Length;
            var maxRij = Rooster.Length;

            List<Cel> retCells = new List<Cel>();

            if (isRechts.HasValue)
            {
                if (isUp.HasValue)
                {
                    if (isRechts.Value)
                    {
                        if (isUp.Value)
                        {
                            //rechtsboven
                            var count = Math.Min(maxKolom - kolom, rij);
                            var currentRij = rij;
                            var currentKolom = kolom;
                            for (int q = 0; q < count - 1; q++)
                            {
                                retCells.Add(Rooster[--currentRij][++currentKolom]);
                            }
                        }
                        else
                        {
                            //rechtsonder
                            var count = Math.Min(maxKolom - kolom, maxRij - rij);
                            var currentRij = rij;
                            var currentKolom = kolom;
                            for (int q = 0; q < count - 1; q++)
                            {
                                retCells.Add(Rooster[++currentRij][++currentKolom]);
                            }
                        }
                    }
                    else
                    {
                        if (isUp.Value)
                        {
                            //linksboven
                            var count = Math.Min(kolom, rij);
                            var currentRij = rij;
                            var currentKolom = kolom;
                            for (int q = 0; q < count; q++)
                            {
                                retCells.Add(Rooster[--currentRij][--currentKolom]);
                            }
                        }
                        else
                        {
                            // linksonder
                            var count = Math.Min(kolom, maxRij - rij);
                            var currentRij = rij;
                            var currentKolom = kolom;
                            for (int q = 0; q < count - 1; q++)
                            {
                                retCells.Add(Rooster[++currentRij][--currentKolom]);
                            }
                        }
                    }
                }
                else
                {
                    if (isRechts.Value)
                    {
                        // naar rechts zoeken
                        for (int q = kolom + 1; q < maxKolom; q++)
                        {
                            retCells.Add(Rooster[rij][q]);
                        }
                    }
                    else
                    {
                        // naar links zoeken
                        for (int q = kolom; q > minKolom; q--)
                        {
                            retCells.Add(Rooster[rij][q]);
                        }
                    }
                }
            }
            else
            {
                if (isUp.Value)
                {
                    // naar boven
                    for (int q = rij; q > minRij; q--)
                    {
                        retCells.Add(Rooster[q][kolom]);
                    }
                }
                else
                {
                    // naar onder
                    for (int q = rij + 1; q < maxRij; q++)
                    {
                        retCells.Add(Rooster[q][kolom]);
                    }
                }
            }

            return retCells.AsEnumerable().Where(x => !lijst.VisitedCellen.Contains(x)).ToList();
        }

        public void AssignPositionsToCells()
        {
            for (int i = 0; i < Rooster.Length; i++)
            {
                for (int j = 0; j < Rooster[i].Length; j++)
                {
                    Rooster[i][j].Kolom = j;
                    Rooster[i][j].Rij = i;
                }
            }
        }
    }

    public class Cel
    {
        public Cel(string letter, Direction direction)
        {
            Letter = letter;
            Direction = direction;
            HasBeenVisited = false;
        }
        public string Letter { get; set; }
        public Direction Direction { get; set; }
        public int Kolom { get; set; }
        public int Rij { get; set; }
        public bool HasBeenVisited { get; set; }

        public void DisplayCell()
        {
            Console.Write($"{Letter} ({Direction})\t");
        }
    }

    public enum Direction
    {
        B = 0,
        RB = 1,
        R = 2,
        RO = 3,
        O = 4,
        LO = 5,
        L = 6,
        LB = 7
    }
}
