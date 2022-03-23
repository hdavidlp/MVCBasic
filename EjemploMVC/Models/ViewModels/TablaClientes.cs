using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EjemploMVC.Models.ViewModels
{
    public class TablaClientes
    {
        
        public long idCliente { get; set; }

        // Validation Rules apply for .Net framework
        // This line is used in .Net Framework to establish auto check 
        // for required fields, also you can custom the error message
        
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(50)]
        [Display(Name ="Nombre")]
        public string nombre { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Apellidos")]
        public string apellidos { get; set; }
        [Required]
        [StringLength(50)]
        [EmailAddress]
        [Display(Name = "Correo")]
        public string correo { get; set; }
    }
}