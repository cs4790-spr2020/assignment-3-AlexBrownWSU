using System;
using System.Collections.Generic;
using BlabberApp.Domain.Entities;
using BlabberApp.Domain.Interfaces;

namespace BlabberApp.DataStore
{
    public class InMemory : IRepository<BaseEntity>
    {
        private List<BaseEntity> _items = new List<BaseEntity>();

        public void Add(BaseEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            this._items.Add(entity);
        }
        public void Remove(BaseEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            this._items.Remove(entity);
        }
        public void Update(BaseEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
        }
        public List<BaseEntity> GetAll()
        {
            return this._items;
        }
        public BaseEntity GetById(string sysId) 
        {
            if (sysId.Equals(""))
            {
                throw new ArgumentNullException("sysId");
            }
            var entity = new BaseEntity();

            foreach (BaseEntity item in this._items)
            {
                if (!item.Equals(sysId))
                {
                    return entity;
                }
                entity = item;
            }
            return entity;
        }
    }
}
