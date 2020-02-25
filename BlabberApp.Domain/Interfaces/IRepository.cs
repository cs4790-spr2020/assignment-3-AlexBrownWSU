using System.Collections.Generic;
using BlabberApp.Domain.Entities;

namespace BlabberApp.Domain.Interfaces {
    public interface IRepository<T> where T : BaseEntity 
    {
       void Add(T entity);
       void Remove(T entity);
       void Update(T entity);
       List<T> GetAll();
       T GetById(string sysId);
    }
}