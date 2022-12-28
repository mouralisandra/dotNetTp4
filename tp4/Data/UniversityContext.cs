using Microsoft.EntityFrameworkCore;
using OpenXmlPowerTools;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.Expressions;
using tp4.Data;
using tp4.Models;

namespace tp4.Data
{
    public class UniversityContext : DbContext
    {
        public DbSet<Student> Student { get; set; }

        static private UniversityContext universityContextInstance = null;
        static public int count = 0;
        public UniversityContext(DbContextOptions o) : base(o)
        {
            count++;
        }
        public UniversityContext Instantiate_UniversityContext()
        {
            if (universityContextInstance == null)
            {var optionsBuilder = new DbContextOptionsBuilder<UniversityContext>();
            optionsBuilder.UseSqlite("Data source= C:\\Users\\sandr\\Videos\\bd.db");
            return new UniversityContext(optionsBuilder.Options);
            }else
            {
                return universityContextInstance;
            }
        }
}
}