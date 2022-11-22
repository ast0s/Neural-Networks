using MathNet.Numerics.LinearAlgebra;

namespace Neural_Networks
{
    public class TSM
    {
        public Matrix<double> X;
        public double k;
        public double b;

        public void FindK()
        {
            int n = X.ColumnCount;
            double sumXY = 0, sumXsqr = 0;

            for (int i = 0; i < n; i++)
                sumXY += X[0, i] * X[1, i];

            for (int i = 0; i < n; i++)
                sumXsqr += X[0, i] * X[0, i];

            k = (n * sumXY - X.Row(0).Sum() * X.Row(1).Sum())/(n * sumXsqr - (X.Row(0).Sum() * X.Row(0).Sum()));
        }
        public void FindB() => b = (X.Row(1).Sum() - k * X.Row(0).Sum()) / X.ColumnCount;
    }
}
