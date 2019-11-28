using System;

namespace V31
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = InputStatic.MatrixA();

            var inputTuple = new Tuple<int, int>(2, 2);

            var res = matrix.NavigateMatrix(inputTuple, 5);
            Console.ReadKey();
        }
    }
}
