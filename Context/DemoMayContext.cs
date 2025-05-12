using System;
using System.Collections.Generic;
using Demomay.Models;
using Microsoft.EntityFrameworkCore;

namespace Demomay.Context;

public partial class DemoMayContext : DbContext
{
    public DemoMayContext()
    {
    }

    public DemoMayContext(DbContextOptions<DemoMayContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<PartnerType> PartnerTypes { get; set; }

    public virtual DbSet<PartnersProduct> PartnersProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Port=5432;Host=localhost;Username=postgres;Password=6274;Database=DemoMay");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("partners_pkey");

            entity.ToTable("partners");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasColumnType("character varying")
                .HasColumnName("address");
            entity.Property(e => e.Director)
                .HasColumnType("character varying")
                .HasColumnName("director");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.Inn)
                .HasColumnType("character varying")
                .HasColumnName("inn");
            entity.Property(e => e.Partnername)
                .HasColumnType("character varying")
                .HasColumnName("partnername");
            entity.Property(e => e.Partnertypeid).HasColumnName("partnertypeid");
            entity.Property(e => e.PhoneNumber)
                .HasColumnType("character varying")
                .HasColumnName("phone_number");
            entity.Property(e => e.Rating).HasColumnName("rating");

            entity.HasOne(d => d.Partnertype).WithMany(p => p.Partners)
                .HasForeignKey(d => d.Partnertypeid)
                .HasConstraintName("partners_partnertypeid_fkey");
        });

        modelBuilder.Entity<PartnerType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("partner_types_pkey");

            entity.ToTable("partner_types");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.PartnertypeName)
                .HasColumnType("character varying")
                .HasColumnName("partnertype_name");
        });

        modelBuilder.Entity<PartnersProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("partners_products_pkey");

            entity.ToTable("partners_products");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Kolvoproduction).HasColumnName("kolvoproduction");
            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.PoductArticlenumber).HasColumnName("poduct_articlenumber");
            entity.Property(e => e.Saledate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("saledate");

            entity.HasOne(d => d.Partner).WithMany(p => p.PartnersProducts)
                .HasForeignKey(d => d.PartnerId)
                .HasConstraintName("partners_products_partner_id_fkey");

            entity.HasOne(d => d.PoductArticlenumberNavigation).WithMany(p => p.PartnersProducts)
                .HasForeignKey(d => d.PoductArticlenumber)
                .HasConstraintName("partners_products_poduct_articlenumber_fkey");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Article).HasName("products_pkey");

            entity.ToTable("products");

            entity.Property(e => e.Article)
                .ValueGeneratedNever()
                .HasColumnName("article");
            entity.Property(e => e.Maxcostforpartner).HasColumnName("maxcostforpartner");
            entity.Property(e => e.Productiontypeid).HasColumnName("productiontypeid");
            entity.Property(e => e.Productname)
                .HasColumnType("character varying")
                .HasColumnName("productname");

            entity.HasOne(d => d.Productiontype).WithMany(p => p.Products)
                .HasForeignKey(d => d.Productiontypeid)
                .HasConstraintName("products_productiontypeid_fkey");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_types_pkey");

            entity.ToTable("product_types");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Koefficient).HasColumnName("koefficient");
            entity.Property(e => e.ProducttypeName)
                .HasColumnType("character varying")
                .HasColumnName("producttype_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
