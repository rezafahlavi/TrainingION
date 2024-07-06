using DomainModelFramework;
using DomainModelFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace TrainingDomainModel
{
    public class DomainRepository<T> : BaseRepository<T> where T : BaseEntity
    {
        public DomainRepository()
        {
            this._context = new TrainingDBEntities();

        }

        public override int Save(long userId)
        {
            List<Object> modifiedOrAddedEntities = _context.ChangeTracker.Entries().Where(x => x.State == EntityState.Modified || x.State == EntityState.Added).Select(x => x.Entity).ToList();

            return base.Save(userId);
        }
    }
}
