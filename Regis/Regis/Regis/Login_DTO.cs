using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regis
{
    public class Login_DTO
    {
        private string user;
        public string User
        {
            get { return user; }
            set { user = value; }
        }
        private string pass;
        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }
        
    }
}
