using Restaurant.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Entity.Model
{
    public class RestaurantDBContext : DbContext
    {
        public RestaurantDBContext() : base("Rest")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<About> Abouts { get; set; }

        public DbSet<ContactInformation> ContactInformations { get; set; }

        public DbSet<ContactMail> ContactMails { get; set; }

        public DbSet<HealtyEat> HealtyEats { get; set; }

        public DbSet<MainGoogleSeo> MainGoogleSeos { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<ProductFile> ProductFiles { get; set; }

        public DbSet<RestaurantBusines> RestaurantBusinesses { get; set; }

        public DbSet<Slider> Sliders { get; set; }

        public DbSet<SocialMedia> SocialMedias { get; set; }

        public DbSet<SSS> SSS { get; set; }

        public DbSet<UserMember> UserMembers { get; set; }

        public DbSet<ConstantValue> ConstantValues { get; set; }
        public DbSet<News> News { get; set; }

        public DbSet<Video> Videos { get; set; }

        public DbSet<InformationMail> InformationMails { get; set; }

        public DbSet<BasindaBiz> BasindaBizs { get; set; }
        public DbSet<Flavors> flavorss { get; set; }

        public DbSet<HumanResources> HumanResourcess { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
