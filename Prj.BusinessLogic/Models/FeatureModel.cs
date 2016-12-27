using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.BusinessLogic.Models
{
   public class FeatureModel : LogsDateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int GroupPageId { get; set; }
    }
    public class FeatureListModel : InfoPageModel
    {
        public FeatureListModel()
        {
            List = new List<FeatureModel>();
        }
        public List<FeatureModel> List { get; set; }
    }
}
