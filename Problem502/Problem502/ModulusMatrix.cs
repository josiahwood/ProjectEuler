using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Problem502
{
	public class ModulusMatrix
	{
		private int _rows;
		private int _columns;
		private ModulusNumber[,] _values;

		public ModulusMatrix(int rows, int columns)
		{
			_rows = rows;
			_columns = columns;
			_values = new ModulusNumber[rows, columns];
		}

		private ModulusMatrix(int rows, int columns, ModulusNumber[,] values)
		{
			_rows = rows;
			_columns = columns;
			_values = values;
		}

		public ModulusNumber this[int row, int column]
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

		public ModulusNumber[] Column(int index)
		{
			ModulusNumber[] column = new ModulusNumber[_rows];

			for (int i = 0; i < _rows; i++)
			{
				column[i] = _values[i, index];
			}

			return column;
		}

		public static ModulusMatrix operator +(ModulusMatrix left, ModulusMatrix right)
		{
			if ((left._columns != right._columns) || (left._rows != right._rows))
			{
				throw new Exception("Incompatible matrices");
			}

			ModulusMatrix result = new ModulusMatrix(left._rows, right._columns);

			for (int i = 0; i < left._rows; i++)
			{
				for (int j = 0; j < left._columns; j++)
				{
					result._values[i, j] += left[i, j] * right[i, j];
				}
			}

			return result;
		}

		public static ModulusMatrix operator *(ModulusMatrix left, ModulusMatrix right)
		{
			if (left._columns != right._rows)
			{
				throw new Exception("Incompatible matrices");
			}

			ModulusMatrix result = new ModulusMatrix(left._rows, right._columns);

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

		public static ModulusMatrix Power(ModulusMatrix matrix, BigInteger power)
		{
			ModulusMatrix result = new ModulusMatrix(matrix._rows, matrix._columns);

			byte[] powerBytes = power.ToByteArray();
			BitArray powerBitArray = new BitArray(powerBytes);

			ModulusMatrix powerMatrix = new ModulusMatrix(matrix._rows, matrix._columns, (ModulusNumber[,])matrix._values.Clone());

			for (int i = 0; i < powerBitArray.Count; i++)
			{
				if (powerBitArray[i])
				{
					result += powerMatrix;
				}

				powerMatrix *= powerMatrix;
			}

			return result;
		}
	}
}
