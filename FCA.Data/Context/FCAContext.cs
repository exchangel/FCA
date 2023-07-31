using FCA.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCA.Data.Context
{
    public class FCAContext : DbContext
    {
        public FCAContext(DbContextOptions<FCAContext> options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.ApplyConfiguration(new PersonalSessionConfiguration());

            modelBuilder.Entity<GroupsCustomersEntity>().HasKey(sc => new { sc.CustomerId, sc.GroupId });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserEntity> Users => Set<UserEntity>();
        public DbSet<PotentialCustomerEntity> PotentialCustomers => Set<PotentialCustomerEntity>();
        public DbSet<CustomerEntity> Customers => Set<CustomerEntity>();
        public DbSet<PersonalSessionEntity> PersonalSessions => Set<PersonalSessionEntity>();
        public DbSet<GroupEntity> Groups => Set<GroupEntity>();
        public DbSet<GroupsCustomersEntity> GroupsCustomers => Set<GroupsCustomersEntity>();
        public DbSet<SessionPaymentEntity> SessionPayment => Set<SessionPaymentEntity>();
        public DbSet<GroupPaymentEntity> GroupPayment => Set<GroupPaymentEntity>();

        

    }
}
