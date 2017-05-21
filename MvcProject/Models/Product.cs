﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcProject.Models
{
    public enum State
    {
        ForSale,
        ShoppingCart,
            Sold
    }
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }
        [ForeignKey("Owner")]
        public int? OwnerId { get; set; }
        [Display(Name = "כותרת")]
        [Required(ErrorMessage = "Please enter a Title")]
        [StringLength(50)]
        public string Title { get; set; }
        [Display(Name = "תאור קצר")]
        [Required(ErrorMessage = "Please enter a Short Description")]
        [StringLength(500)]
        public string ShortDescription { get; set; }
        [Display(Name = "תאור ארוך")]
        [Required(ErrorMessage = "Please enter a Long Description")]
        [StringLength(4000)]
        public string LongDescription { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Range(0.01,50000)]
        [Display(Name = "מחיר")]
        [Required]
        public decimal Price { get; set; }
     
        public byte[] picture1 { get; set; }
        public byte[] picture2 { get; set; }
        public byte[] picture3 { get; set; }
        [Required]
        public  State Status{ get; set; }
        [NotMapped]
        public bool IsInCart { get; set; }
        public virtual User User { get; set; }
        public virtual User Owner { get; set; }
    }
}
      