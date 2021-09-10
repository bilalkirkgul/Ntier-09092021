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
   public class ProductBLL : IProductBLL
    {

        IProductDAL productDAL;
        public ProductBLL(IProductDAL product)
        {
            productDAL = product;
        }

        public void Add(Product entity)
        {
            productDAL.Insert(entity);
        }

        public void Delete(Product entity)
        {
            productDAL.Delete(entity);
        }

        public void DeleteByID(int entityId)
        {
            productDAL.Delete(GetEntity(entityId));
        }

        public ICollection<Product> GetAll()
        {
          return productDAL.GetAll();
        }

        public Product GetEntity(int entityId)
        {
            return productDAL.Get(a => a.ProductID == entityId);
        }

        public void Update(Product entity)
        {
            productDAL.Update(entity);
        }
    }
}
