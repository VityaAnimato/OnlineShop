﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Db.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }

        public List<Image> Images { get; set; }


        public Product()
        {
            Images = new List<Image>();
        }

        public Product(Guid id, string name, decimal cost, string description) : this()
        {
            Id = id;
            Name = name;
            Cost = cost;
            Description = description;
        }
    } 
}
