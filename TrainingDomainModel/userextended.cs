using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingDomainModel
{
    public partial class User
    {
        public string UserNamePhone 
        {
            get 
            {
                return this.UserDetail != null ? this.UserDetail.FullName + " " + this.UserDetail.Phone : "";

            }
        
        }
    }
}
