using Microsoft.EntityFrameworkCore;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Context
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserEntity> UserTable { get; set; }

        public DbSet<CarEntity> CarsTable { get; set; }

        public DbSet<BookingEntity> BookingsTable { get; set; }

        public DbSet<PaymentEntity> PaymentsTable { get; set; }

        public DbSet<ReportEntity> ReportTable { get; set; }

        public DbSet<OrderEntity> OrdersTable { get; set; }

    }
}
