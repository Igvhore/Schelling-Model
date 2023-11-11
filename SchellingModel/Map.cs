using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SchellingModel
{
    internal class Map
    {
        private uint _size;
        private Cell[,] _cells;
        private double amountOfMembersInFirstGroup;
        private double amountOfMembersInSecondGroup;    

        public void SetSize(string size) 
        {
            try
            {
                if (UInt32.Parse(size) < 3)
                {
                    Console.WriteLine("Был установлен минимальный размер равынй 3");
                    _size = 3;
                }
                else
                    _size = UInt32.Parse(size);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка! {e.Message}");
                Console.WriteLine("Введите размер карты (минимальный размер равен 3): ");
                SetSize(Console.ReadLine());
            }

        }
        public uint GetSize() => _size;
        public void Split(string percentage)
        {
            try
            {
                if (UInt32.Parse(percentage) > 0 && UInt32.Parse(percentage) <= 100)
                {
                    amountOfMembersInFirstGroup = (double)(_size * _size) / 100 * UInt32.Parse(percentage);
                    amountOfMembersInSecondGroup = (double)(_size * _size) / 100 * UInt32.Parse(percentage);
                }
                else
                    throw new ArgumentOutOfRangeException();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка! {e.Message}");
                Console.Write("Введите процент еще раз: ");
                Split(Console.ReadLine());
            }
        }
        public void GenerateCells (int endPoint, string colour)
        {

            for (int i = 0; i < endPoint / 2; i++)
            {
                for (int j = 0; j < endPoint / 2; j++)
                {
                    if (_cells[i, j].GetColour() == "Unknown")
                        _cells[i, j].SetColour(colour);
                }
                                 
            }
        }

        public void CreateMap()
        {
            _cells = new Cell[_size, _size];
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    _cells[i, j] = new Cell();                  
                }
            }

            Console.Write("Введите процент разделения: ");
            this.Split(Console.ReadLine());
            this.GenerateCells((int)this.amountOfMembersInFirstGroup, "Red");
            this.GenerateCells((int)this.amountOfMembersInSecondGroup, "Blue");

        }
        public void PrintMap()
        {
            for (int i = 0; i < _size / 2; i++)
            {
                for (int j = 0; j < _size / 2; j++)                
                    Console.Write($"{_cells[i, j].GetColour()} ");
                

                Console.WriteLine("\n");
            }

        }

    }
}
