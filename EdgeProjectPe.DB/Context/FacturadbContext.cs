using System;
using System.Collections.Generic;
using EdgeProjectPe.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace EdgeProjectPe.DB.Context;

public class FacturadbContext : DbContext
{
    public FacturadbContext(DbContextOptions<FacturadbContext> options) : base(options)
    {

    }
    public FacturadbContext()
    {

    }
    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Parameter> Parameters { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Saleinvoice> Saleinvoices { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Usertype> Usertypes { get; set; }

}