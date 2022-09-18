using System;
using System.Collections.Generic;
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
        public decimal Price { get; set; }

    }

}
