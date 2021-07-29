using LLS.CommonDefinitions.Enum;
using LLS.CommonDefinitions.Model;
using LLS.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LLS.BLL.Services
{
    public class userService
    {
        public unitOfWork unitOfWork { get; set; }
        public userService(unitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<GenericResult<List<User>>> GetUsers(User user)
        {
            var result = new GenericResult<List<User>>();

            var users = await unitOfWork.userRepository.GetAllAsync();

            if (users != null)
            {
                result.Data = users;
                result.Status = ResultStatusEnum.Succeeded;
            }
            else
            {
                result.Message = "Some Thing went Wrong ";

                result.Status = ResultStatusEnum.Failed;
            }

            return result;
        }


        public async Task<GenericResult<string>> Create(User user)
        {
            var result = new GenericResult<String>();
            string id = Ulid.NewUlid().ToString();
            user.id = id;
            var newUser = await unitOfWork.userRepository.AddOrEditUser(user);
            var createdUser = unitOfWork.userRepository.AddAsync(newUser);
            if (createdUser != null)
            {
                result.Data = id;
                result.Message = "User Added Successfully";
                result.Status = ResultStatusEnum.Succeeded;
            }
            else
            {
                result.Message = "Some Thing went Wrong ";

                result.Status = ResultStatusEnum.Failed;
            }
            return result;
        }
        public async Task<GenericResult<bool>> Delete(string userId)
        {
            var result = new GenericResult<bool>();
            try
            {
                var olduser = await unitOfWork.userRepository.FirstOrDefaultAsync(e => e.id == userId);
                var user = unitOfWork.userRepository.Remove(olduser);
                if (user != null)
                {
                    result.Message = "User Deleted Successfully";
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

        public async Task<GenericResult<User>> Edit(User user)
        {
            var result = new GenericResult<User>();
            var oldUser = await unitOfWork.userRepository.FirstOrDefaultAsync(e => e.id == user.id);
            var newuser = await unitOfWork.userRepository.AddOrEditUser(user, oldUser);
            var editedUser = unitOfWork.userRepository.Update(newuser);

            if (editedUser != null)
            {
                result.Data = editedUser;
                result.Message = "User Modified  Successfully";
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
