using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiService.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Username { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        
 
    }
}