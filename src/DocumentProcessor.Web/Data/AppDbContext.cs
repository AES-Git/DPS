using Microsoft.EntityFrameworkCore;
using DocumentProcessor.Web.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System;

namespace DocumentProcessor.Web.Data;

public class AppDbContext : DbContext
{
    static AppDbContext()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Document> Documents { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        // Apply schema mappings for Document entity
        mb.Entity<Document>().ToTable("documents", "public");
        
        // Apply HasConversion for boolean properties
        mb.Entity<Document>().Property(d => d.IsDeleted).HasConversion<int>();
        
        // Preserve existing query filter
        mb.Entity<Document>().HasQueryFilter(d => !d.IsDeleted);
    }
}
