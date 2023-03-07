using System;

namespace Logic_Gates
{
    public class Perceptron
    {
        double[] weights;
        double bias;
        double learningRate;

        public Perceptron()
        {
            weights = new double[2];
            bias = -0.5;
            learningRate = 0.1;
        }

        public Perceptron(double bias, double learningRate)
        {
            this.bias = bias;
            this.learningRate = learningRate;
        }

        public Perceptron(double[] weights, double bias, double learningRate)
        {
            this.weights = weights;
            this.bias = bias;
            this.learningRate = learningRate;
        }

        // Activation function using step rule
        public int Activation(double sum)
        {
            return (sum >= 0) ? 1 : 0;
        }

        public int Predict(int[] x)
        {
            double weightedSum = 0;

            // Calculates weighted sum
            for (int i = 0; i < 2; i++)
                weightedSum += x[i] * weights[i];
            weightedSum += bias;

            return Activation(weightedSum);
        }

        public void Train(int[][] inputs, int[] outputs, int epochLimit)
        {
            Random rnd = new Random(new Random().Next());
            for (int i = 0; i < weights.Length; i++)
                weights[i] = (rnd.Next(2) == 0) ? -1 : 1;

            int[] x = new int[2];

            for (int epoch = 0; epoch < epochLimit; epoch++)
            {
                double totalError = 0;
                for (int i = 0; i < outputs.Length; i++)
                {
                    // Sets x
                    for (int j = 0; j < 2; j++)
                        x[j] = inputs[i][j];

                    // Sets predictions and errors
                    int output = outputs[i];
                    int prediction = Predict(x);
                    int error = output - prediction;
                    totalError += Math.Abs(error);

                    // Set new weights and bias
                    for (int j = 0; i < 2; i++)
                        weights[j] += learningRate * error * x[j];
                    bias += learningRate * error;
                }
                Console.WriteLine("Epoch = {0}, Error = {1}", epoch, totalError);

                // Ends if error is zero
                if (totalError == 0) 
                    break;
            }
        }
    }
}
