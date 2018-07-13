using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace entityStudent.Models
{
    public class Grad
    {
        [Key]
        public int Gid { get; set; }

        public string gName { get; set; }//年级名称

    }
}