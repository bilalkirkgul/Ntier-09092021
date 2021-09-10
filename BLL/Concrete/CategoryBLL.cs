using BLL.Abstract;
using DAL.Abstract;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
   public class CategoryBLL : ICategoryBLL
    {

        ICategoryDAL categoryDAL;
        public CategoryBLL(ICategoryDAL category)
        {
            categoryDAL = category;
        }

        public void Add(Category entity)
        {
            categoryDAL.Insert(entity);
        }
        public void Update(Category entity)
        {
            categoryDAL.Update(entity);
        }

        public void Delete(Category entity)
        {
            categoryDAL.Delete(entity);
        }
        public Category GetEntity(int entityId)
        {
            return categoryDAL.Get(a=>a.CategoryID==entityId);
        }
        public void DeleteByID(int entityId)
        {
           categoryDAL.Delete(GetEntity(entityId));
        }

        public ICollection<Category> GetAll()
        {
           return categoryDAL.GetAll();
        }

       

        
    }
}
