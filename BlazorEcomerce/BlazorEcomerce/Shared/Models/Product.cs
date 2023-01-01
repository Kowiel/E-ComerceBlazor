using BlazorEcomerce.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazroEcomerce.Shared.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }=String.Empty;
        public string Description { get; set; }=String.Empty;

        public string ImgURL { get; set; } = String.Empty;

        public List<Image> Images { get; set; } = new List<Image>();

        public Category? category { get; set; }  
        public int CategoryId { get; set; }
        public bool Featured { get; set; } = false;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public User? User { get; set; }
        public int UserId { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set;}

        public bool Visible { get; set; } = true;
        public bool Deleted { get; set; } = false;
        [NotMapped]
        public bool Editing { get; set; } = false;
        [NotMapped]
        public bool IsNew { get; set; } = false;


    }

}
