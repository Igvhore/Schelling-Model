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
        private void _Split(string percentage)
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
                _Split(Console.ReadLine());
            }
        }
        public void GenerateCells (int endPoint, string colour)
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (_cells[i, j].GetColour() == "U" && endPoint > 0)
                    {
                        _cells[i, j].SetColour(colour);
                        endPoint--;
                    }

                }
                                 
            }
        }
        private void _SwapCellByIndex (int a_i, int a_j, int b_i, int b_j)
        {
            Cell temp = _cells[a_i,a_j];
            _cells[a_i, a_j] = _cells[b_i, b_j];
            _cells[b_i, b_j] = temp;
        }
        private void Shaffle()
        {
            Random rnd = new Random(DateTime.Now.Second + DateTime.Now.Minute + DateTime.Now.Hour);

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                    _SwapCellByIndex(i,j,rnd.Next(0,(int)_size-1), rnd.Next(0, (int)_size - 1));               
            }
        }
        public void CreateMap()
        {
            _cells = new Cell[_size, _size];
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                    _cells[i, j] = new Cell();                                  
            }

            Console.Write("Введите процент разделения: ");
            this._Split(Console.ReadLine());
            this.GenerateCells((int)this.amountOfMembersInFirstGroup, "R");
            this.GenerateCells((int)this.amountOfMembersInSecondGroup, "B");
            Shaffle();
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
        public void CreateNeighboursTry()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    try
                    {
                        _cells[i, j].neighbours.Add(_cells[i - 1, j]);
                    }
                    catch { }
                    try
                    {
                        _cells[i, j].neighbours.Add(_cells[i - 1, j + 1]);
                    }
                    catch { }
                    try
                    {
                        _cells[i, j].neighbours.Add(_cells[i - 1, j - 1]);
                    }
                    catch { }

                    try
                    {
                        _cells[i, j].neighbours.Add(_cells[i, j - 1]);
                    }
                    catch { }
                    try
                    {
                        _cells[i, j].neighbours.Add(_cells[i, j + 1]);
                    }
                    catch { }

                    try
                    {
                        _cells[i, j].neighbours.Add(_cells[i + 1, j]);
                    }
                    catch { }
                    try
                    {
                        _cells[i, j].neighbours.Add(_cells[i + 1, j + 1]);
                    }
                    catch { }
                    try
                    {
                        _cells[i, j].neighbours.Add(_cells[i + 1, j - 1]);
                    }
                    catch { }
                }
            }
        }
        public List<Cell> DetectStatus()
        {
            CreateNeighboursTry();
            List<Cell> unhappies = new List<Cell>();
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    foreach (var neighbour in _cells[i, j].neighbours)
                    {
                        if (neighbour.GetColour() == "R")
                            _cells[i, j].R_neighbours++;
                        else if (neighbour.GetColour() == "B")
                            _cells[i, j].B_neighbours++;
                    }

                    _cells[i, j].x = i;
                    _cells[i, j].y = j;

                    if (_cells[i, j].GetColour() == "R" & _cells[i, j].R_neighbours >= 2)
                        _cells[i, j].SetStatus(true);
                    else if (_cells[i, j].GetColour() == "B" & _cells[i, j].B_neighbours >= 2)
                        _cells[i, j].SetStatus(true);
                    else if (_cells[i, j].GetColour() != "U")
                    {
                        _cells[i, j].SetStatus(false);
                        unhappies.Add(_cells[i, j]);
                    }                      
                    _cells[i, j].R_neighbours = 0;
                    _cells[i, j].B_neighbours = 0;
                }
            }
            return unhappies;
        }
        public List<Cell> DetectFreeSpace()
        {
            List<Cell> whites = new List<Cell>();
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (_cells[i, j].GetColour() == "U")
                        whites.Add(_cells[i, j]);
                }
            }
            return whites;
        }
        public void SwapUnhappy()
        {
            List<Cell> unhappy = new List<Cell>();
            List<Cell> whites = new List<Cell>();
            Console.Write("Введите количество итераций: ");
            int iteration = 3;
            iteration = Convert.ToInt32(Console.ReadLine());
            Random random = new Random();

            for(int i = 0; i < iteration; i++)
            {
                unhappy = DetectStatus();
                whites = DetectFreeSpace();

                if(unhappy.Count > 0 && whites.Count > 0)
                {
                    Cell cl1 = unhappy[random.Next(0, unhappy.Count)];
                    Cell cl2 = whites[random.Next(0, whites.Count)];
                    _SwapCellByIndex(cl1.x, cl1.y, cl2.x, cl2.y);
                }                 
            }
        }
        public void PrintStatus()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                    Console.Write($"{Convert.ToInt32(_cells[i, j].GetStatus())} ");


                Console.WriteLine("\n");
            }

        }
        public void PrintNeighbours(int i, int j)
        {
            foreach(var neighbour in _cells[i,j].neighbours)
                Console.WriteLine(neighbour.GetColour());           
        }       
    }
}
