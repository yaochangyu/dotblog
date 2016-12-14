using System;
using System.Collections.Generic;
using System.Text;


namespace Model
{
    public class Person
    {
        public int Age { get; set; }
        public string Address { get; set; }
        public Name Name { get; set; }

        private List<string> _phones = new List<string>();
        public List<string> Phones
        {
            get { return this._phones; }
            set { this._phones = value; }
        }

        public Person Clone()
        {
            return this.MemberwiseClone() as Person;
        }
    }
}
