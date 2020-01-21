using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Bu hissə məcburidir")]
        [MaxLength(100, ErrorMessage = "Maksimum 100 xarakter ola bilər")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bu hissə məcburidir")]
        [MaxLength(1000, ErrorMessage ="Maksimum 1000 xarakter ola bilər")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Bu hissə məcburidir")]
        public double Price { get; set; }
    }
}
