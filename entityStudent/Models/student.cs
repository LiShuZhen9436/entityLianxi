using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace entityStudent.Models
{
    public class student
    {
        [Key]
        public int sid { get; set; }

        [Required(ErrorMessage ="姓名不能为空！")]
        public string sName { get; set; }

        [Range(1,100,ErrorMessage ="请输入1-100之间的年龄！")]
        public int age { get; set; }

        //外键
        [ForeignKey("wGrad")]
        public int Gid { get; set; }

        //导航属性
        public virtual Grad wGrad { get; set; }

    }
}