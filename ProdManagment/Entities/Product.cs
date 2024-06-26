﻿using ProdManagment.Entities;
using System.ComponentModel.DataAnnotations;

namespace ProdManagment.Entity
{
    public class Product
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public int PackageId { get; set; }
        public Package Package { get; set; }
        public string Description { get; set; }
    }
}
