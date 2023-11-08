
using Final_Project.Models.DataContext;
using Final_Project.Models.DomainModels;
using Microsoft.AspNetCore.Identity;
using System.Collections;

namespace Final_Project.Repositary
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public DataContext db { get; set; }
        private readonly Clinic Clinic;
        public Repository(DataContext _db)
        {
            db = _db;
            
        }
       
        public IEnumerable<TEntity> GetAll()
        {
            return db.Set<TEntity>().ToList() ;
        }

        public TEntity GetByID(string Id)
        {
            return db.Set<TEntity>().Find(Id);
        }
        public TEntity GetByIDstring(string Id)
        {
            return db.Set<TEntity>().Find(Id);
        }

        public void Add(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
        }

        public void Delete(string Id)
        {
            var entity = db.Set<TEntity>().Find(Id);
            if (entity != null)
                db.Set<TEntity>().Remove(entity);
        }
        public virtual void Update(string Id, TEntity entity)
        {
            db.Set<TEntity>().Update(entity);
        }
        public void Save()
        {
            db.SaveChanges();
        }


        public IEnumerable GetDoctorsForAClinic(string id)
        {
            //id "8093f94c-331f-439e-84b0-adac6d760dcc"
            var AllDoctortoClinic = db.Users.ToList();
            IEnumerable<ApplicationUser> applicationUsers = AllDoctortoClinic
              .Cast<ApplicationUser>()
             .Where(d => d.ClinicId == id)
                 .ToList();
            return applicationUsers;
        }




    }
}
