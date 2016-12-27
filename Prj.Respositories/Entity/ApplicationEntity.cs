using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Respositories.Entity
{
    [TableName("Application")]
    [PrimaryKey("Id", autoIncrement = true)] // thêm khóa chính để câu lệnh insert trả về ID hiện có của User
    public class ApplicationEntity : LogsDateEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desctiption { get; set; }
        public bool bActived { get; set; }
        public bool bDeleted { get; set; }
    }


    public class ApplicationListEntity : InfoPageEntity
    {
        public ApplicationListEntity()
        {
            List = new List<ApplicationEntity>();
        }
        public List<ApplicationEntity> List { get; set; }
    }
}
