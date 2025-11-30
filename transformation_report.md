# SQL Schema Qualification Transformation Report

## File Processed: src/DocumentProcessor.Web/Program.cs

**Result:** No raw SQL queries found in the file requiring schema qualification.

### Analysis:
- The file primarily contains application startup and configuration code
- Database connection is configured using EF Core's UseNpgsql method
- No SqlQueryRaw, ExecuteSqlRaw, FromSqlRaw, or other raw SQL queries found
- The application is already configured for PostgreSQL

### Related Files Examined:
- src/DocumentProcessor.Web/Data/AppDbContext.cs
  - Already configured with schema qualification: `mb.Entity<Document>().ToTable("documents", "public")`
- src/DocumentProcessor.Web/Services/DocumentProcessingService.cs
  - Uses EF Core API for data access, no raw SQL

### Conclusion:
No schema qualification transformations were required for Program.cs or related files.
