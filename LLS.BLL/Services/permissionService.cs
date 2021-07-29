using LLS.CommonDefinitions.Dto;
using LLS.CommonDefinitions.Enum;
using LLS.CommonDefinitions.Model;
using LLS.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLS.BLL.Services
{
    public class permissionService
    {
        public unitOfWork unitOfWork { get; set; }
        public permissionService(unitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<GenericResult<List<Permission>>> GetAllPermissions(Permission permission)
        {
            var result = new GenericResult<List<Permission>>();

            var permissions = await unitOfWork.permissionRepository.GetAllAsync();

            if (permissions != null)
            {
                result.Data = permissions;
                result.Status = ResultStatusEnum.Succeeded;
            }
            else
            {
                result.Message = "Some Thing went Wrong ";

                result.Status = ResultStatusEnum.Failed;
            }

            return result;
        }

        public GenericResult<PermissionDto> GetPermissionWithRoles(string id)
        {
            var result = new GenericResult<PermissionDto>();

            var Permission = unitOfWork.permissionRepository.GetPermisionWithRoles(id);

            if (Permission != null)
            {
                result.Data = Permission;
                result.Status = ResultStatusEnum.Succeeded;
            }
            else
            {
                result.Message = "Some Thing went Wrong ";

                result.Status = ResultStatusEnum.Failed;
            }

            return result;
        }


        //public async Task<GenericResult<string>> Create(PermissionDto permission)
        //{
        //    var result = new GenericResult<String>();
        //    string id = Ulid.NewUlid().ToString();
        //    var newPermission = await unitOfWork.permissionRepository.AddOrEditPermission(permission);
        //    newPermission.id = id;
        //    var createdPermission = unitOfWork.permissionRepository.AddAsync(newPermission);
        //    if (createdPermission != null)
        //    {
        //        result.Data = id;
        //        result.Message = "Permission Added Successfully";
        //        result.Status = ResultStatusEnum.Succeeded;
        //    }
        //    else
        //    {
        //        result.Message = "Some Thing went Wrong ";

        //        result.Status = ResultStatusEnum.Failed;
        //    }
        //    return result;
        //}
        public async Task<GenericResult<bool>> Delete(string permissionId)
        {
            var result = new GenericResult<bool>();
            try
            {
                var oldpermission = await unitOfWork.permissionRepository.FirstOrDefaultAsync(e => e.id == permissionId);
                var permission = unitOfWork.permissionRepository.Remove(oldpermission);
                if (permission != null)
                {
                    var rp = unitOfWork.RolePermissionsRepository.GetAllById(e => (e.permissionId == permissionId));
                    unitOfWork.RolePermissionsRepository.RemoveRange(rp);

                    result.Message = "Permission Deleted Successfully";
                    result.Status = ResultStatusEnum.Succeeded;
                }
                else
                {
                    result.Message = "Some Thing went Wrong ";

                    result.Status = ResultStatusEnum.Failed;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Some Thing went Wrong");
            }

            return result;
        }

        public async Task<GenericResult<Permission>> Edit(PermissionDto permission)
        {
            var result = new GenericResult<Permission>();
            var oldPermission = await unitOfWork.permissionRepository.FirstOrDefaultAsync(e => e.id == permission.id);
            var newpermission = await unitOfWork.permissionRepository.AddOrEditPermission(permission, oldPermission);
            var editedPermission = unitOfWork.permissionRepository.Update(newpermission);

            if (editedPermission != null)
            {

                var rp = unitOfWork.RolePermissionsRepository.GetAllById(e => (e.permissionId == permission.id && !permission.roles.Contains(e.roleId)));
                unitOfWork.RolePermissionsRepository.RemoveRange(rp);
                var rpExist = unitOfWork.RolePermissionsRepository.GetAllById(e => e.permissionId == permission.id).Select(e => e.roleId);
                permission.roles.ForEach(e =>
                {
                    if (!rpExist.Contains(e))
                    {
                        var p = new RolePermissions() { permissionId = permission.id, roleId = e };
                        unitOfWork.RolePermissionsRepository.AddAsync(p);
                    }

                });


                result.Data = editedPermission;
                result.Message = "Permission Modified  Successfully";
                result.Status = ResultStatusEnum.Succeeded;

            }
            else
            {
                result.Message = "Some Thing went Wrong ";

                result.Status = ResultStatusEnum.Failed;
            }

            return result;
        }



    }
}
