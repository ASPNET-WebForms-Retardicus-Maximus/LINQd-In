namespace LINQdIn.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Models;

    public interface IApplicationDbContext : IDisposable
    {
        int SaveChanges();

        IDbSet<User> Users { get; set; }

        IDbSet<Skill> Skills { get; set; }

        IDbSet<Education> Education { get; set; }

        IDbSet<Endorsement> Endorsements { get; set; }

        IDbSet<Update> Updates { get; set; }

        IDbSet<Connection> Connections { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
