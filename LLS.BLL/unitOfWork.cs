using LLS.BLL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace LLS.BLL
{
    public class unitOfWork
    {
        public userRepository userRepository { get; set; }
        public roleRepository roleRepository { get; set; }
        public permissionRepository permissionRepository { get; set; }
        public RolePermissionsRepository RolePermissionsRepository { get; set; }
        public unitOfWork(userRepository userRepo, roleRepository roleRepo, permissionRepository permissionRepo, RolePermissionsRepository RolePermissionsRepo)
        {
            userRepository = userRepo;
            roleRepository = roleRepo;
            permissionRepository = permissionRepo;
            RolePermissionsRepository = RolePermissionsRepo;
        }
    }
}
