using System;

namespace Lab4
{
    class Pair
    {
        
        private int Y;
        private int X;
        public double probabilityForY { get; }
        private int numberOfRandsCounter;

        public Pair(int X, int Y, double probabilityForY)
        {
            this.X = X;
            this.Y = Y;
            this.probabilityForY = probabilityForY;
            this.ClearCounter();
        }

        public void IncreseCounter()
        {
            this.numberOfRandsCounter += 1;
        }

        public void ClearCounter()
        {
            this.numberOfRandsCounter = 0;
        }

        public void PrintCounter()
        {
            Console.WriteLine("Pair (" + X + ", " + Y + ") - counter: " + numberOfRandsCounter);
        }

        public void PrintPair()
        {
            Console.WriteLine("Pair (" + X + ", " + Y + ")");
        }

    }
}

