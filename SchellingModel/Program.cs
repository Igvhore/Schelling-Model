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
            map.PrintMap();

        }
    }
}