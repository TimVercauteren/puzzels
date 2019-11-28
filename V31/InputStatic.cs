using System;
using System.Collections.Generic;
using System.Text;

namespace V31
{
    public class InputStatic
    {
        public static Matrix MatrixA()
        {
            var retVal = new Matrix();


            retVal.Rooster = new Cel[][]
            {

                new Cel[]
                {
                    new Cel("D", Direction.RO),
                    new Cel("N", Direction.L),
                    new Cel("T", Direction.R),
                    new Cel("W", Direction.O),
                    new Cel("K", Direction.LO),
                    new Cel("L", Direction.LO),
                },
                new Cel[]
                {
                    new Cel("E", Direction.RB),
                    new Cel("E", Direction.O),
                    new Cel("G", Direction.R),
                    new Cel("K", Direction.R),
                    new Cel("W", Direction.R),
                    new Cel("I", Direction.LO),
                },
                new Cel[]
                {
                    new Cel("K", Direction.R),
                    new Cel("D", Direction.RO),
                    new Cel("R", Direction.LB),
                    new Cel("E", Direction.LB),
                    new Cel("N", Direction.L),
                    new Cel("S", Direction.L),
                },
                new Cel[]
                {
                    new Cel("N", Direction.B),
                    new Cel("C", Direction.R),
                    new Cel("H", Direction.R),
                    new Cel("E", Direction.B),
                    new Cel("S", Direction.LO),
                    new Cel("T", Direction.L),
                },
                new Cel[]
                {
                    new Cel("B", Direction.B),
                    new Cel("O", Direction.R),
                    new Cel("J", Direction.B),
                    new Cel("B", Direction.L),
                    new Cel("I", Direction.B),
                    new Cel("V", Direction.O),
                },
                new Cel[]
                {
                    new Cel("I", Direction.B),
                    new Cel("O", Direction.RB),
                    new Cel("N", Direction.L),
                    new Cel("R", Direction.RB),
                    new Cel("E", Direction.L),
                    new Cel("E", Direction.L),
                },
            };

            retVal.AssignPositionsToCells();

            return retVal;
        }
    }
}
