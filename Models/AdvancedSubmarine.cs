using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2021.Models
{
    public class AdvancedSubmarine : Submarine
    {
        private int _aim;

        public AdvancedSubmarine() : base()
        {
            _aim = 0;
        }

        public override void MoveForward(int units)
        {
            _depth += (_aim * units);

            base.MoveForward(units);
        }

        public override void MoveUp(int units)
        {
            _aim -= units;
        }

        public override void MoveDown(int units)
        {
            _aim += units;
        }
    }
}
