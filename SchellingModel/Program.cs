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
            Console.WriteLine("Начало работы алгоритма");    
            map.DetectStatus();
            Console.WriteLine("Статус для каждой клетки:");
            map.PrintMap();
            map.SwapUnhappy();
            Console.WriteLine("Статус для каждой клетки после работы алгоритма:");
            map.PrintMap(); 
           
        }
    }
}