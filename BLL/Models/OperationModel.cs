using DLL.EF;
using DLL.Entity1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class OperationModel
    {
        public int Id { get; set; }

        public int RecreationAreaId { get; set; }

        public int BraceletId { get; set; }

        public int sum { get; set; }

        public DateTime time { get; set; }
        public OperationModel(operation op)
        {
            Id = op.operation_id;
            RecreationAreaId = op.recreation_area_id;
            BraceletId = op.bracelet_id;
            sum = op.sum;
            time = op.time;
        }
        public OperationModel() { }
        //public operation MakeOperation(bracelet br, recreation_area recarea)
        //{
        //    return new operation() { operation_id = Id, bracelet_id = BraceletId, sum = this.sum, time = this.time, recreation_area_id = RecreationAreaId, bracelet = br, recreation_area = recarea };
        //}
    }
}
