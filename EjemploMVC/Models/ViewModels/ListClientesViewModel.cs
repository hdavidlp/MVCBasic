using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EjemploMVC.Models.ViewModels
{
    public class ListClientesViewModel
    {
        public long idCliente { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string correo { get; set; }
    }
}