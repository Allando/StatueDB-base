using System.Data.Entity;

namespace WebService
{
    public class StatueContext : DbContext
    {
        public StatueContext()
            : base("name=StatueContext")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<CulturalValue> CulturalValues { get; set; }
        public virtual DbSet<CulturalValueList> CulturalValueLists { get; set; }
        public virtual DbSet<Description> Descriptions { get; set; }
        // ReSharper disable once InconsistentNaming
        public virtual DbSet<GPSLocation> GPSLocations { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<ImageList> ImageLists { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<MaterialList> MaterialLists { get; set; }
        public virtual DbSet<Placement> Placements { get; set; }
        public virtual DbSet<PlacementList> PlacementLists { get; set; }
        public virtual DbSet<Statue> Statues { get; set; }
        public virtual DbSet<StatueType> StatueTypes { get; set; }
        public virtual DbSet<StatueTypeList> StatueTypeLists { get; set; }
        public virtual DbSet<Zipcode> Zipcodes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CulturalValue>()
                .Property(e => e.CulturalValue1)
                .IsUnicode(false);

            modelBuilder.Entity<CulturalValue>()
                .HasMany(e => e.CulturalValueLists)
                .WithRequired(e => e.CulturalValue)
                .HasForeignKey(e => e.FK_CulturalValue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GPSLocation>()
                .Property(e => e.Coordinates)
                .IsUnicode(false);

            modelBuilder.Entity<Image>()
                .Property(e => e.Image1)
                .IsUnicode(false);

            modelBuilder.Entity<Image>()
                .HasMany(e => e.ImageLists)
                .WithRequired(e => e.Image)
                .HasForeignKey(e => e.FK_Image)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Material>()
                .Property(e => e.MaterialName)
                .IsUnicode(false);

            modelBuilder.Entity<Material>()
                .Property(e => e.Types)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Material>()
                .HasMany(e => e.MaterialLists)
                .WithRequired(e => e.Material)
                .HasForeignKey(e => e.FK_Material)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Placement>()
                .Property(e => e.Placement1)
                .IsUnicode(false);

            modelBuilder.Entity<Placement>()
                .HasMany(e => e.PlacementLists)
                .WithRequired(e => e.Placement)
                .HasForeignKey(e => e.FK_Placement)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Statue>()
                .Property(e => e.Adress)
                .IsUnicode(false);

            modelBuilder.Entity<Statue>()
                .Property(e => e.Zipcode)
                .IsUnicode(false);

            modelBuilder.Entity<Statue>()
                .HasMany(e => e.CulturalValueLists)
                .WithRequired(e => e.Statue)
                .HasForeignKey(e => e.FK_Statue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Statue>()
                .HasMany(e => e.Descriptions)
                .WithRequired(e => e.Statue)
                .HasForeignKey(e => e.FK_Statue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Statue>()
                .HasMany(e => e.GPSLocations)
                .WithRequired(e => e.Statue)
                .HasForeignKey(e => e.FK_Statue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Statue>()
                .HasMany(e => e.ImageLists)
                .WithRequired(e => e.Statue)
                .HasForeignKey(e => e.FK_Statue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Statue>()
                .HasMany(e => e.MaterialLists)
                .WithRequired(e => e.Statue)
                .HasForeignKey(e => e.FK_Statue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Statue>()
                .HasMany(e => e.PlacementLists)
                .WithRequired(e => e.Statue)
                .HasForeignKey(e => e.FK_Statue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Statue>()
                .HasMany(e => e.StatueTypeLists)
                .WithRequired(e => e.Statue)
                .HasForeignKey(e => e.FK_Statue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StatueType>()
                .Property(e => e.StatueType_)
                .IsUnicode(false);

            modelBuilder.Entity<StatueType>()
                .HasMany(e => e.StatueTypeLists)
                .WithRequired(e => e.StatueType)
                .HasForeignKey(e => e.FK_StatueType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Zipcode>()
                .Property(e => e.Zipcode1)
                .IsUnicode(false);

            modelBuilder.Entity<Zipcode>()
                .Property(e => e.City)
                .IsUnicode(false);
        }
    }
}