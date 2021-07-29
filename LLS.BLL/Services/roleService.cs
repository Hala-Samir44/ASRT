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
    public class roleService
    {
        public unitOfWork unitOfWork { get; set; }
        public roleService(unitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<GenericResult<List<Role>>> GetAllRoles(Role role)
        {
            var result = new GenericResult<List<Role>>();

            var roles = await unitOfWork.roleRepository.GetAllAsync();

            if (roles != null)
            {
                result.Data = roles;
                result.Status = ResultStatusEnum.Succeeded;
            }
            else
            {
                result.Message = "Some Thing went Wrong ";

                result.Status = ResultStatusEnum.Failed;
            }

            return result;
        }

        public GenericResult<RoleDto> GetRoleWithPermissions(string id)
        {
            var result = new GenericResult<RoleDto>();

            var role =  unitOfWork.roleRepository.GetRoleWithPermisions(id);

            if (role != null)
            {
                result.Data = role;
                result.Status = ResultStatusEnum.Succeeded;
            }
            else
            {
                result.Message = "Some Thing went Wrong ";

                result.Status = ResultStatusEnum.Failed;
            }

            return result;
        }


        public async Task<GenericResult<string>> Create(RoleDto role)
        {
                var result = new GenericResult<String>();
            try
            {
                string id = Ulid.NewUlid().ToString();
                var newRole = await unitOfWork.roleRepository.AddOrEditRole(role);
                newRole.id = id;
                var createdRole = unitOfWork.roleRepository.AddAsync(newRole);
                if (createdRole.Result != null)
                {
                    if (role.permissions != null && role.permissions.Count > 0)
                    {
                        role.permissions.ForEach(e =>
                        {
                            var p = new RolePermissions() { roleId = newRole.id, permissionId = e };
                            unitOfWork.RolePermissionsRepository.AddAsync(p);
                        });
                    }


                    result.Data = id;
                    result.Message = "Role Added Successfully";
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
                if (e.InnerException.InnerException.Message.Contains("23505"))
                {
                    result.Message = "this title already exist ";

                    result.Status = ResultStatusEnum.AlreadyExist;
                }
                else
                {

                throw new Exception();
                }
            }
            return result;
        }
        public async Task<GenericResult<bool>> Delete(string roleId)
        {
            var result = new GenericResult<bool>();
            try
            {
                var oldrole = await unitOfWork.roleRepository.FirstOrDefaultAsync(e => e.id == roleId);
                var role = unitOfWork.roleRepository.Remove(oldrole);
                if (role != null)
                {
                    var rp = unitOfWork.RolePermissionsRepository.GetAllById(e => (e.roleId == roleId));
                    unitOfWork.RolePermissionsRepository.RemoveRange(rp);

                    result.Message = "Role Deleted Successfully";
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

        public async Task<GenericResult<Role>> Edit(RoleDto role)
        {
            var result = new GenericResult<Role>();
            var oldRole = await unitOfWork.roleRepository.FirstOrDefaultAsync(e => e.id == role.id);
            var newrole = await unitOfWork.roleRepository.AddOrEditRole(role, oldRole);
            var editedRole = unitOfWork.roleRepository.Update(newrole);

            if (editedRole != null)
            {

                var rp = unitOfWork.RolePermissionsRepository.GetAllById(e => (e.roleId == role.id && !role.permissions.Contains(e.permissionId)));
                unitOfWork.RolePermissionsRepository.RemoveRange(rp);
                var rpExist = unitOfWork.RolePermissionsRepository.GetAllById(e => e.roleId == role.id).Select(e => e.permissionId);
                role.permissions.ForEach(e =>
                {
                    if (!rpExist.Contains(e))
                    {
                        var p = new RolePermissions() { roleId = role.id, permissionId = e };
                        unitOfWork.RolePermissionsRepository.AddAsync(p);
                    }

                });


                result.Data = editedRole;
                result.Message = "Role Modified  Successfully";
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
