using DLL.EF;
using DLL.Entity1;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class RecreationAreaModel
    {
        public int Id { get; set; }

        public int CostPerHour { get; set; }
        public string Name { get; set; }
        public RecreationAreaModel(recreation_area rec)
        {
            Id = rec.recreation_area_id;
            CostPerHour = rec.cost_in_hour;
            Name = rec.Name;
        }
    }
}
