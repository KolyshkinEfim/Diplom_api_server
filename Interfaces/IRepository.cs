using System.Collections.Generic;

namespace test_crud.Interfaces
{
    public interface IRepository
    {
        public void Create<TEntity>(TEntity item) where TEntity : class;
        public TEntity FindById<TEntity>(int id) where TEntity : class;
        public IEnumerable<TEntity> Get<TEntity>() where TEntity : class;
        public void Remove<TEntity>(TEntity item) where TEntity : class;
        public void Update<TEntity>(TEntity item) where TEntity : class;
    }
}
