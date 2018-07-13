using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace entityLianXi.Models
{
    //种类类别
    public class Category
    {
        [Key]
        public int Cid { get; set; }

        [StringLength(50)]
        public string CName { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}