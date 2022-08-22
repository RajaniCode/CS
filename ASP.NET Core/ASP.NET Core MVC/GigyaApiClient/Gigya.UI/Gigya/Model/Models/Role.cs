using System;
using System.Collections.Generic;
using System.Linq;


namespace Gigya.Model.Models
{
    [Serializable]
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string MarketoRoleName { get; set; }

        // public IList<Permission> Permissions { get; set; }

        public List<Permission> Permissions { get; set; }

        public string ResourceName { get; set; }

        public Role(RoleSerializeModel model)
        {
            Id = model.Id;
            Name = model.N;
            Permissions = model.P.Select(p => new Permission
            {
                Id = p.Id,
            }).ToList();
            ResourceName = model.R;
        }

        public Role() { }
    }

    [Serializable]
    public class RoleSerializeModel
    {
        //rolRowId
        public int Id { get; set; }

        //rolName
        public string N { get; set; }

        //Permissions
        public IList<PermissionSerializeModel> P { get; set; }

        //ResourceId
        public string R { get; set; }
    }

}
