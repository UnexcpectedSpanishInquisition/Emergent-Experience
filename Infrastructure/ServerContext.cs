using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using Microsoft.EntityFrameworkCore.Design;


namespace Infrastructure
{ 
    public class ServerContext : DbContext
    {
        public DbSet<Server> Servers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseMySql("Server=localhost;User=root;database=EEdata;port=3306;Connect Timeout=5", new MySqlServerVersion(new Version(8, 0, 21)));
 
    }

    public class Server
    {
        public ulong Id { get; set; }
        public string Prefix { get; set; }
        public int GoalMax { get; set; }
        public int DiscoveryMax { get; set; }
        public int BondMax { get; set; }
        public int SetbackMax { get; set; }
        public int Goalxp { get; set; }
        public int Discoveryxp { get; set; }
        public int Bondxp { get; set; }
        public int Setbackxp { get; set; }
    }

}
