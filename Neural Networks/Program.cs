namespace Neural_Networks
{
    public class Program
    {

        static void Main(string[] args)
        {
            Service s = new Service();

            Console.WriteLine("What method to use?\n1)Perceptron\n2)Tsm");

            if (Console.ReadLine() == "1")
            {
                Console.WriteLine("Set the learning speed coefficient.");
                s.SetLearningSpeedCoefficient();

                Console.WriteLine("How to set weights?\n1)From txt\n2)From txt (final)\n3)Randomly\n4)Manualy");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("The weights:");
                        s.SetWeightsFromTxt();
                        s.PrintWeights();
                        break;
                    case "2":
                        Console.WriteLine("The weights:");
                        s.SetFinalWeightsFromTxt();
                        s.PrintWeights();
                        break;
                    case "3":
                        Console.WriteLine("The weights:");
                        s.SetRandomWeights();
                        s.PrintWeights();
                        break;
                    case "4":
                        Console.WriteLine("The weights:");
                        s.SetManualWeights();
                        break;
                    default:
                        break;
                }

                Console.WriteLine("The input:");
                s.SetPerceptronInputXFromTxt();
                s.PrintPerceptronInputX();

                Console.WriteLine("How many eras should perceptron be trained?");
                s.P.Progonka(int.Parse(Console.ReadLine()));
                Console.WriteLine("The result:");
                s.PrintWeights();
                s.WriteTxtFinalWeights();
            }
            else
            {
                s.SetTSMInputXFromTxt(2);
                s.PrintTSMInputX();

                s.TSM.FindK();
                s.TSM.FindB();
                s.PrintKB();
            }
        }
    }
}