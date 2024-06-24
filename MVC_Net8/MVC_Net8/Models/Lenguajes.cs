using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Net8.Models
{
    public class Lenguajes
    {
        [Key]
        [Column("id")]
        public int id {get; set;}
        public string? nombre {get; set;}
        public DateTime? fecha {get; set;}
        public int? nivel {get;set;}
    }
}