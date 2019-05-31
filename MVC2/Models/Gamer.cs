using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC2.Models
{
    public class Gamer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Column("Gender")]
        [Display(Name = "Gender")]
        [StringLength(50)]
        public string Gender { get; set; }
        public int Score { get; set; }
        public int GameMoney { get; set; }
        public int Age { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "RegisteredDate")]
        public DateTime RegisteredDate { get; set; }

        public Gamer()
        {
            Id = 0;
            Name = string.Empty;
            Gender = string.Empty;
            Score = 0;
            GameMoney = 0;
            Age = 0;
            RegisteredDate = DateTime.Parse("1900-01-01 00:00:00.000");
        }

        //public Gamer(int _id, string _name, string _score)
        //{
        //    Id = _id;
        //    Name = _name;
        //    Gender = _score;
        //}
        //public override string ToString()
        //{
        //    return $"學號:{id}, 姓名:{name}, 分數:{score}.";
        //}
    }
}