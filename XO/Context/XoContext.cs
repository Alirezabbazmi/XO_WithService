using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.SqlServer;
using XO.Context.Model;

namespace XO.Context
{
    class XoContext : DbContext
    {
        public XoContext()
        {

        }
        public DbSet<GameBoardModel> GameBoards { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
