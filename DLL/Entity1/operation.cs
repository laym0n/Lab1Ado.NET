namespace DLL.Entity1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("operation")]
    public partial class operation
    {
        [Key]
        public int operation_id { get; set; }

        public int recreation_area_id { get; set; }

        public int bracelet_id { get; set; }

        public int sum { get; set; }

        public DateTime time { get; set; }

        public virtual bracelet bracelet { get; set; }

        public virtual recreation_area recreation_area { get; set; }
    }
}
