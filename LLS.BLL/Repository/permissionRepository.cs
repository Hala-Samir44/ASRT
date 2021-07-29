using LLS.CommonDefinitions.Dto;
using LLS.DAL;
using LLS.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLS.BLL.Repository
{
    public class permissionRepository : Repository<Permission>
    {
        public LLSDBContext Ctx { get; }
        public permissionRepository(LLSDBContext context) : base(context)
        {
            Ctx = context;
        }

        public async Task<Permission> AddOrEditPermission(PermissionDto permission, Permission newPermission = null)
        {
            var isEdit = true;
            if (newPermission == null)
            {
                isEdit = false;
                newPermission = new Permission();
            }

            newPermission.title = permission.title;
            newPermission.description = permission.description;

            return newPermission;
        }


        public PermissionDto GetPermisionWithRoles(string id)
        {
            var Permission = Context.Set<Permission>().Where(p => p.id == id).Include(e => e.RolePermissions);
            var PermissionWithRoles = Permission.Select
               (r => new PermissionDto
               {
                   id = r.id,
                   title = r.title,
                   description = r.description,
                   roles = r.RolePermissions.Select(a => a.roleId).ToList()


               }).ToList()[0];
            return PermissionWithRoles;
        }


    }
}
