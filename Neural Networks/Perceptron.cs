using MathNet.Numerics.LinearAlgebra;

namespace Neural_Networks
{
    public class Perceptron
    {
        public Vector<double> W;
        public Matrix<double> X;
        public double C;

        public double Net(int i)
        {
            double sum = 0;

            for (int j = 0; j < W.Count - 1; j++)
                sum += X[j, i] * W[j];

            sum += W.Last();

            return sum;
        }
        public int ActivationFunction(double x) { return x >= 0 ? 1 : -1; }
        public void TrainThePerceptronOneEra()
        {
            for (int i = 0; i < X.ColumnCount; i++)
                if (!Check(i, ActivationFunction(Net(i))))
                    AdjustTheWeights(i);
        }
        public void Progonka(int n) { for (int i = 0; i < n; i++) TrainThePerceptronOneEra(); }
        public bool Check(int i, int actFunc) => X[X.RowCount - 1, i] == actFunc;
        public void AdjustTheWeights(int iteration)
        {
            Vector<double> Xi = X.Column(iteration);
            Xi[Xi.Count - 1] = 1;

            W = W + C * (X[X.RowCount - 1, iteration] - ActivationFunction(W  * Xi)) * Xi;
        }
    }
}
