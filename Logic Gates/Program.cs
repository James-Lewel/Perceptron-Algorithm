using System;

namespace Logic_Gates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] inputs = new int[4][];
            int[] outputs = new int[4];

            // Pre-defined inputs
            inputs[0] = new int[2] { 0, 0 };
            inputs[1] = new int[2] { 0, 1 };
            inputs[2] = new int[2] { 1, 0 };
            inputs[3] = new int[2] { 1, 1 };

            /* METHOD 1
            //Takes user input of x
            Console.WriteLine("Input X |X1|X2 - Separated by comma - {1,0}");
            for (int i = 0; i < 4; i++)
            {
                inputs[i] = new int[2];
                Console.Write("      x{0}| ", i);

                // Reads and splits line by comma
                string[] input = Console.ReadLine().Split(',');

                // Loops and stores input into inputs
                for (int j = 0; j < 2; j++)
                    inputs[i][j] = int.Parse(input[j]);
            }*/

            /* METHOD 2
            //Takes user input of y
            Console.WriteLine("\n-------------------------------\n");
            Console.WriteLine("Input Y | (Expected Output)");
            for (int i = 0; i < 4; i++)
            {
                Console.Write("      y{0}| ", i);

                outputs[i] = int.Parse(Console.ReadLine());
            }
            */

            // METHOD 3
            Console.WriteLine("1 - [OR]");
            Console.WriteLine("2 - [AND]");
            Console.WriteLine("3 - [NOR]");
            Console.WriteLine("4 - [NAND]");
            Console.WriteLine("5 - [XOR]");
            Console.WriteLine("6 - [XNOR]");
            Console.Write("Enter : ");

            switch(Console.ReadLine())
            {
                case "1":
                    outputs = new int[] { 0, 1, 1, 1};
                    break;
                case "2":
                    outputs = new int[] { 0, 0, 0, 1 };
                    break;
                case "3":
                    outputs = new int[] { 1, 0, 0, 0 };
                    break;
                case "4":
                    outputs = new int[] { 1, 1, 1, 0 };
                    break;
                case "5":
                    outputs = new int[] { 0, 1, 1, 0 };
                    break;
                case "6":
                    outputs = new int[] { 1, 0, 0, 1 };
                    break;
            }

            Console.WriteLine("\n-------------------------------\n");

            // Train the perceptron
            Perceptron p = new Perceptron();
            p.Train(inputs, outputs, 10);

            // Loops and test perceptrons
            Console.WriteLine("\n-------------------------------");
            Console.WriteLine("\n X1 | X2 | Expected | Results");
            for (int i = 0; i < 4; i++)
                Console.WriteLine("  {0} |  {1} |    {2}     |  {3}", inputs[i][0]
                                                                    , inputs[i][1]
                                                                    , outputs[i]
                                                                    ,p.CalculateOutput(inputs[i]));

            Console.ReadLine();
        }
    }
}
