using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC2.Models
{
    public class FormBoard
    {
        [Key]
        public int FormID { get; set; }
        public string FormNo { get; set; }
        public string Subject { get; set; }

        public FormBoard()
        {

            FormNo = string.Empty;
            Subject = string.Empty;
            FormID = 0;
        }

        public FormBoard(int _id, string _name, string _score)
        {
            FormID = _id;
            FormNo = _name;
            Subject = _score;
        }

        public override string ToString()
        {
            return $"學號:{FormID}, 姓名:{FormNo}, 分數:{Subject}.";
        }
    }
}