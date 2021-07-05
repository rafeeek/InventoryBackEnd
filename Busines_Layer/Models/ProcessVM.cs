using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busines_Layer.Models
{
    public class ProcessVM
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string CstName { get; set; }
        public string ProcessType { get; set; }
    }
}
