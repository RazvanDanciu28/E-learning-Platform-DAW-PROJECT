using ELP.Data;
using ELP.Models.Base;
using Microsoft.EntityFrameworkCore;


namespace ELP.Repositories.GenericRepository{

    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity: BaseEntity{

        protected readonly ELPContext elpContext;
        protected readonly DbSet <TEntity> elpTable;

        public GenericRepository (ELPContext _elpContext){
            elpContext = _elpContext;
            elpTable = elpContext.Set<TEntity>();
        }

        //get data from interface
        public TEntity GetById(Guid id){
            return elpContext.Set<TEntity>().FirstOrDefault(e => e.Id == id);
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync(){
            return await elpTable.AsNoTracking().ToListAsync();
        }
        public IQueryable<TEntity> GetAllAsQueryable(){
            return elpTable.AsNoTracking();
        }

        //create new data from interface
        public void Create(TEntity entity){
            elpTable.Add(entity);
        }
        public async Task CreateAsync(TEntity entity){
            await elpTable.AddAsync(entity);
        }
        public void CreateRange(IEnumerable<TEntity> enitities){
            elpTable.AddRange(enitities);
        }
        public async Task CreateRangeAsync(IEnumerable<TEntity> entities){
            await elpTable.AddRangeAsync(enitities);
        }

        //update the data from inteface
        public void Update(TEntity entity){
            elpTable.Update(entity);
        }
        public void UpdateRange(IEnumerable<TEntity> enitities){
            elpTable.UpdateRange(entities);
        }

        //delete the data from interface
        public void Delete(TEntity entity){
            elpTable.Remove(entity);
        }
        public void DeleteRange(IEnumerable<TEntity> entities){
            elpTable.RemoveRange(entities);
        }

        //find data from interface
        public async Task<IEnumerable<TEntity>> GetByIdRangeAsync(IEnumerable<object> Ids){
            return await elpTable.Where(e => Ids.Contains(e.Id)).ToListAsync();
        }
        public TEntity FindById(object id){
            return elpTable.Find(id);
        }
        public async Task<TEntity> FindByIdAsync(object id){
            return await elpTable.FindAsync(id);
        }

        //save data from interface
        public bool Save(){
            return elpContext.SaveChanges() > 0;
        }
        public async Task<bool> SaveAsync(){
            return await elpContext.SaveChangesAsync() > 0;
        }
    }
}