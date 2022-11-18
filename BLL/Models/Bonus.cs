using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Bonus
    {
        public int RealSum(int sum, int count)
        {
            return (count % 1000 == 0) ? sum : sum + 1000;
        }
    }
}
