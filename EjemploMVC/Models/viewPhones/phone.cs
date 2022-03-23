using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EjemploMVC.Models.viewPhones
{
    public class phone
    {
        public int idPhone { get; set; }

        [Display (Name ="phone number")]
        public string phone_Numer { get; set; }

        [Display (Name ="Company name")]
        public string company { get; set; }

        [Display (Name ="Creation Date")]
        [DataType (DataType.Date)]
        [DisplayFormat (DataFormatString ="{0:dd/MM/YYYY}",ApplyFormatInEditMode =true)]
        public DateTime creation_Date { get; set; }

        [Display (Name ="Is assign?")]
        public bool assign { get; set; }


    }
}