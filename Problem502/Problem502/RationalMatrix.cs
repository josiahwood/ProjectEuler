using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem502
{
	class RationalMatrix
	{
		private int _rows;
		private int _columns;
		private RationalNumber[,] _values;

		public RationalMatrix(int rows, int columns)
		{
			_rows = rows;
			_columns = columns;
			_values = new RationalNumber[rows, columns];

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < columns; j++)
				{
					_values[i, j] = RationalNumber.Zero;
				}
			}
		}

		public RationalNumber this[int row, int column]
		{
			get
			{
				return _values[row, column];
			}

			set
			{
				_values[row, column] = value;
			}
		}

		public RationalNumber[] Column(int index)
		{
			RationalNumber[] column = new RationalNumber[_rows];

			for (int i = 0; i < _rows; i++)
			{
				column[i] = _values[i, index];
			}

			return column;
		}

		public static RationalMatrix operator *(RationalMatrix left, RationalMatrix right)
		{
			if (left._columns != right._rows)
			{
				throw new Exception("Incompatible matrices");
			}
			
			RationalMatrix result = new RationalMatrix(left._rows, right._columns);

			for (int i = 0; i < left._rows; i++)
			{
				for (int j = 0; j < right._columns; j++)
				{
					for (int k = 0; k < left._columns; k++)
					{
						result._values[i, j] += left[i, k] * right[k, j];
					}
				}
			}

			return result;
		}

		public static RationalMatrix GaussianElimination(RationalMatrix a, RationalMatrix b)
		{
			RationalNumber[,] ap = (RationalNumber[,])a._values.Clone();
			RationalNumber[,] bp = (RationalNumber[,])b._values.Clone();

			int n = b._rows;

			for (int k = 1; k <= n; k++)
			{
				for (int i = k + 1; i <= n; i++)
				{
					RationalNumber m = ap[i - 1, k - 1] / ap[k - 1, k - 1];
					ap[i - 1, k - 1] = RationalNumber.Zero;

					for (int j = k + 1; j <= n; j++)
					{
						ap[i - 1, j - 1] -= m * ap[k - 1, j - 1];
					}

					bp[i - 1, 0] -= m * bp[k - 1, 0];
				}
			}

			RationalMatrix x = new RationalMatrix(n, 1);

			for (int i = n; i >= 1; i--)
			{
				for (int j = i + 1; j <= n; j++)
				{
					bp[i - 1, 0] -= ap[i - 1, j - 1] * x[j - 1, 0];
				}

				x[i - 1, 0] = bp[i - 1, 0] / ap[i - 1, i - 1];
			}

			return x;
		}

		public static string DisplayMatrix(RationalNumber[,] matrix, int rows, int columns)
		{
			StringBuilder s = new StringBuilder();

			for (int r = 0; r < rows; r++)
			{
				if (r > 0)
				{
					s.AppendLine();
				}

				for (int c = 0; c < columns; c++)
				{
					if (c > 0)
					{
						s.Append(", ");
					}
					
					s.Append(matrix[r, c].ToString());
				}
			}

			return s.ToString();
		}
	}
}
