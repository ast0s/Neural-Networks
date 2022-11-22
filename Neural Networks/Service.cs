using MathNet.Numerics.LinearAlgebra;

namespace Neural_Networks
{
    public class Service
    {
        public Perceptron P = new Perceptron();
        public TSM TSM = new TSM();

        public void SetLearningSpeedCoefficient() { P.C = double.Parse(Console.ReadLine()); }

        public void SetFinalWeightsFromTxt()
        {
            P.W = Vector<double>.Build.Dense(File.ReadAllText("final_weights.txt").Split(' ').Select(x => double.Parse(x)).ToArray());
        }
        public void SetWeightsFromTxt()
        {
            P.W = Vector<double>.Build.Dense(File.ReadAllText("weights.txt").Split(' ').Select(x => double.Parse(x)).ToArray());
        }
        public void SetRandomWeights()
        {
            Console.WriteLine("How many weights the neuron should have?");
            P.W = Vector<double>.Build.Random(int.Parse(Console.ReadLine()));
        }
        public void SetManualWeights()
        {
            P.W = Vector<double>.Build.Dense(Console.ReadLine().Split(' ').Select(x => double.Parse(x)).ToArray());
        }
        public void PrintWeights()
        {
            for (int i = 0; i < P.W.Count; i++)
                Console.WriteLine(P.W[i] + " ");
        }
        public void WriteTxtFinalWeights()
        {
            string str = "";

            for (int i = 0; i < P.W.Count; i++)
                str += P.W[i] + " ";

            File.WriteAllText("final_weights.txt", str.Trim());
        }

        public void SetPerceptronInputXFromTxt()
        {
            string[] str_input = File.ReadAllText("perceptron_input.txt").Replace("\r\n", " ").Trim().Split(' ');
            P.X = Matrix<double>.Build.Dense(str_input.Length / P.W.Count, P.W.Count, str_input.Select(x => double.Parse(x)).ToArray()).Transpose();
        }
        public void SetTSMInputXFromTxt(int columns)
        {
            string[] str_input = File.ReadAllText("tsm_input.txt").Replace("\r\n", " ").Trim().Split(' ');
            TSM.X = Matrix<double>.Build.Dense(str_input.Length / columns, columns, str_input.Select(x => double.Parse(x)).ToArray()).Transpose();
        }

        public void PrintPerceptronInputX()
        {
            for (int i = 0; i < P.X.ColumnCount; i++)
            {
                for (int j = 0; j < P.X.RowCount; j++)
                {
                    Console.Write(P.X[j, i] + "\t");
                }
                Console.WriteLine();
            }
        }

        public void PrintTSMInputX()
        {
            for (int i = 0; i < TSM.X.ColumnCount; i++)
            {
                for (int j = 0; j < TSM.X.RowCount; j++)
                {
                    Console.Write(TSM.X[j, i] + "\t");
                }
                Console.WriteLine();
            }
        }

        public void PrintKB() => Console.WriteLine($"k = {TSM.k}, b = {TSM.b}, y = kx+b");
    }
}
