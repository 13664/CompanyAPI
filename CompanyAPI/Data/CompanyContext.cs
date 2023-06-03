using CompanyAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Security.Cryptography.X509Certificates;

namespace CompanyAPI.Data
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        { }

        public DbSet<Company> Companys { get; set; }

             
        
    }
}
