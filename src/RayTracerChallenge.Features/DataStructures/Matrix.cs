namespace RayTracerChallenge.Features.DataStructures;

public struct Matrix
{
    public int RowCount { get; }
    private int ColumnCount { get; }

    public float[,] MatrixArray { get; set; }

    public Matrix(int rows, int columns)
    {
        RowCount = rows;
        ColumnCount = columns;
        MatrixArray = new float[RowCount, ColumnCount];
    }

    public float this[int rowIndex, int columnIndex]
    {
        get => MatrixArray[rowIndex, columnIndex];
        set => MatrixArray[rowIndex, columnIndex] = value;
    }

    public static bool operator ==(Matrix left, Matrix right)
    {
        if (left.RowCount != right.RowCount || left.ColumnCount != right.ColumnCount)
        {
            return false;
        }

        for (int i = 0; i < left.RowCount; i++)
        {
            for (int j = 0; j < left.ColumnCount; j++)
            {
                if (!FloatComparison.AboutEqual(left[i, j], right[i, j]))
                {
                    return false;
                }
            }
        }

        return true;
    }

    public static bool operator !=(Matrix left, Matrix right)
    {
        return !(left == right);
    }

    public static Matrix operator *(Matrix left, Matrix right)
    {
        if (left.RowCount != 4 || left.ColumnCount != 4 || right.RowCount != 4 || right.ColumnCount != 4)
        {
            throw new ArgumentException("Only 4x4 matrices can be multiplied.");
        }
        Matrix M = new(4, 4);
        for (int rowI = 0; rowI < 4; rowI++)
        {
            for (int columnI = 0; columnI < 4; columnI++)
            {
                M[rowI, columnI] = (left[rowI, 0] * right[0, columnI])
                    + (left[rowI, 1] * right[1, columnI])
                    + (left[rowI, 2] * right[2, columnI])
                    + (left[rowI, 3] * right[3, columnI]);
            }
        }
        return M;
    }

    public static Element operator *(Matrix left, Element right)
    {
        if (left.RowCount != 4 || left.ColumnCount != 4)
        {
            throw new ArgumentException("Only 4x4 matrices can be multiplied.");
        }

        float[] results = new float[4];

        for (int i = 0; i < 4; i++)
        {

            results[i] = (left[i, 0] * right.X)
                        + (left[i, 1] * right.Y)
                        + (left[i, 2] * right.Z)
                        + (left[i, 3] * (right.W ? 1 : 0));

        }

        return new Element(results[0], results[1], results[2], right.W);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        return obj is Matrix && this == (Matrix)obj;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public Matrix Transpose()
    {
        Matrix transposed = new(ColumnCount, RowCount);
        for (int i = 0; i < ColumnCount; i++)
        {
            for (int j = 0; j < RowCount; j++)
            {
                transposed[i, j] = this[j, i];
            }
        }
        return transposed;
    }

    public static Matrix IdentityMatrix
    {
        get
        {
            Matrix m = new(4, 4);
            m[0, 0] = 1;
            m[0, 1] = 0;
            m[0, 2] = 0;
            m[0, 3] = 0;
            m[1, 0] = 0;
            m[1, 1] = 1;
            m[1, 2] = 0;
            m[1, 3] = 0;
            m[2, 0] = 0;
            m[2, 1] = 0;
            m[2, 2] = 1;
            m[2, 3] = 0;
            m[3, 0] = 0;
            m[3, 1] = 0;
            m[3, 2] = 0;
            m[3, 3] = 1;
            return m;
        }
    }
}
