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
    public class roleRepository : Repository<Role>
    {
        public LLSDBContext Ctx { get; }
        public roleRepository(LLSDBContext context) : base(context)
        {
            Ctx = context;
        }

        public async Task<Role> AddOrEditRole(RoleDto role, Role newRole = null)
        {
            var isEdit = true;
            if (newRole == null)
            {
                isEdit = false;
                newRole = new Role();
            }

            newRole.title = role.title;
            newRole.description = role.description;

            return newRole;
        }


        public RoleDto GetRoleWithPermisions(string id)
        {
            var role = Context.Set<Role>().Where(r=>r.id==id).Include(e => e.RolePermissions);
            var roleWithPermiision = role.Select
               (r => new RoleDto
               {
                   id = r.id,
                   title = r.title,
                   description = r.description,
                   permissions = r.RolePermissions.Select(a => a.permissionId).ToList()


               }).ToList()[0];
            return roleWithPermiision;
        }

    }
}
