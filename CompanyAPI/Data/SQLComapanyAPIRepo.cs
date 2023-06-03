using CompanyAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyAPI.Data
{
    public class SQLComapanyAPIRepo : ICompanyAPIRepo
    {
        private readonly CompanyContext _context;
        public SQLComapanyAPIRepo(CompanyContext context)
        {
            _context = context;
        }

        public  async Task CreateCompany(Company company)
        {
            if(company == null)
            {
                throw new ArgumentNullException(nameof(company));
            }

            await _context.Companys.AddAsync(company);
        }

        public void DeleteCompany(Company company) 
        {
            if (company == null)
            {
                throw new ArgumentNullException(nameof(company));
            }

            _context.Companys.Remove(company);
        }

        public async Task<IEnumerable<Company>> GetAllCompanys()
        {
            return await _context.Companys.ToListAsync();
        }

        public async Task<Company> GetCompanyById(int id)
        {
            return await _context.Companys.FirstOrDefaultAsync(company => company.Id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
        public async Task UpdateCompany(Company company)
        {
            
        }
    }
}
