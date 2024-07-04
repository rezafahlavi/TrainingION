using BusinessServiceFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingDomainModel;

namespace BusinessService
{

    public class UserService : BaseService <DomainRepository<User>,User>
    {
        public UserService() : base()
        { 
        
        }

        public void InsertUser()
        {
            var user = new User();

            this.Insert(user);
            this.Update(user);
        }
    }
}
