using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EjemploMVC.Models.viewPhones
{
    public class listPhones
    {

        public int idPhone { get; set; }
        public string phone_Number { get; set; }
        public string company { get; set; }

        public DateTime creationDate { get; set; }
        public bool assign { get; set; }

    }
}