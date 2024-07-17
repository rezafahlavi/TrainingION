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
        public void ManageUserDetail(User user) 
        {
            if (user.UserID > 0)
            {
                user.UserDetail.CreatedDate = DateTime.Now;
                user.UserDetail// tambah
                this._context.Entry(user.UserDetail).State = EntityState.Modified;
            }
            else
            {
                this._context.Entry(user.UserDetail).State = EntityState.Added;
            }
        }
    }
}
