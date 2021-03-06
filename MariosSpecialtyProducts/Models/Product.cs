﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MariosSpecialtyProducts.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter the product's name.")]
        public string Name { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public double Cost { get; set; }

        [Required(ErrorMessage = "Please enter the product's country of origin.")]
        public string CountryOfOrigin { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public override bool Equals(System.Object otherProduct)
        {
            if (!(otherProduct is Product))
            {
                return false;
            }
            else
            {
                Product newProduct = (Product)otherProduct;
                return this.ProductId.Equals(newProduct.ProductId);

            }
        }

        public override int GetHashCode()
        {

            return this.ProductId.GetHashCode();
        }

        public static void DeleteAll()
        {
            MariosSpecialtyProductsContext db = new MariosSpecialtyProductsContext();
            db.Products.RemoveRange(db.Products.ToList());

            db.SaveChanges();
        }

    }
}
