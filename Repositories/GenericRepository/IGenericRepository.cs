using ELP.Models.Base;

namespace ELP.Repositories.IGenericRepository {
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity {

        //get all data
        TEntity GetById(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        public IQueryable<TEntity> GetAllAsQueryable();

        //create new data
        void Create(TEntity entity);
        Task CreateAsync(TEntity entity);
        void CreateRange(IEnumerable<TEntity> entities);
        Task CreateRangeAsync(IEnumerable<TEntity> entities);

        //update data
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        //delte data
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);

        //find data
        Task<IEnumerable<TEntity>> GetByIdRangeAsync(IEnumerable<object> id);
        TEntity FindById(object id);
        Task<TEntity> FindByIdAsync(object id);

        //save data
        bool Save();
        Task<bool> SaveAsync();
    }
}