using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IncubatorRequirements.DAL.Models
{
    public partial class IncubatorRequirementContext : DbContext
    {
        public virtual DbSet<Booleans> Booleans { get; set; }
        public virtual DbSet<CalculationMaps> CalculationMaps { get; set; }
        public virtual DbSet<Calculations> Calculations { get; set; }
        public virtual DbSet<ClientFields> ClientFields { get; set; }
        public virtual DbSet<ClientTypes> ClientTypes { get; set; }
        public virtual DbSet<DropdownSetMaps> DropdownSetMaps { get; set; }
        public virtual DbSet<DropdownSets> DropdownSets { get; set; }
        public virtual DbSet<DropdownValues> DropdownValues { get; set; }
        public virtual DbSet<FieldSetGroupMaps> FieldSetGroupMaps { get; set; }
        public virtual DbSet<FieldSetGroups> FieldSetGroups { get; set; }
        public virtual DbSet<FieldSetMaps> FieldSetMaps { get; set; }
        public virtual DbSet<FieldSets> FieldSets { get; set; }
        public virtual DbSet<FieldTypes> FieldTypes { get; set; }
        public virtual DbSet<IncubatorQuardrants> IncubatorQuardrants { get; set; }
        public virtual DbSet<QuardrantMaps> QuardrantMaps { get; set; }
        public virtual DbSet<RejectionReasons> RejectionReasons { get; set; }
        public virtual DbSet<RequirementMaps> RequirementMaps { get; set; }
        public virtual DbSet<Requirements> Requirements { get; set; }
        public virtual DbSet<WorkItemStageMaps> WorkItemStageMaps { get; set; }
        public virtual DbSet<WorkItemStageReasons> WorkItemStageReasons { get; set; }
        public virtual DbSet<WorkItemStages> WorkItemStages { get; set; }
        public virtual DbSet<WorkItemStatus> WorkItemStatus { get; set; }

        public IncubatorRequirementContext(DbContextOptions<IncubatorRequirementContext> options)
    : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=localhost;Database=IncubatorRequirement;integrated security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booleans>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EnterDateTime).HasColumnType("datetime");

                entity.Property(e => e.EnterUserName).HasMaxLength(100);

                entity.Property(e => e.LastChgDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastChgUserName).HasMaxLength(100);

                entity.Property(e => e.Muid).HasColumnName("MUID");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.ValidationStatus).HasMaxLength(250);

                entity.Property(e => e.VersionFlag).HasMaxLength(50);

                entity.Property(e => e.VersionName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CalculationMaps>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Muid, e.VersionName, e.VersionNumber, e.Code, e.ChangeTrackingMask, e.EnterDateTime, e.LastChgDateTime });

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Muid).HasColumnName("MUID");

                entity.Property(e => e.VersionName).HasMaxLength(50);

                entity.Property(e => e.Code).HasMaxLength(250);

                entity.Property(e => e.EnterDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastChgDateTime).HasColumnType("datetime");

                entity.Property(e => e.CaculationCode)
                    .HasColumnName("Caculation_Code")
                    .HasMaxLength(250);

                entity.Property(e => e.CaculationId).HasColumnName("Caculation_ID");

                entity.Property(e => e.CaculationName)
                    .HasColumnName("Caculation_Name")
                    .HasMaxLength(250);

                entity.Property(e => e.EnterUserName).HasMaxLength(100);

                entity.Property(e => e.LastChgUserName).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.ParameterCode)
                    .HasColumnName("Parameter_Code")
                    .HasMaxLength(250);

                entity.Property(e => e.ParameterId).HasColumnName("Parameter_ID");

                entity.Property(e => e.ParameterName)
                    .HasColumnName("Parameter_Name")
                    .HasMaxLength(250);

                entity.Property(e => e.ValidationStatus).HasMaxLength(250);

                entity.Property(e => e.VersionFlag).HasMaxLength(50);
            });

            modelBuilder.Entity<Calculations>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Muid, e.VersionName, e.VersionNumber, e.Code, e.ChangeTrackingMask, e.EnterDateTime, e.LastChgDateTime });

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Muid).HasColumnName("MUID");

                entity.Property(e => e.VersionName).HasMaxLength(50);

                entity.Property(e => e.Code).HasMaxLength(250);

                entity.Property(e => e.EnterDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastChgDateTime).HasColumnType("datetime");

                entity.Property(e => e.EnterUserName).HasMaxLength(100);

                entity.Property(e => e.LastChgUserName).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.ValidationStatus).HasMaxLength(250);

                entity.Property(e => e.VersionFlag).HasMaxLength(50);
            });

            modelBuilder.Entity<ClientFields>(entity =>
            {
                entity.HasIndex(e => e.FieldTypeId)
                    .HasName("IX_FK_ClientFieldFieldType");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EnterDateTime).HasColumnType("datetime");

                entity.Property(e => e.EnterUserName).HasMaxLength(100);

                entity.Property(e => e.FieldTypeCode)
                    .HasColumnName("FieldType_Code")
                    .HasMaxLength(250);

                entity.Property(e => e.FieldTypeId).HasColumnName("FieldType_ID");

                entity.Property(e => e.FieldTypeName)
                    .HasColumnName("FieldType_Name")
                    .HasMaxLength(250);

                entity.Property(e => e.LastChgDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastChgUserName).HasMaxLength(100);

                entity.Property(e => e.Muid).HasColumnName("MUID");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.ValidationStatus).HasMaxLength(250);

                entity.Property(e => e.VersionFlag).HasMaxLength(50);

                entity.Property(e => e.VersionName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.FieldType)
                    .WithMany(p => p.ClientFields)
                    .HasForeignKey(d => d.FieldTypeId)
                    .HasConstraintName("FK_ClientFieldFieldType");
            });

            modelBuilder.Entity<ClientTypes>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EnterDateTime).HasColumnType("datetime");

                entity.Property(e => e.EnterUserName).HasMaxLength(100);

                entity.Property(e => e.LastChgDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastChgUserName).HasMaxLength(100);

                entity.Property(e => e.Muid).HasColumnName("MUID");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.ValidationStatus).HasMaxLength(250);

                entity.Property(e => e.VersionFlag).HasMaxLength(50);

                entity.Property(e => e.VersionName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DropdownSetMaps>(entity =>
            {
                entity.HasIndex(e => e.DropdownSetId)
                    .HasName("IX_FK_DropdownSetDropdownSetMap");

                entity.HasIndex(e => e.DropdownValueId)
                    .HasName("IX_FK_DropdownValueDropdownSetMap");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.DropdownSetCode)
                    .HasColumnName("DropdownSet_Code")
                    .HasMaxLength(250);

                entity.Property(e => e.DropdownSetId).HasColumnName("DropdownSet_ID");

                entity.Property(e => e.DropdownSetName)
                    .HasColumnName("DropdownSet_Name")
                    .HasMaxLength(250);

                entity.Property(e => e.DropdownValueCode)
                    .HasColumnName("DropdownValue_Code")
                    .HasMaxLength(250);

                entity.Property(e => e.DropdownValueId).HasColumnName("DropdownValue_ID");

                entity.Property(e => e.DropdownValueName)
                    .HasColumnName("DropdownValue_Name")
                    .HasMaxLength(250);

                entity.Property(e => e.EnterDateTime).HasColumnType("datetime");

                entity.Property(e => e.EnterUserName).HasMaxLength(100);

                entity.Property(e => e.FieldSetGroupCode)
                    .HasColumnName("FieldSetGroup_Code")
                    .HasMaxLength(250);

                entity.Property(e => e.FieldSetGroupId).HasColumnName("FieldSetGroup_ID");

                entity.Property(e => e.FieldSetGroupName)
                    .HasColumnName("FieldSetGroup_Name")
                    .HasMaxLength(250);

                entity.Property(e => e.LastChgDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastChgUserName).HasMaxLength(100);

                entity.Property(e => e.Muid).HasColumnName("MUID");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.ScoreCard).HasMaxLength(100);

                entity.Property(e => e.ValidationStatus).HasMaxLength(250);

                entity.Property(e => e.VersionFlag).HasMaxLength(50);

                entity.Property(e => e.VersionName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.DropdownSet)
                    .WithMany(p => p.DropdownSetMaps)
                    .HasForeignKey(d => d.DropdownSetId)
                    .HasConstraintName("FK_DropdownSetDropdownSetMap");

                entity.HasOne(d => d.DropdownValue)
                    .WithMany(p => p.DropdownSetMaps)
                    .HasForeignKey(d => d.DropdownValueId)
                    .HasConstraintName("FK_DropdownValueDropdownSetMap");
            });

            modelBuilder.Entity<DropdownSets>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EnterDateTime).HasColumnType("datetime");

                entity.Property(e => e.EnterUserName).HasMaxLength(100);

                entity.Property(e => e.LastChgDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastChgUserName).HasMaxLength(100);

                entity.Property(e => e.Muid).HasColumnName("MUID");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.ValidationStatus).HasMaxLength(250);

                entity.Property(e => e.VersionFlag).HasMaxLength(50);

                entity.Property(e => e.VersionName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DropdownValues>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EnterDateTime).HasColumnType("datetime");

                entity.Property(e => e.EnterUserName).HasMaxLength(100);

                entity.Property(e => e.LastChgDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastChgUserName).HasMaxLength(100);

                entity.Property(e => e.Muid).HasColumnName("MUID");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.ValidationStatus).HasMaxLength(250);

                entity.Property(e => e.VersionFlag).HasMaxLength(50);

                entity.Property(e => e.VersionName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<FieldSetGroupMaps>(entity =>
            {
                entity.HasIndex(e => e.FieldSetGroupId)
                    .HasName("IX_FK_FieldSetGroupFieldSetGroupMap");

                entity.HasIndex(e => e.FieldSetId)
                    .HasName("IX_FK_FieldSetFieldSetGroupMap");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EnterDateTime).HasColumnType("datetime");

                entity.Property(e => e.EnterUserName).HasMaxLength(100);

                entity.Property(e => e.FieldSetCode)
                    .HasColumnName("FieldSet_Code")
                    .HasMaxLength(250);

                entity.Property(e => e.FieldSetGroupCode)
                    .HasColumnName("FieldSetGroup_Code")
                    .HasMaxLength(250);

                entity.Property(e => e.FieldSetGroupId).HasColumnName("FieldSetGroup_ID");

                entity.Property(e => e.FieldSetGroupName)
                    .HasColumnName("FieldSetGroup_Name")
                    .HasMaxLength(250);

                entity.Property(e => e.FieldSetId).HasColumnName("FieldSet_ID");

                entity.Property(e => e.FieldSetName)
                    .HasColumnName("FieldSet_Name")
                    .HasMaxLength(250);

                entity.Property(e => e.FieldSetOrder).HasMaxLength(100);

                entity.Property(e => e.LastChgDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastChgUserName).HasMaxLength(100);

                entity.Property(e => e.Muid).HasColumnName("MUID");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.ValidationStatus).HasMaxLength(250);

                entity.Property(e => e.VersionFlag).HasMaxLength(50);

                entity.Property(e => e.VersionName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.FieldSetGroup)
                    .WithMany(p => p.FieldSetGroupMaps)
                    .HasForeignKey(d => d.FieldSetGroupId)
                    .HasConstraintName("FK_FieldSetGroupFieldSetGroupMap");

                entity.HasOne(d => d.FieldSet)
                    .WithMany(p => p.FieldSetGroupMaps)
                    .HasForeignKey(d => d.FieldSetId)
                    .HasConstraintName("FK_FieldSetFieldSetGroupMap");
            });

            modelBuilder.Entity<FieldSetGroups>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EnterDateTime).HasColumnType("datetime");

                entity.Property(e => e.EnterUserName).HasMaxLength(100);

                entity.Property(e => e.LastChgDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastChgUserName).HasMaxLength(100);

                entity.Property(e => e.Muid).HasColumnName("MUID");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.ValidationStatus).HasMaxLength(250);

                entity.Property(e => e.VersionFlag).HasMaxLength(50);

                entity.Property(e => e.VersionName).HasMaxLength(50);
            });

            modelBuilder.Entity<FieldSetMaps>(entity =>
            {
                entity.HasIndex(e => e.FieldId)
                    .HasName("IX_FK_ClientFieldFieldSetMap");

                entity.HasIndex(e => e.FieldSetId)
                    .HasName("IX_FK_FieldSetFieldSetMap");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CaculationCode)
                    .HasColumnName("Caculation_Code")
                    .HasMaxLength(250);

                entity.Property(e => e.CaculationId).HasColumnName("Caculation_ID");

                entity.Property(e => e.CaculationName)
                    .HasColumnName("Caculation_Name")
                    .HasMaxLength(250);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.DropdownSetCode)
                    .HasColumnName("DropdownSet_Code")
                    .HasMaxLength(250);

                entity.Property(e => e.DropdownSetId).HasColumnName("DropdownSet_ID");

                entity.Property(e => e.DropdownSetName)
                    .HasColumnName("DropdownSet_Name")
                    .HasMaxLength(250);

                entity.Property(e => e.EnterDateTime).HasColumnType("datetime");

                entity.Property(e => e.EnterUserName).HasMaxLength(100);

                entity.Property(e => e.FieldCode)
                    .HasColumnName("Field_Code")
                    .HasMaxLength(250);

                entity.Property(e => e.FieldId).HasColumnName("Field_ID");

                entity.Property(e => e.FieldName)
                    .HasColumnName("Field_Name")
                    .HasMaxLength(250);

                entity.Property(e => e.FieldOrder).HasMaxLength(100);

                entity.Property(e => e.FieldScore).HasMaxLength(100);

                entity.Property(e => e.FieldSetCode)
                    .HasColumnName("FieldSet_Code")
                    .HasMaxLength(250);

                entity.Property(e => e.FieldSetId).HasColumnName("FieldSetID");

                entity.Property(e => e.FieldSetName)
                    .HasColumnName("FieldSet_Name")
                    .HasMaxLength(250);

                entity.Property(e => e.IsRelatedCode)
                    .HasColumnName("IsRelated_Code")
                    .HasMaxLength(250);

                entity.Property(e => e.IsRelatedId).HasColumnName("IsRelated_ID");

                entity.Property(e => e.IsRelatedName)
                    .HasColumnName("IsRelated_Name")
                    .HasMaxLength(250);

                entity.Property(e => e.IsRequiredCode)
                    .HasColumnName("IsRequired_Code")
                    .HasMaxLength(250);

                entity.Property(e => e.IsRequiredId).HasColumnName("IsRequired_ID");

                entity.Property(e => e.IsRequiredName)
                    .HasColumnName("IsRequired_Name")
                    .HasMaxLength(250);

                entity.Property(e => e.LastChgDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastChgUserName).HasMaxLength(100);

                entity.Property(e => e.Length).HasMaxLength(100);

                entity.Property(e => e.Muid).HasColumnName("MUID");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.ToolTip).HasMaxLength(100);

                entity.Property(e => e.ValidationStatus).HasMaxLength(250);

                entity.Property(e => e.VersionFlag).HasMaxLength(50);

                entity.Property(e => e.VersionName).HasMaxLength(50);

                entity.HasOne(d => d.Field)
                    .WithMany(p => p.FieldSetMaps)
                    .HasForeignKey(d => d.FieldId)
                    .HasConstraintName("FK_ClientFieldFieldSetMap");

                entity.HasOne(d => d.FieldSet)
                    .WithMany(p => p.FieldSetMaps)
                    .HasForeignKey(d => d.FieldSetId)
                    .HasConstraintName("FK_FieldSetFieldSetMap");
            });

            modelBuilder.Entity<FieldSets>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.EnterDateTime).HasColumnType("datetime");

                entity.Property(e => e.EnterUserName).HasMaxLength(100);

                entity.Property(e => e.IsCalculatedCode)
                    .HasColumnName("IsCalculated_Code")
                    .HasMaxLength(250);

                entity.Property(e => e.IsCalculatedId).HasColumnName("IsCalculated_ID");

                entity.Property(e => e.IsCalculatedName)
                    .HasColumnName("IsCalculated_Name")
                    .HasMaxLength(250);

                entity.Property(e => e.IsHiddenCode)
                    .HasColumnName("IsHidden_Code")
                    .HasMaxLength(250);

                entity.Property(e => e.IsHiddenId).HasColumnName("IsHidden_ID");

                entity.Property(e => e.IsHiddenName)
                    .HasColumnName("IsHidden_Name")
                    .HasMaxLength(250);

                entity.Property(e => e.LastChgDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastChgUserName).HasMaxLength(100);

                entity.Property(e => e.Muid).HasColumnName("MUID");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.PrePopulateCode)
                    .HasColumnName("PrePopulate_Code")
                    .HasMaxLength(250);

                entity.Property(e => e.PrePopulateId).HasColumnName("PrePopulate_ID");

                entity.Property(e => e.PrePopulateName)
                    .HasColumnName("PrePopulate_Name")
                    .HasMaxLength(250);

                entity.Property(e => e.ValidationStatus).HasMaxLength(250);

                entity.Property(e => e.VersionFlag).HasMaxLength(50);

                entity.Property(e => e.VersionName).HasMaxLength(50);
            });

            modelBuilder.Entity<FieldTypes>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EnterDateTime).HasColumnType("datetime");

                entity.Property(e => e.EnterUserName).HasMaxLength(100);

                entity.Property(e => e.LastChgDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastChgUserName).HasMaxLength(100);

                entity.Property(e => e.Muid).HasColumnName("MUID");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.ValidationStatus).HasMaxLength(250);

                entity.Property(e => e.VersionFlag).HasMaxLength(50);

                entity.Property(e => e.VersionName).HasMaxLength(50);
            });

            modelBuilder.Entity<IncubatorQuardrants>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EnterDateTime).HasColumnType("datetime");

                entity.Property(e => e.EnterUserName).HasMaxLength(100);

                entity.Property(e => e.LastChgDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastChgUserName).HasMaxLength(100);

                entity.Property(e => e.Muid).HasColumnName("MUID");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.ValidationStatus).HasMaxLength(250);

                entity.Property(e => e.VersionFlag).HasMaxLength(50);

                entity.Property(e => e.VersionName).HasMaxLength(50);
            });

            modelBuilder.Entity<QuardrantMaps>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EnterDateTime).HasColumnType("datetime");

                entity.Property(e => e.EnterUserName).HasMaxLength(100);

                entity.Property(e => e.FieldSetGroupCode)
                    .HasColumnName("FieldSetGroup_Code")
                    .HasMaxLength(250);

                entity.Property(e => e.FieldSetGroupId).HasColumnName("FieldSetGroup_ID");

                entity.Property(e => e.FieldSetGroupName)
                    .HasColumnName("FieldSetGroup_Name")
                    .HasMaxLength(250);

                entity.Property(e => e.FieldSetGroupOrder).HasMaxLength(100);

                entity.Property(e => e.LastChgDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastChgUserName).HasMaxLength(100);

                entity.Property(e => e.Muid).HasColumnName("MUID");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.QuadrantCode)
                    .HasColumnName("Quadrant_Code")
                    .HasMaxLength(250);

                entity.Property(e => e.QuadrantId).HasColumnName("Quadrant_ID");

                entity.Property(e => e.QuadrantName)
                    .HasColumnName("Quadrant_Name")
                    .HasMaxLength(250);

                entity.Property(e => e.RequirementsTabCode)
                    .HasColumnName("RequirementsTab_Code")
                    .HasMaxLength(250);

                entity.Property(e => e.RequirementsTabId).HasColumnName("RequirementsTab_ID");

                entity.Property(e => e.RequirementsTabName)
                    .HasColumnName("RequirementsTab_Name")
                    .HasMaxLength(250);

                entity.Property(e => e.ValidationStatus).HasMaxLength(250);

                entity.Property(e => e.VersionFlag).HasMaxLength(50);

                entity.Property(e => e.VersionName).HasMaxLength(50);
            });

            modelBuilder.Entity<RejectionReasons>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.EnterDateTime).HasColumnType("datetime");

                entity.Property(e => e.EnterUserName).HasMaxLength(100);

                entity.Property(e => e.LastChgDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastChgUserName).HasMaxLength(100);

                entity.Property(e => e.Muid).HasColumnName("MUID");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.ValidationStatus).HasMaxLength(250);

                entity.Property(e => e.VersionFlag).HasMaxLength(50);

                entity.Property(e => e.VersionName).HasMaxLength(50);
            });

            modelBuilder.Entity<RequirementMaps>(entity =>
            {
                entity.HasIndex(e => e.ClientTypeId)
                    .HasName("IX_FK_ClientTypeRequirementMap");

                entity.HasIndex(e => e.FieldSetGroupId)
                    .HasName("IX_FK_FieldSetGroupRequirementMap");

                entity.HasIndex(e => e.RequirementsTabId)
                    .HasName("IX_FK_RequirementRequirementMap");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClientTypeCode)
                    .HasColumnName("ClientType_Code")
                    .HasMaxLength(250);

                entity.Property(e => e.ClientTypeId).HasColumnName("ClientType_ID");

                entity.Property(e => e.ClientTypeName)
                    .HasColumnName("ClientType_Name")
                    .HasMaxLength(250);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EnterDateTime).HasColumnType("datetime");

                entity.Property(e => e.EnterUserName).HasMaxLength(100);

                entity.Property(e => e.FieldSetGroupCode)
                    .HasColumnName("FieldSetGroup_Code")
                    .HasMaxLength(250);

                entity.Property(e => e.FieldSetGroupId).HasColumnName("FieldSetGroup_ID");

                entity.Property(e => e.FieldSetGroupName)
                    .HasColumnName("FieldSetGroup_Name")
                    .HasMaxLength(250);

                entity.Property(e => e.FieldSetGroupOrder).HasMaxLength(100);

                entity.Property(e => e.LastChgDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastChgUserName).HasMaxLength(100);

                entity.Property(e => e.Muid).HasColumnName("MUID");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.RequirementsTabCode)
                    .HasColumnName("RequirementsTab_Code")
                    .HasMaxLength(250);

                entity.Property(e => e.RequirementsTabId).HasColumnName("RequirementsTab_ID");

                entity.Property(e => e.RequirementsTabName)
                    .HasColumnName("RequirementsTab_Name")
                    .HasMaxLength(250);

                entity.Property(e => e.ValidationStatus).HasMaxLength(250);

                entity.Property(e => e.VersionFlag).HasMaxLength(50);

                entity.Property(e => e.VersionName).HasMaxLength(50);

                entity.Property(e => e.WorkItemStatusCode)
                    .HasColumnName("WorkItemStatus_Code")
                    .HasMaxLength(250);

                entity.Property(e => e.WorkItemStatusId).HasColumnName("WorkItemStatus_ID");

                entity.Property(e => e.WorkItemStatusName)
                    .HasColumnName("WorkItemStatus_Name")
                    .HasMaxLength(250);

                entity.HasOne(d => d.ClientType)
                    .WithMany(p => p.RequirementMaps)
                    .HasForeignKey(d => d.ClientTypeId)
                    .HasConstraintName("FK_ClientTypeRequirementMap");

                entity.HasOne(d => d.FieldSetGroup)
                    .WithMany(p => p.RequirementMaps)
                    .HasForeignKey(d => d.FieldSetGroupId)
                    .HasConstraintName("FK_FieldSetGroupRequirementMap");

                entity.HasOne(d => d.RequirementsTab)
                    .WithMany(p => p.RequirementMaps)
                    .HasForeignKey(d => d.RequirementsTabId)
                    .HasConstraintName("FK_RequirementRequirementMap");
            });

            modelBuilder.Entity<Requirements>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EnterDateTime).HasColumnType("datetime");

                entity.Property(e => e.EnterUserName).HasMaxLength(100);

                entity.Property(e => e.LastChgDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastChgUserName).HasMaxLength(100);

                entity.Property(e => e.Muid).HasColumnName("MUID");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.ValidationStatus).HasMaxLength(250);

                entity.Property(e => e.VersionFlag).HasMaxLength(50);

                entity.Property(e => e.VersionName).HasMaxLength(50);
            });

            modelBuilder.Entity<WorkItemStageMaps>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActionTeamCode)
                    .HasColumnName("ActionTeam_Code")
                    .HasMaxLength(250);

                entity.Property(e => e.ActionTeamId).HasColumnName("ActionTeam_ID");

                entity.Property(e => e.ActionTeamName)
                    .HasColumnName("ActionTeam_Name")
                    .HasMaxLength(250);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EnterDateTime).HasColumnType("datetime");

                entity.Property(e => e.EnterUserName).HasMaxLength(100);

                entity.Property(e => e.LastChgDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastChgUserName).HasMaxLength(100);

                entity.Property(e => e.Muid).HasColumnName("MUID");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.ValidationStatus).HasMaxLength(250);

                entity.Property(e => e.VersionFlag).HasMaxLength(50);

                entity.Property(e => e.VersionName).HasMaxLength(50);

                entity.Property(e => e.WorkItemStageCode)
                    .HasColumnName("WorkItemStage_Code")
                    .HasMaxLength(250);

                entity.Property(e => e.WorkItemStageId).HasColumnName("WorkItemStage_ID");

                entity.Property(e => e.WorkItemStageName)
                    .HasColumnName("WorkItemStage_Name")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<WorkItemStageReasons>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EnterDateTime).HasColumnType("datetime");

                entity.Property(e => e.EnterUserName).HasMaxLength(100);

                entity.Property(e => e.LastChgDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastChgUserName).HasMaxLength(100);

                entity.Property(e => e.Muid).HasColumnName("MUID");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.ReasonCode)
                    .HasColumnName("Reason_Code")
                    .HasMaxLength(250);

                entity.Property(e => e.ReasonId).HasColumnName("Reason_ID");

                entity.Property(e => e.ReasonName)
                    .HasColumnName("Reason_Name")
                    .HasMaxLength(250);

                entity.Property(e => e.StageCode)
                    .HasColumnName("Stage_Code")
                    .HasMaxLength(250);

                entity.Property(e => e.StageId).HasColumnName("Stage_ID");

                entity.Property(e => e.StageName)
                    .HasColumnName("Stage_Name")
                    .HasMaxLength(250);

                entity.Property(e => e.ValidationStatus).HasMaxLength(250);

                entity.Property(e => e.VersionFlag).HasMaxLength(50);

                entity.Property(e => e.VersionName).HasMaxLength(50);
            });

            modelBuilder.Entity<WorkItemStages>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BussinessCanEditCode)
                    .HasColumnName("BussinessCanEdit_Code")
                    .HasMaxLength(250);

                entity.Property(e => e.BussinessCanEditId).HasColumnName("BussinessCanEdit_ID");

                entity.Property(e => e.BussinessCanEditName)
                    .HasColumnName("BussinessCanEdit_Name")
                    .HasMaxLength(250);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EnterDateTime).HasColumnType("datetime");

                entity.Property(e => e.EnterUserName).HasMaxLength(100);

                entity.Property(e => e.HasDocumentsCode)
                    .HasColumnName("HasDocuments_Code")
                    .HasMaxLength(250);

                entity.Property(e => e.HasDocumentsId).HasColumnName("HasDocuments_ID");

                entity.Property(e => e.HasDocumentsName)
                    .HasColumnName("HasDocuments_Name")
                    .HasMaxLength(250);

                entity.Property(e => e.LastChgDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastChgUserName).HasMaxLength(100);

                entity.Property(e => e.Muid).HasColumnName("MUID");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.NextSageCode)
                    .HasColumnName("NextSage_Code")
                    .HasMaxLength(250);

                entity.Property(e => e.NextSageId).HasColumnName("NextSage_ID");

                entity.Property(e => e.NextSageName)
                    .HasColumnName("NextSage_Name")
                    .HasMaxLength(250);

                entity.Property(e => e.PreviousStageCode)
                    .HasColumnName("PreviousStage_Code")
                    .HasMaxLength(250);

                entity.Property(e => e.PreviousStageId).HasColumnName("PreviousStage_ID");

                entity.Property(e => e.PreviousStageName)
                    .HasColumnName("PreviousStage_Name")
                    .HasMaxLength(250);

                entity.Property(e => e.UserCanEditCode)
                    .HasColumnName("UserCanEdit_Code")
                    .HasMaxLength(250);

                entity.Property(e => e.UserCanEditId).HasColumnName("UserCanEdit_ID");

                entity.Property(e => e.UserCanEditName)
                    .HasColumnName("UserCanEdit_Name")
                    .HasMaxLength(250);

                entity.Property(e => e.ValidationStatus).HasMaxLength(250);

                entity.Property(e => e.VersionFlag).HasMaxLength(50);

                entity.Property(e => e.VersionName).HasMaxLength(50);
            });

            modelBuilder.Entity<WorkItemStatus>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EnterDateTime).HasColumnType("datetime");

                entity.Property(e => e.EnterUserName).HasMaxLength(100);

                entity.Property(e => e.LastChgDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastChgUserName).HasMaxLength(100);

                entity.Property(e => e.Muid).HasColumnName("MUID");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.ValidationStatus).HasMaxLength(250);

                entity.Property(e => e.VersionFlag).HasMaxLength(50);

                entity.Property(e => e.VersionName).HasMaxLength(50);
            });
        }
    }
}
