using System;
using System.Collections.Generic;
using System.Text;

namespace InformationCompression
{
    class Character
    {
       public char ch;
       public double min;
       public double max;
       public double delta;


        public Character()
        {
            ch = ' ';
            min = 0;
            max = 0;

        }

        public Character(char ch, double min, double max)
        {
            this.ch = ch;
            this.min = min;
            this.max = max;
            this.delta = Math.Round(max - min, 1);
        }
    }
}
