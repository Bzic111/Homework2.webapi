using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework2.webapi.Classes
{
    public class Employe
    {
        public string Name { get; private set; }
        public int Id { get; private set; }
        public Employe(string name,int id)
        {
            Name = name;
            Id = id;
        }
    }
}
