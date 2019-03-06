using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Design;

namespace TableFootball.Models
{
    public class Player
    {
        [Key]
        public int Id       { get; set; }
        public int Points   { get; set; }
        public int Games    { get; set; }
        public string Name  { get; set; }
        public string AvatarUrl { get; set; }
    }
}
