using Microsoft.VisualBasic;
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
        private void Split(string percentage)
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

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (_cells[i, j].GetColour() == "Unknown" && endPoint > 0)
                    {
                        _cells[i, j].SetColour(colour);
                        endPoint--;
                    }


                }
                                 
            }
        }
        private void Swap (Cell[,] cells, int a_i, int a_j, int b_i, int b_j)
        {
            Cell temp = cells[a_i,a_j];
            cells[a_i, a_j] = cells[b_i, b_j];
            cells[b_i, b_j] = temp;
        }
        private void Shaffle(Cell[,] cells)
        {
            Random rnd = new Random(DateTime.Now.Second + DateTime.Now.Minute + DateTime.Now.Hour);

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                   Swap(cells,i,j,rnd.Next(0,(int)_size-1), rnd.Next(0, (int)_size - 1));               
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
            Shaffle(_cells);
        }
        public void PrintMap()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)                
                    Console.Write($"{_cells[i, j].GetColour()} ");
                

                Console.WriteLine("\n");
            }

        }

    }
}
