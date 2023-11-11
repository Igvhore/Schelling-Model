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
        public int R_neighbours;
        public int B_neighbours;
        public int x;
        public int y;

        public Cell()
        {
            _colour = "U";
            _status = false;
            neighbours = new List<Cell>();
            R_neighbours = 0;
            B_neighbours = 0;
        }
        public Cell(string colour)
        {
            _colour = colour;
            _status = false;
            neighbours = new List<Cell>();
            R_neighbours = 0;
            B_neighbours = 0;
        }
        public Cell(bool status)
        {
            _colour = "U";
            _status = status;
            neighbours = new List<Cell>();
            R_neighbours = 0;
            B_neighbours = 0;
        }
        public Cell(List<Cell> neighbours)
        {
            _colour = "U";
            _status = false;
            this.neighbours = neighbours;
            R_neighbours = 0;
            B_neighbours = 0;
        }
        public Cell(string colour, bool status)
        {
            _colour = colour;
            _status = status;
            neighbours = new List<Cell>();
            R_neighbours = 0;
            B_neighbours = 0;
        }
        public Cell(string colour, List<Cell> neighbours)
        {
            _colour = colour;
            _status = false;
            this.neighbours = neighbours;
            R_neighbours = 0;
            B_neighbours = 0;
        }
        public Cell(bool status, List<Cell> neighbours)
        {
            _colour = "U";
            _status = status;
            this.neighbours = neighbours;
            R_neighbours = 0;
            B_neighbours = 0;
        }
        public Cell(string colour, bool status, List<Cell> neighbours)
        {
            _colour = colour;
            _status = status;
            this.neighbours = neighbours;
            R_neighbours = 0;
            B_neighbours = 0;
        }
                       
        public void SetColour(string colour) => _colour = colour; 
        public void SetStatus(bool status) => _status = status; 
        public string GetColour() => this._colour; 
        public bool GetStatus() => this._status;
    }
}
