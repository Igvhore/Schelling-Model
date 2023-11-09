using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchellingModel
{
    internal class Cell
    {
        private string _colour;
        private bool _status;
        public List<Cell> neighbours;

        public Cell()
        {
            _colour = "Unknown";
            _status = false;
            neighbours = new List<Cell>();
        }
        public Cell(string colour)
        {
            _colour = colour;
            _status = false;
            neighbours = new List<Cell>();
        }
        public Cell(bool status)
        {
            _colour = "Unknown";
            _status = status;
            neighbours = new List<Cell>();
        }
        public Cell(List<Cell> neighbours)
        {
            _colour = "Unknown";
            _status = false;
            this.neighbours = neighbours;
        }
        public Cell(string colour, bool status)
        {
            _colour = colour;
            _status = status;
            neighbours = new List<Cell>();
        }
        public Cell(string colour, List<Cell> neighbours)
        {
            _colour = colour;
            _status = false;
            this.neighbours = neighbours;
        }
        public Cell(bool status, List<Cell> neighbours)
        {
            _colour = "Unknown";
            _status = status;
            this.neighbours = neighbours;
        }
        public Cell(string colour, bool status, List<Cell> neighbours)
        {
            _colour = colour;
            _status = status;
            this.neighbours = neighbours;
        }
    }
}
