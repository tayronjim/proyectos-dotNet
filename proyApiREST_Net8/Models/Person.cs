using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace proyApiREST_Net8.Models
{
    public class Person
    {
        [Key]
        public int id {get;set;}
        public required string name {get;set;}
        public required int age {get;set;}
    }
}