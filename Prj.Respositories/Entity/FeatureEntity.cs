using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Respositories.Entity
{
    [TableName("Feature")]
    [PrimaryKey("Id", autoIncrement = true)]
    public class FeatureEntity : LogsDateEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int GroupPageId { get; set; }
    }
    // get data
    public class FeatureListEntity : InfoPageEntity
    {
        public FeatureListEntity()
        {
            List = new List<FeatureEntity>();
        }
        public List<FeatureEntity> List { get; set; }
    }
}
