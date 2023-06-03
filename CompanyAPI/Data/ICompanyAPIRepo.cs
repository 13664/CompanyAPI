using CompanyAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyAPI.Data
{
    public interface ICompanyAPIRepo
    {
        Task<IEnumerable<Company>> GetAllCompanys();
        Task<Company> GetCompanyById(int id);

        Task CreateCompany(Company company);
        Task UpdateCompany(Company company);
        void DeleteCompany(Company company);

        public Task<bool> SaveChangesAsync();
    }
}
