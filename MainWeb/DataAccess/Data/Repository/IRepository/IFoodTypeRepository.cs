using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using System.Collections.Generic;

namespace DataAccess.Data.Repository.IRepository
{
    public interface IFoodTypeRepository
    {
        public interface IFoodTypeRepository : IRepository<FoodType>
        {
            IEnumerable<SelectListItem> GetFoodTypeListForDropDown();

            void Update(FoodType foodType);
        }
    }
}
