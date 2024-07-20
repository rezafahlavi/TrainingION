using BusinessServiceFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingDomainModel;

namespace BusinessService
{

    public class UserService : BaseService <UserRepository,User>
    {
        public UserService() : base()
        { 
        
        }

        public void InsertUser(User user)
        {
            this.Insert(user);
            this.Repository.ManageUserDetail(user);
            this.Save();
        }
        public void UpdateUser(User user)
        {
            this.Update(user);
            this.Repository.ManageUserDetail(user);
            this.Save();
        }
        public void DeleteUser(User user)
        {
            this.Repository.DeleteUserDetail(user);
            this.Delete(user);
            this.Save();
        }
    }
}
