using LLS.DAL;
using LLS.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LLS.BLL.Repository
{
    public class userRepository : Repository<User>
    {
        public LLSDBContext Ctx { get; }
        public userRepository(LLSDBContext context) : base(context)
        {
            Ctx = context;
        }

        public async Task<User> AddOrEditUser(User user, User newUser = null)
        {
            var isEdit = true;
            if (newUser == null)
            {
                isEdit = false;
                newUser = new User();
            }

            newUser.firstname = user.firstname;
            newUser.lastname = user.lastname;

            return newUser;
        }




    }
}
