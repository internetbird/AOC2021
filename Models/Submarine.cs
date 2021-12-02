using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2021.Models
{
    public class Submarine
    {
        protected int _position;
        protected int _depth;
        
    
        public Submarine()
        {
            _depth = 0;
            _position = 0;  
        }

        public virtual void MoveForward(int units)
        {
            _position += units;
        }

        public virtual void MoveUp(int units)
        {
            _depth -= units;
        }

        public virtual void MoveDown(int units)
        {
            _depth += units;
        }

        public (int depth, int position) GetStatus()
        {
            return (_depth, _position);
        }
    }
}
