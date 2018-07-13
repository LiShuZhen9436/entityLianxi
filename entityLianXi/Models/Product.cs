using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace entityLianXi.Models
{
    [Table("Pro")]//修改数据库中生成的表的名称加Pro
    public class Product
    {
        [Key]
        public int Pid { get; set; }

       [Required(ErrorMessage ="商品名不能为空！")]//使用Required确认为必须是必填项(非空) mvc验证 
        public string PName { get; set; }

        //在声明类型时加上？号表示可以为空
        [Range(1,100,ErrorMessage ="价格只能在1-100之间")]
        public int? Pice { get; set; }

        //[StringLength(550)]//也可以进行长度限制
        [MaxLength(2,ErrorMessage ="输入的商品简介过长！")]//使用MaxLength可以限制最大长度
        public string Detail { get; set; }

        [NotMapped]//被此特性修饰时该属性不在数据库中生成
        public int Counts { get; set; }

        //外键
        //public int Cid { get; set; }//当这个属性名和关联表中的主键名称相同时会自动识别为外键，当当前属性名和关联表中的主键名不一致时需要在上面加foreignkey

#region 一对多
        //[ForeignKey("Cat")]//cat导航属性，表示为Category表的外键
        //public int CatId { get; set; }

        ////virtual延迟加载，只有加了virtual在view视图中才可以通过item.Cat.CName获取外键表中的属性
        //public virtual Category Cat { get; set; }//Category导航属性(种类类别的导航属性)
        #endregion

#region 多对多
        //[ForeignKey("ord")]
        //public int Oid { get; set; }
        //public virtual List<Order> ord { get; set; }
#endregion

    }
}