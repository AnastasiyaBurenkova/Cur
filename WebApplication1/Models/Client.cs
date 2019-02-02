using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Client
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateBirth { get; set; }
        public string Gender { get; set; }
        public string passportID { get; set; }
        public string Phone { get; set; }

        public ICollection<Contract> Contracts { get; set; }
        public Client()
        {
            Contracts = new List<Contract>();
        }
    }
}