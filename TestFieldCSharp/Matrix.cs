using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFieldCSharp
{
    internal class Matrix
    {
        private int[][] _matrix;
        public int Rows { get => _matrix.Length; }
        public int Columns { get => _matrix[0].Length; }

        public int this[int row, int column]
        {
            get => _matrix[row][column];
            set => _matrix[row][column] = value;
        }

        public static implicit operator string(Matrix m) { return m.ToString(); }

        // Constructors

        public Matrix()
        {
            _matrix = Array.Empty<int[]>();
            _matrix[0] = Array.Empty<int>();
        }

        public Matrix(int rows, int columns)
        {
            _matrix = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                _matrix[row] = new int[columns];
            }
        }

        public Matrix(Matrix input)
        {
            _matrix = input._matrix;
        }

        public Matrix(int rows, int columns, Tuple<int, int> range)
        {
            _matrix = GenerateRandomMatrix(rows, columns, range)._matrix;
        }

        public Matrix(int[][] array)
        {
            _matrix = array;
        }

        // Data access and management

        public int Get(int row, int column)
        {
            return this[row, column];
        }

        public void Set(int row, int column, int value)
        {
            this[row, column] = value;
        }

        public void SetMatrix(int[][] newMatrix)
        {
            _matrix = newMatrix;
        }

        // Validation checks

        public bool IsMultipliable(Matrix other)
        {
            return Columns == other.Rows;
        }

        public bool IsAddable(Matrix other)
        {
            return Columns == other.Columns && Rows == other.Rows;
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

        public Matrix ScalarMultiplication(int value)
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
            int sum = 0;

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

        public int SumOfAll(Matrix matrix)
        {
            int sum = 0;
            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    sum += matrix[row, column];
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

        public int Determinant(Matrix matrix2x2)
        {
            matrix2x2[0, 1] *= -1;
            matrix2x2[1, 0] *= -1;

            (matrix2x2[0, 0], matrix2x2[1, 1]) = (matrix2x2[1, 1], matrix2x2[0, 0]);

            ScalarMultiplication(1 / ((matrix2x2[0, 0] * matrix2x2[1, 1]) - (matrix2x2[0, 1] * matrix2x2[1, 0])));

            return 0;
        }

        public Matrix CheckboardSignInversion()
        {
            Matrix newMatrix = new(_matrix);

            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    if (row % 2 != 0 !^ column % 2 != 0)
                    {
                        newMatrix[row, column] *= -1;
                    }
                }
            }

            return newMatrix;
        }

        public Matrix InverseMatrix()
        {
            Matrix newMatrix = new();
            Matrix tempMatrix = new Matrix(2, 2);

            for (int row = 0; row < Rows - 1; row++)
            {
                for (int column = 0; column < Columns - 1; column++)
                {
                    GetSub2x2(row, column);
                }
            }

            return newMatrix;
        }

        // String conversion utility

        public int FindGreatest()
        {
            int greatest = 0;

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
            int greatest = 0;
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
                    output.Append(RandomUtilities.SpaceFormatting(this[row, column], size) + "|");
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
    }
}
