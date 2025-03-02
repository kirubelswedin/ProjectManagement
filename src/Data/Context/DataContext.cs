using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected DataContext()
    {
    }

    public virtual DbSet<ProjectEntity> Projects { get; set; } = null!;
    public virtual DbSet<EmployeeEntity> Employees { get; set; } = null!;
    public virtual DbSet<ClientEntity> Clients { get; set; } = null!;
    public virtual DbSet<ServiceTypeEntity> ServiceTypes { get; set; } = null!;
    public virtual DbSet<StatusEntity> Statuses { get; set; } = null!;
    public virtual DbSet<ProjectEmployeeEntity> ProjectEmployees { get; set; } = null!;
    public virtual DbSet<TimeEntryEntity> TimeEntries { get; set; } = null!;
    public virtual DbSet<InvoiceEntity> Invoices { get; set; } = null!;
    public virtual DbSet<CommentEntity> Comments { get; set; } = null!;
    public virtual DbSet<DocumentEntity> Documents { get; set; } = null!;
    public virtual DbSet<DepartmentEntity> Departments { get; set; } = null!;
    public virtual DbSet<AddressEntity> Addresses { get; set; } = null!;
    public virtual DbSet<TagEntity> Tags { get; set; } = null!;
    public virtual DbSet<ProjectTagEntity> ProjectTags { get; set; } = null!;

    // Took some help from gpt to Configure the relationships between the entities
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // TimeEntry 
        modelBuilder.Entity<TimeEntryEntity>()
            .HasOne(t => t.Project)
            .WithMany(p => p.TimeEntries)
            .HasForeignKey(t => t.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TimeEntryEntity>()
            .HasOne(t => t.Employee)
            .WithMany(e => e.TimeEntries)
            .HasForeignKey(t => t.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TimeEntryEntity>()
            .HasOne(t => t.ServiceType)
            .WithMany(s => s.TimeEntries)
            .HasForeignKey(t => t.ServiceTypeId)
            .OnDelete(DeleteBehavior.Restrict);


        // ProjectNumber
        modelBuilder.Entity<ProjectEntity>()
            .HasIndex(p => p.ProjectNumber)
            .IsUnique();

        // Status relationships
        modelBuilder.Entity<StatusEntity>()
            .HasMany(s => s.Projects)
            .WithOne(p => p.Status)
            .HasForeignKey(p => p.StatusId)
            .OnDelete(DeleteBehavior.Restrict);

        // many-to-many relationships
        modelBuilder.Entity<ProjectEmployeeEntity>()
            .HasOne(pe => pe.Project)
            .WithMany(p => p.ProjectEmployees)
            .HasForeignKey(pe => pe.ProjectId);

        modelBuilder.Entity<ProjectEmployeeEntity>()
            .HasOne(pe => pe.Employee)
            .WithMany(e => e.ProjectEmployees)
            .HasForeignKey(pe => pe.EmployeeId);

        modelBuilder.Entity<ProjectTagEntity>()
            .HasOne(pt => pt.Project)
            .WithMany(p => p.ProjectTags)
            .HasForeignKey(pt => pt.ProjectId);

        modelBuilder.Entity<ProjectTagEntity>()
            .HasOne(pt => pt.TagEntity)
            .WithMany(t => t.ProjectTags)
            .HasForeignKey(pt => pt.TagId);

        // self-referencing Comments
        modelBuilder.Entity<CommentEntity>()
            .HasOne(c => c.ParentComment)
            .WithMany(c => c.Replies)
            .HasForeignKey(c => c.ParentCommentId)
            .OnDelete(DeleteBehavior.Restrict);

        // Client relationships
        modelBuilder.Entity<ClientEntity>()
            .HasMany(c => c.Projects)
            .WithOne(p => p.Client)
            .HasForeignKey(p => p.ClientId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ClientEntity>()
            .HasMany(c => c.Invoices)
            .WithOne(i => i.Client)
            .HasForeignKey(i => i.ClientId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProjectEntity>()
            .HasOne(p => p.ProjectManager)
            .WithMany(e => e.ManagedProjects)
            .HasForeignKey(c => c.ProjectManagerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}