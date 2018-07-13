using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace entityLianXi.Models
{

    //数据库上下文，生成数据库操作数据库（对数据进行增删改查）
    public class ProductEntity:DbContext
    {
        //构造函数 默认Web.config中的数据库链接要和当前上下文类的名称相同也就是ProductEntity，想要更换名称的时候可以在当前的构造函数
        //中继承base("conStr")中重新命名
        //public ProductEntity() : base("conStr")
        //{
        //    //model改变的时候就删除原数据库重新创建新数据库，但是数据库中的数据就没有了
        //    Database.SetInitializer<ProductEntity>(new DropCreateDatabaseIfModelChanges<ProductEntity>());
        //}


        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Order> Order { get; set; }


        ////修改关系表的表名称，和外键列名称
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    t.ord product表中的导航属性   a.Opro order表中的导航属性
        //    modelBuilder.Entity<Product>().HasMany(t => t.ord).WithMany(a => a.Opro).Map(m =>
        //    {
        //        m.ToTable("ProAndOrd");
        //        m.MapLeftKey("productId");
        //        m.MapRightKey("orderId");
        //    });
        //}
    }
}