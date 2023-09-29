using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFieldCSharp
{
    internal class Matrix
    {
        private decimal[][] _matrix;
        public int Rows { get => _matrix.Length; }
        public int Columns { get => _matrix[0].Length; }
        public int SmallestDimension { get => Rows > Columns ? Rows : Columns; }
        public bool IsSquare { get => Rows == Columns; }
        public bool HasInverse { get => DeterminantLarge() != 0; }

        public decimal this[int row, int column]
        {
            get => _matrix[row][column];
            set => _matrix[row][column] = value;
        }

        public static implicit operator string(Matrix m) { return m.ToString(); }

        // Constructors

        public Matrix()
        {
            _matrix = Array.Empty<decimal[]>();
            _matrix[0] = Array.Empty<decimal>();
        }

        public Matrix(int rows, int columns)
        {
            _matrix = new decimal[rows][];
            for (int row = 0; row < rows; row++)
            {
                _matrix[row] = new decimal[columns];
            }
        }

        public Matrix(Matrix matrix)
        {
            _matrix = matrix._matrix;
        }

        public Matrix(int rows, int columns, Tuple<int, int> range)
        {
            _matrix = GenerateRandomMatrix(rows, columns, range)._matrix;
        }

        public Matrix(decimal[][] array)
        {
            _matrix = array;
        }

        public Matrix(decimal[,] array)
        {
            _matrix = new decimal[array.GetLength(0)][];
            for (int row = 0; row < array.GetLength(0); row++)
            {
                _matrix[row] = new decimal[array.GetLength(1)];
                for (int column = 0; column < array.GetLength(1); column++)
                {
                    _matrix[row][column] = array[row, column];
                }
            }
        }

        // Data access and management

        public decimal Get(int row, int column)
        {
            return this[row, column];
        }

        public void Set(int row, int column, int value)
        {
            this[row, column] = value;
        }

        public void SetMatrix(decimal[][] newMatrix)
        {
            _matrix = newMatrix;
        }

        // Validation checks

        public bool IsMultipliable(Matrix matrix)
        {
            return Columns == matrix.Rows;
        }

        public bool IsAddable(Matrix matrix)
        {
            return Columns == matrix.Columns && Rows == matrix.Rows;
        }

        public bool RowBounds(int row)
        {
            return row >= 0 && row < Rows;
        }

        public bool ColumnBounds(int column)
        {
            return column >= 0 && column < Rows;
        }

        // Matrix math

        public Matrix ScalarMultiplication(decimal value)
        {
            Matrix newMatrix = new(Rows, Columns);

            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    newMatrix[row, column] = this[row, column] * value;
                }
            }

            return newMatrix;
        }

        public Matrix Multiplication(Matrix multiplier)
        {
            if (!IsMultipliable(multiplier)) return new();

            Matrix newMatrix = new(Rows, multiplier.Columns);
            decimal sum = 0;

            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < multiplier.Columns; column++)
                {
                    for (int current = 0; current < Columns; current++)
                    {
                        sum += this[row, current] * multiplier[current, column];
                    }
                    newMatrix[row, column] = sum;
                    sum = 0;
                }
            }
            return newMatrix;
        }

        public Matrix Addition(Matrix additive)
        {
            if (!IsAddable(additive)) return new();

            Matrix newMatrix = new(Rows, Columns);

            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    newMatrix[row, column] = this[row, column] + additive[row, column];
                }
            }
            return newMatrix;
        }

        // Matrix operations

        public Matrix InterchangeRows(int row1, int row2)
        {
            Matrix newMatrix = new(_matrix);

            if ((row1 >= 0 && row1 < Rows) || (row2 >= 0 && row2 < Rows))
            {
                (_matrix[row2], _matrix[row1]) = (_matrix[row1], _matrix[row2]);
            }

            return newMatrix;
        }

        public Matrix MultiplyRowElements(int row, int value)
        {
            Matrix newMatrix = new(_matrix);

            if (value != 0 && RowBounds(row))
            {
                for (int column = 0; column < Columns; column++)
                {
                    newMatrix[row, column] *= value;
                }
            }

            return newMatrix;
        }

        public Matrix AddMultipleOfRow(int row1, int row2, int value)
        {
            Matrix newMatrix = new(_matrix);

            if ((RowBounds(row1) && RowBounds(row2)))
            {
                for (int column = 0; column < Columns; column++)
                {
                    newMatrix[row2, column] -= this[row1, column] * value;
                }
            }

            return newMatrix;
        }

        public Matrix GetSub2x2(int row, int column)
        {
            Matrix m = new(2, 2);
            m[0, 0] = this[row, column];
            m[0, 1] = this[row, column + 1];
            m[1, 0] = this[row + 1, column];
            m[1, 1] = this[row + 1, column + 1];

            return m;
        }

        public decimal SumOfAll()
        {
            decimal sum = 0;

            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    sum += this[row, column];
                }
            }

            return sum;
        }

        public Matrix Transpose()
        {
            Matrix newMatrix = new(Columns, Rows);

            for (int row = 0; row < Columns; row++)
            {
                for (int column = 0; column < Rows; column++)
                {
                    newMatrix[row, column] = this[column, row];
                }
            }

            return newMatrix;
        }

        public Matrix GetMatrixMinor(int rowSkip, int columnSkip)
        {
            Matrix newMatrix = new(Rows - 1, Columns - 1);

            for (int row = 0, rowMinor = 0; row < Rows; row++)
            {
                if (row != rowSkip)
                {
                    for (int column = 0, columnMinor = 0; column < Columns; column++)
                    {
                        if (column != columnSkip)
                        {
                            newMatrix[rowMinor, columnMinor++] = this[row, column];
                        }
                    }
                    rowMinor++;
                }
            }

            return newMatrix;
        }

        public decimal Determinant2x2()
        {
            return (this[0, 0] * this[1, 1]) - (this[0, 1] * this[1, 0]);
        }

        public decimal DeterminantLarge()
        {
            if (SmallestDimension == 2) return Determinant2x2();
            decimal value;
            List<decimal> list = new();

            if (SmallestDimension == 3)
            {
                for (int column = 0; column < Columns; column++)
                {
                    list.Add(this[0, column] * CheckboardSign(0, column) * GetMatrixMinor(0, column).Determinant2x2());
                }
            }
            else
            {
                for (int column = 0; column < Columns; column++)
                {
                    list.Add(this[0, column] * CheckboardSign(0, column) * GetMatrixMinor(0, column).DeterminantLarge());
                }
            }
            value = list[0];
            list.RemoveAt(0);

            foreach (decimal item in list)
            {
                value += item;
            }

            return value;

            //if (SmallestDimension < 3 || !IsSquare) return 0;

            //decimal value;
            //List<decimal> list = new();

            //for (int column = 0; column < Columns; column++)
            //{
            //    list.Add(this[0, column] * CheckboardSign(0, column) * GetMatrixMinor(0, column).Determinant2x2());
            //}

            //value = list[0];
            //list.RemoveAt(0);

            //foreach (decimal item in list)
            //{
            //    value += item;
            //}

            //return value;
        }

        public Matrix MatrixOfDeterminants()
        {
            Matrix newMatrix = new(Rows, Columns);

            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    newMatrix[row, column] = GetMatrixMinor(row, column).DeterminantLarge();
                }

            }

            return newMatrix;
        }

        public static decimal CheckboardSign(int row, int column)
        {
            return (row % 2 != 0! ^ column % 2 != 0) ? -1 : 1;
        }

        public Matrix CheckboardSignInversion()
        {
            Matrix newMatrix = new(_matrix);

            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    if (row % 2 != 0! ^ column % 2 != 0)
                    {
                        newMatrix[row, column] *= -1;
                    }
                }
            }

            return newMatrix;
        }

        public Matrix InverseMatrix()
        {
            if (DeterminantLarge() != 0)
            {
                return Transpose().MatrixOfDeterminants().CheckboardSignInversion().ScalarMultiplication(1m / DeterminantLarge());
            }
            return new(0, 0);
        }

        // String conversion utility

        public decimal FindGreatest()
        {
            decimal greatest = 0;

            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    greatest = this[row, column] > greatest ? this[row, column] : greatest;
                }
            }

            return greatest;
        }

        private int FindSpacing()
        {
            decimal greatest = 0;
            int hasNegative = 0;

            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    greatest = this[row, column] > greatest ? this[row, column] : greatest;
                    if (this[row, column] < 0) hasNegative = 1;
                }
            }

            return RandomUtilities.GetIntLength(greatest) + hasNegative;
        }

        public override string ToString()
        {
            StringBuilder output = new();
            int size = FindSpacing();

            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    output.Append(RandomUtilities.SpaceFormatting(Math.Round(this[row, column], 10).ToString(), size) + " ");
                }
                output.Append('\n');
            }

            return output.ToString();
        }

        // Other

        public static Matrix GenerateRandomMatrix(int rows, int columns, Tuple<int, int> range)
        {
            Matrix newMatrix = new(rows, columns);
            Random random = new();

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    newMatrix[row, column] = random.Next(range.Item1, range.Item2);
                }
            }

            return newMatrix;
        }

        public static Matrix GenerateNeutral(int dimension)
        {
            Matrix matrix = new(dimension, dimension);

            for (int row = 0; row < dimension; row++)
            {
                for (int column = 0; column < dimension; column++)
                {
                    matrix[row, column] = row == column ? 1 : 0;
                }
            }

            return matrix;
        }
    }
}
