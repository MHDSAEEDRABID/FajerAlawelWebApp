using DataAccess.Data.Repository.IRepository;
using MainWeb.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            FoodType = new FoodTypeRepository(_db);
        }

        public ICategoryRepository Category { get; set; }
        public IFoodTypeRepository FoodType { get; private set; }
        public void Dispose()
        {
            
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
