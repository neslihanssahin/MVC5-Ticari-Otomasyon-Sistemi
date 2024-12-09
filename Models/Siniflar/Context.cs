using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace MvcOnlineTİcariOtomasyon.Models.Siniflar
{
    public class Context:DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Cari> Caris { get; set; }
        public DbSet<Departman> Departmans{ get; set; }
        public DbSet<FaturaKalem> FaturaKalems { get; set; }
        public DbSet<Faturalar> Faturalars{ get; set; }
        public DbSet<Gider> Giders{ get; set; }
        public DbSet<Kategori> Kategoris{ get; set; }
        public DbSet<Personel> Personels{ get; set; }
        public DbSet<SatisHareket> SatisHarekets{ get; set; }
        public DbSet<Urun> Uruns{ get; set; }
        public DbSet<Detay> Detays { get; set; }

    }
}