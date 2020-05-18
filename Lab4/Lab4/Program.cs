
namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {

            PairRandomGenerator generator = new PairRandomGenerator(10000);
            generator
                .ClearPairsCounters()
                .PrintRandPairs()
                .PrintPairsCouters();

        }
    }
}
