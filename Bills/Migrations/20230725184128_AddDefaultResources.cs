using Bills.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Data.Common;

#nullable disable

namespace Bills.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultResources : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            using(var db =new BillsDataContext())
            {
                var electr = new CommunalResource { Title = "Електрика" };
                electr.Tariffs.Add(new Tariff { Price = 2.64M });
                db.Add(electr);
                var water = new CommunalResource { Title = "Вода" };
                water.Tariffs.Add(new Tariff { Price = 1.34M });
                db.Add(water);
                var gas = new CommunalResource { Title = "Газ" };
                gas.Tariffs.Add(new Tariff { Price = 7.99M });
                db.Add(gas);
                db.SaveChanges();
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
