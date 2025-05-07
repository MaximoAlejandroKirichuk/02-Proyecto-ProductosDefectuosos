using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ProductosDefectuosos
{
    public class usuario
    {
        private string fullname;

        public string Fullname
        {
            get { return fullname; }
            set { fullname = value; }
        }

        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string mail;

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public usuario(string fullName, string username, string mail, string password)
        {
            Fullname = fullName;
            Username = username;
            Mail = mail;
            Password = password;
        }

        public override string ToString()
        {
            return $"{Fullname},{Username},{Mail},{Password}";
        }

    }
}
