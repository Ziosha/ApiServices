using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiService.Models
{
    public class RolsUser
    {
        [Key]
        public int Id {get; set;}
        public int UserId {get; set;}
        public int RolsId {get; set;}

        [ForeignKey(nameof(UserId))]
        public virtual Users Users{get; set;}

        [ForeignKey(nameof(RolsId))]
        public virtual Rols Rols {get; set;}

    }
}