using BLL.Models;
using DLL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBraceletService
    {
        void GiveBracelet(BraceletModel br);
    }
}
