using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using entityStudent.Models;

namespace entityStudent.Models
{
    //上下文类
    public class conEntity:DbContext
    {
        public DbSet<student> student { get; set; }
        public DbSet<Grad> grad { get; set; }
    }
}