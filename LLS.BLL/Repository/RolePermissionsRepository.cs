using LLS.DAL;
using LLS.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LLS.BLL.Repository
{
    public class RolePermissionsRepository : Repository<RolePermissions>
    {
        public LLSDBContext Ctx { get; }
        public RolePermissionsRepository(LLSDBContext context) : base(context)
        {
            Ctx = context;
        }
    }
}