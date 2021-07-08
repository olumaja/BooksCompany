using Books.DataAccess.Data;
using Books.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.DataAccess.Services
{
    public class CoverTypeRepository : ICoverTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public CoverTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void AddCoverType(CoverType coverType)
        {
            _db.CoverTypes.Add(coverType);
            _db.SaveChanges();

        }

        public void DeleteCoverType(CoverType coverType)
        {
            _db.CoverTypes.Remove(coverType);
            _db.SaveChanges();
        }

        public IEnumerable<CoverType> GetAllCoverTypes()
        {
            return _db.CoverTypes.ToList();
        }

        public CoverType GetCoverTypeById(int id)
        {
            return _db.CoverTypes.FirstOrDefault(c => c.CoverTypeId == id);
        }

        public void UpdateCoverType(CoverType coverType)
        {
            _db.CoverTypes.Update(coverType);
            _db.SaveChanges();
        }
    }
}
