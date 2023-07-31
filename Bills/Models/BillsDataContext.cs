using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bills.Models;
    public class BillsDataContext:DbContext
    {
        public virtual DbSet<CommunalResource> Resources { get; set; } = null!;
        public virtual DbSet<Tariff> Tariffs { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-H9PN9H5\\SQLEXPRESS;Initial Catalog=Bills;Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Connect Timeout=60;Encrypt=False;Trust Server Certificate=False;Command Timeout=0");

    }
