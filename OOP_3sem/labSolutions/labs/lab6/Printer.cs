using lab6;

namespace lab6
{
    class Printer
    {
        public void IAmPrinting(Figure figure)
        {
            Console.WriteLine(figure.ToString());
        }
        public void IAmPrinting(Controls ñontrols)
        {
            Console.WriteLine(ñontrols.ToString());
        }
    }
}