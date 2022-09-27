using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcomerce.Shared.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } =String.Empty;
        public string URL { get; set; } =String.Empty;

    }
}
