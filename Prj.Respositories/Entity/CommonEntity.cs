using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Respositories.Entity
{
    public abstract class LogsDateEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
    public abstract class InfoPageEntity
    {
        public int Count { get; set; }
        public long PageIndex { get; set; }
        public long PageSize { get; set; }
        public long PageTotal { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
