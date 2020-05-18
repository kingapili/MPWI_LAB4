using System;
using System.Collections.Generic;

namespace Lab4
{
    class PairRandomGenerator
    {
        private static Dictionary<int,double> xProbabilities;
        private static Dictionary<int, Pair []> pairs;
        private int randomValueX;
        private int numberOfRandsToGenerate;

        private Random rnd;

        public PairRandomGenerator(int numberOfRandsToGenerate)
        {
            this.numberOfRandsToGenerate = numberOfRandsToGenerate;
            xProbabilities = new Dictionary<int, double> { { 1, 0.25 }, { 2, 0.25 }, { 3, 0.25 }, { 4, 0.25 } };

            pairs = new Dictionary<int, Pair[]>{
                {
                    1, new Pair[] {
                            new Pair(1, 3, 0.5),
                            new Pair(1, 4, 0.5),
                        }
                },
                {
                    2, new Pair[] {
                            new Pair(2, 1, 0.5),
                            new Pair(2, 4, 0.5),
                        }
                },
                {
                    3, new Pair[] {
                            new Pair(3, 3, 1)
                        }
                },
                {
                    4, new Pair[] {
                            new Pair(4, 2, 0.5),
                            new Pair(4, 4, 0.5),
                        }
                }
            };
            rnd = new Random();
        }

        public PairRandomGenerator ClearPairsCounters()
        {
            foreach (var x_pairs in pairs)
            {
                foreach (Pair pair in x_pairs.Value)
                {
                    pair.ClearCounter();
                }
            }
            return this;
        }

        private PairRandomGenerator RandX()
        {
            double randProbabilityForX = rnd.NextDouble();
            double previousProbabilities = 0;

            foreach (var x_probability in xProbabilities)
            {
                if (randProbabilityForX <= x_probability.Value + previousProbabilities)
                {
                    randomValueX = x_probability.Key;
                    break;
                }
                else
                {
                    previousProbabilities += x_probability.Value;
                }
            }
            return this;
        }

        private Pair RandY()
        {
            double randProbabilityForY = rnd.NextDouble();
            double previousProbabilities = 0;

            foreach (Pair pair in pairs[randomValueX])
            {
                if (randProbabilityForY <= pair.probabilityForY + previousProbabilities)
                {
                    pair.IncreseCounter();
                    return pair;
                }
                else
                {
                    previousProbabilities += pair.probabilityForY;
                }
            }
            throw new NullReferenceException("Not found pair for randed pobabilities");
        }

        public PairRandomGenerator PrintRandPairs()
        {
            for (int i = 0; i < numberOfRandsToGenerate; ++i)
            {
                try
                {
                    this
                        .RandX()
                        .RandY()
                        .PrintPair();
                }
                catch (NullReferenceException e)
                {

                    Console.WriteLine("NullReferenceException source: {0}", e.Source);
                }
                
            }
            return this;
        }

        public void PrintPairsCouters()
        {
            foreach (var x_pairs in pairs)
            {
                foreach (Pair pair in x_pairs.Value)
                {
                    pair.PrintCounter();
                }
            }
            Console.Read();
        }
    }
}
