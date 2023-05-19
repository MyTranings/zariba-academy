namespace MathematicalMatrix
{
    using System;

    public class Matrix
    {
        private const string EXEPTION_MESSAGE = "The matrix need to be identical to perform this action.";
        private const string EXEPTION_MESSAGE_MULTIPLICATION = "Multiplication of matrix is only available if columns in the first matrix are equals to the rows of the second matrix!";

        public Matrix(int row, int col, int[,] matrixContent)
        {
            this.Row = row;
            this.Col = col;
            this.MatrixContent = matrixContent;
        }

        public int Row { get; private set; }

        public int Col { get; private set; }

        public int[,] MatrixContent { get; private set; }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            if (CheckMatrix(m1, m2))
            {
                Matrix result = new Matrix(m1.Row, m1.Col, new int[m1.Row, m1.Col]);

                for (int i = 0; i < m1.Row; i++)
                {
                    for (int j = 0; j < m1.Col; j++)
                    {
                        result.MatrixContent[i, j] = m1.MatrixContent[i, j] + m2.MatrixContent[i, j];
                    }
                }

                return result;
            }
            else
            {
                throw new ArgumentException(EXEPTION_MESSAGE);
            }
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            if (CheckMatrix(m1, m2))
            {
                Matrix result = new Matrix(m1.Row, m1.Col, new int[m1.Row, m1.Col]);

                for (int i = 0; i < m1.Row; i++)
                {
                    for (int j = 0; j < m1.Col; j++)
                    {
                        result.MatrixContent[i, j] = m1.MatrixContent[i, j] - m2.MatrixContent[i, j];
                    }
                }

                return result;
            }
            else
            {
                throw new ArgumentException(EXEPTION_MESSAGE);
            }
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            Matrix result;
            int iterations = 0;

            if (m1.Col > m2.Row)
            {
                iterations = m1.Col;
            }
            else if (m2.Row > m1.Col)
            {
                iterations = m2.Row;
            }
            else
            {
                iterations = m1.Col;
            }

            if (m1.Row == 1 && m1.Col == 1)
            {
                result = new Matrix(m2.Row, m2.Col, new int[m2.Row, m2.Col]);

                for (int i = 0; i < result.Row; i++)
                {
                    for (int j = 0; j < result.Col; j++)
                    {
                        result.MatrixContent[i, j] = m1.MatrixContent[0, 0] * m2.MatrixContent[i, j];
                    }
                }
            }
            else if (m2.Row == 1 && m2.Col == 1)
            {
                result = new Matrix(m1.Row, m1.Col, new int[m1.Row, m1.Col]);

                for (int i = 0; i < result.Row; i++)
                {
                    for (int j = 0; j < result.Col; j++)
                    {
                        result.MatrixContent[i, j] = m1.MatrixContent[i, j] * m2.MatrixContent[0, 0];
                    }
                }
            }
            else if (m1.Col == m2.Row)
            {
                result = new Matrix(m1.Row, m2.Col, new int[m1.Row, m2.Col]);

                for (int i = 0; i < result.Row; i++)
                {
                    for (int j = 0; j < result.Col; j++)
                    {
                        for (int n = 0; n < iterations; n++)
                        {
                            result.MatrixContent[i, j] += m1.MatrixContent[i, n] * m2.MatrixContent[n, j];
                        }
                    }
                }
            }
            else
            {
                throw new ArgumentException(EXEPTION_MESSAGE_MULTIPLICATION);
            }

            return result;
        }

        private static bool CheckMatrix(Matrix m1, Matrix m2)
        {
            if (m1.Row != m2.Row || m1.Col != m2.Col)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
