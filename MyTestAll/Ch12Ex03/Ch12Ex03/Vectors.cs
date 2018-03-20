using System;
using System.Collections.Generic;
using System.Text;

namespace Ch12Ex03
{
    public class Vectors : List<Vector>
    {
        public Vectors()
        {
            
        }

        public Vectors(IEnumerable<Vector> initialItem)
        {
            foreach (Vector vector in initialItem)
            {
                Add(vector);
            }
        }

        public String Sum()
        {
            StringBuilder sb = new StringBuilder();
            Vector currentPoint = new Vector(0.0, 0.0);

            sb.Append("Origin");

            foreach (Vector vector in this)
            {
                sb.AppendFormat($" + {vector}");
                currentPoint += vector;
            }
            sb.AppendFormat($" = {currentPoint}");
            return sb.ToString();
        }
        
    }
}