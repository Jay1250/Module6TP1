using BO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjetModule5TP2.Models
{
    public class Context : DbContext
    {
    public DbSet<Samourai> Samourais { get; set; }
    public DbSet<Arme> Armes { get; set; }
    }
}