using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busines_Layer.Models
{
    public class InventoryProcVM
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Cost { get; set; }
        public int Count { get; set; }
        public int ProcessId { get; set; }
        public int GoodsId { get; set; }


        public string CstName { get; set; }
        public string ProcessType { get; set; }
        public string GoodsName { get; set; }
    }
}
