using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC2.Models
{
    public class Gamer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Score { get; set; }
        public int GameMoney { get; set; }
        public int Age { get; set; }

        public Gamer()
        {
            Id = 0;
            Name = string.Empty;
            Gender = string.Empty;
            Score = 0;
            GameMoney = 0;
            Age = 0;
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