﻿using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;
using WebApiApp.Data.Models;

namespace WebApiApp.Migrations
{
    [DbContext(typeof(SellOnlineApiAppContext))]
    [Migration("20230907072823_DbInit")]
    public partial class DbInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = File.ReadAllText(@"Migrations\20230907072823_DbInit_Up.sql");
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sql = File.ReadAllText(@"Migrations\20230907072823_DbInit_Down.sql");
            migrationBuilder.Sql(sql);
        }
    }
}
