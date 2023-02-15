using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Db.Models
{
    public class OrderUserData : ICloneable
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }    
        public string Address { get; set; }
        public string Phone { get; set; }


        public object Clone()
        {
            return new OrderUserData
            {
                FullName = string.Copy(FullName), 
                Address = string.Copy(Address),
                Phone = string.Copy(Phone)
            };
        }
    }

}
