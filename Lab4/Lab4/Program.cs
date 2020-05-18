
namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {

            PairRandomGenerator generator = new PairRandomGenerator(100000);
            generator
                .ClearPairsCounters()
                .PrintRandPairs()
                .PrintPairsCouters();

        }
    }
}
