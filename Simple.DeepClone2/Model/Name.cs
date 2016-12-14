using System;
using System.Collections.Generic;

namespace Model
{
    public class Name
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Name()
        {
            
        }
        public Name(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
