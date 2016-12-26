using Prj.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.BusinessLogic.Models
{
   public class CommonModel
    {

    }

    public abstract class LogsDateModel
    {
        private DateTime SetCreatedDate = DateHandler.UtcNow();
        private DateTime SetModifiedDate = DateHandler.UtcNow();
        public DateTime CreatedDate { get { return this.SetCreatedDate; } set { this.SetCreatedDate = DateHandler.UtcNow(); } }
        public DateTime ModifiedDate { get { return this.SetModifiedDate; } set { this.SetModifiedDate = DateHandler.UtcNow(); } }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
    public class InfoPageModel
    {
        public int Count { get; set; }
        public long PageIndex { get; set; }
        public long PageSize { get; set; }
        public long PageTotal { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
