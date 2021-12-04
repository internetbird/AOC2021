using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2021.Utility
{
    public static class MatrixExtensions
    {
        public static T[] GetRow<T>(this T[,] matrix, int rowIndex)
        {
            return Enumerable.Range(0, matrix.GetLength(1))
              .Select(columnIndex => matrix[rowIndex, columnIndex])
              .ToArray();

        }

        public static T[] GetColumn<T>(this T[,] matrix, int columnIndex)
        {
            return Enumerable.Range(0, matrix.GetLength(0))
              .Select(rowIndex => matrix[rowIndex, columnIndex])
              .ToArray();

        }


    }
}
