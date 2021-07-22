using Books.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.DataAccess.Services
{
    public interface ICompanyRepository
    {
        void AddCompany(Company company);
        Company GetCompanyById(int Id);
        IEnumerable<Company> GetAllCompanies();
        void UpdateCompany(Company company);
        void DeleteCompany(Company company);
    }
}
