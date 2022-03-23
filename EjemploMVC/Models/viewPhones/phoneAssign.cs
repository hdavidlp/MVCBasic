using EjemploMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EjemploMVC.Models.viewPhones
{
    public class phoneAssign
    {
        public phone selectedPhone { get; set; }
        public List<ListClientesViewModel> clients = new List<ListClientesViewModel>();
        public long idSelectedClient { get; set; }
    }
}