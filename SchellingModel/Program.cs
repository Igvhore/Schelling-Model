namespace SchellingModel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map();
            Console.Write("Введите размер карты (минимальный размер равен 3): ");
            map.SetSize(Console.ReadLine());
            map.CreateMap();           
            Console.WriteLine("Test-------------------------------------");    
            map.DetectStatus();
            map.PrintStatus();
            //map.PrintNeighbours(4, 4);

            //List<Cell> cells = map.DetectStatus();
            //foreach (Cell cell in cells) 
            //{ 
            //    Console.WriteLine(cell.x);
            //    Console.Write(cell.y);
            //}

            map.SwapUnhappy();
            map.PrintStatus();
           
        }
    }
}