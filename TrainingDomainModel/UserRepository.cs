using DomainModelFramework;
using DomainModelFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;


namespace TrainingDomainModel
{
    public class UserRepository : DomainRepository<User> 
    {
        public UserRepository()
        {
        }
        public void DeleteUserDetail(User user)
        {
            this._context.Entry(user.UserDetail).State = EntityState.Deleted;
        }

        public void ManageUserDetail(User user) 
        {
            if (user.UserID > 0)
            {
                user.UserDetail.ModifiedDate = DateTime.Now;
                user.UserDetail.ModifiedBy = 0;
                this._context.Entry(user.UserDetail).State = EntityState.Modified;
            }
            else
            {
                user.UserDetail.CreatedDate = DateTime.Now;
                user.UserDetail.CreatedBy = 0;
                user.UserDetail.ModifiedDate = DateTime.Now;
                user.UserDetail.ModifiedBy= 0;
                this._context.Entry(user.UserDetail).State = EntityState.Added;
            }
        }
    }
}
