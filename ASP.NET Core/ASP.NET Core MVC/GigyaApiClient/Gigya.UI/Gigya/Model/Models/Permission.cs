using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gigya.Model.Models
{
    [Serializable]
    public class Permission
    {
        public int Id { get; set; }

        public Permission(PermissionSerializeModel model)
        {
            Id = model.Id;
        }

        public Permission()
        {
        }
    }

    [Serializable]
    public class PermissionSerializeModel
    {
        //perRowId
        public int Id { get; set; }
    }

}
