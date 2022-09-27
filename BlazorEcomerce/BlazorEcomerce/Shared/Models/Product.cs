using BlazorEcomerce.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazroEcomerce.Shared.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }=String.Empty;
        public string Description { get; set; }=String.Empty;

        public string ImgURL { get; set; } = String.Empty;
        [Column(TypeName="decimal(18,2)")]
        public decimal Price { get; set; }
        public Category? category { get; set; }  
        public int CategoryId { get; set; }   

    }

}
