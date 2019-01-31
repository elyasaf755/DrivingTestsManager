using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Permisson
    {
        //Properties
        public AccessLevelEnum AccessLevel { get; set; }
        public string Id { get; set; }
        public string Password { get; set; }

        //Constructors
        public Permisson(AccessLevelEnum accessLevel, string id, string password)
        {
            AccessLevel = accessLevel;
            Id = id;
            Password = password;
        }
        public Permisson()
        {

        }

        //Overrides
        public override bool Equals(object obj)
        {
            var permisson = obj as Permisson;
            return permisson != null &&
                   AccessLevel == permisson.AccessLevel &&
                   Id == permisson.Id &&
                   Password == permisson.Password;
        }
        public override int GetHashCode()
        {
            var hashCode = -1857862541;
            hashCode = hashCode * -1521134295 + AccessLevel.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Password);
            return hashCode;
        }
    }
}
