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
  public  class SupplierBLL : ISupplierBLL
    {
        ISupplierDAL supplierDAL;
        public SupplierBLL(ISupplierDAL supplier)
        {
            supplierDAL = supplier;
        }

        public void Add(Supplier entity)
        {
            supplierDAL.Insert(entity);
        }

        public void Delete(Supplier entity)
        {
            supplierDAL.Delete(entity);
        }

        public void DeleteByID(int entityId)
        {
            supplierDAL.Delete(GetEntity(entityId));
        }

        public ICollection<Supplier> GetAll()
        {
            return supplierDAL.GetAll().ToList();
        }

        public Supplier GetEntity(int entityId)
        {
            return supplierDAL.Get(a => a.SupplierID == entityId);
        }

        public void Update(Supplier entity)
        {
            supplierDAL.Update(entity);
        }
    }
}
