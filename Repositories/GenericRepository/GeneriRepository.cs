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

        //get data
        public TEntity GetById(Guid id){
            return elpContext.Set<TEntity>().FirstOrDefault(e => e.Id == id);
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync(){
            return await elpTable.AsNoTracking().ToListAsync();
        }
        public IQueryable<TEntity> GetAllAsQueryable(){
            return elpTable.AsNoTracking();
        }

        //create new data
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
    }
}