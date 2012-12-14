using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace HotelManagement.ServiceApp
{    
    public class A
    {        
        public int id { get; set; }
               
        public string name { get; set; }

        public B b { get; set; }
    }

    public class B
    {
        public int mem1 { get; set; }
        public string mem2 { get; set; }
    }
}
