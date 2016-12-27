using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Respositories.Entity
{
    [TableName("Department")]
    [PrimaryKey("Id", autoIncrement = true)] // thêm khóa chính để câu lệnh insert trả về ID hiện có của User
    public class DepartmentEntity : LogsDateEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }


}
