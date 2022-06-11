using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace GaoXiao_Final.Models
{
    public partial class LibraryModels : DbContext
    {
        public LibraryModels()
            : base("name=LibraryModels")
        {
        }

        public virtual DbSet<DiscussionRoomStatu> DiscussionRoomStatus { get; set; }
        public virtual DbSet<LendingStatu> LendingStatus { get; set; }
        public virtual DbSet<Librarian> Librarians { get; set; }
        public virtual DbSet<StudentDetail> StudentDetails { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<LendingHistory> LendingHistories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiscussionRoomStatu>()
                .Property(e => e.RoomNumber)
                .IsUnicode(false);

            modelBuilder.Entity<DiscussionRoomStatu>()
                .Property(e => e.RoomType)
                .IsUnicode(false);

            modelBuilder.Entity<DiscussionRoomStatu>()
                .Property(e => e.RoomAccess)
                .IsUnicode(false);

            modelBuilder.Entity<DiscussionRoomStatu>()
                .HasMany(e => e.LendingStatus)
                .WithRequired(e => e.DiscussionRoomStatu)
                .HasForeignKey(e => e.DiscussionRoom)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LendingStatu>()
                .Property(e => e.DiscussionRoom)
                .IsUnicode(false);

            modelBuilder.Entity<Librarian>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Librarian>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Librarian>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<Librarian>()
                .HasMany(e => e.LendingStatus)
                .WithOptional(e => e.Librarian)
                .HasForeignKey(e => e.PersonInCharge);

            modelBuilder.Entity<StudentDetail>()
                .Property(e => e.Course)
                .IsUnicode(false);

            modelBuilder.Entity<StudentDetail>()
                .Property(e => e.Degree)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Account)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.LendingStatus)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LendingHistory>()
                .Property(e => e.房號)
                .IsUnicode(false);

            modelBuilder.Entity<LendingHistory>()
                .Property(e => e.租借人)
                .IsUnicode(false);
        }
    }
}
