using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.DTO
{
    public class HotelDTO
    {        
        public virtual int Id { get; set; }        
        public virtual string Name { get; set; }        
        public virtual HotelChainDTO HotelChain { get; set; }        
        public virtual string Address1 { get; set; }
        public virtual string Address2 { get; set; }
        public virtual string Address3 { get; set; }
        public virtual string Address4 { get; set; }
        public virtual string Address5 { get; set; }
        public virtual bool InOperation { get; set; }
    }
}