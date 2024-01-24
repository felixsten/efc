using Infrastructure.Contexts;
using System;
using System.Diagnostics;
using System.Linq.Expressions;


namespace Infrastructure.Repositories;

public abstract class BaseRepository<TEntity> where TEntity : class
{
    private readonly DataContext _context;

    protected BaseRepository(DataContext context)
    {
        _context = context;
    }


    public virtual TEntity Create(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }


    public virtual IEnumerable<TEntity> GetAll()
    {
        try
        {
            var result = _context.Set<TEntity>().ToList();
            if (result != null)
            {
                return result;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }


    public virtual TEntity GetOne(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var result = _context.Set<TEntity>().FirstOrDefault(predicate);
            if (result != null)
            {
                return result;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }


    public virtual TEntity Update(TEntity entity)
    {
        try
        {
            // Get the entity by its primary key
            var entry = _context.Entry(entity);
            var keyValues = entry.Metadata.FindPrimaryKey()!.Properties
                .Select(p => entry.Property(p.Name).CurrentValue)
                .ToArray();

            var entityToUpdate = _context.Set<TEntity>().Find(keyValues);

            if (entityToUpdate != null)
            {
                // Update the properties of the existing entity
                _context.Entry(entityToUpdate).CurrentValues.SetValues(entity);

                // Save changes to the database
                _context.SaveChanges();

                return entityToUpdate;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("ERROR :: " + ex.Message);
        }

        return null!;
    }


    public virtual bool Delete(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var entity = _context.Set<TEntity>().FirstOrDefault(predicate);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                _context.SaveChanges();

                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return false;
    }


    public virtual bool Exists(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var result = _context.Set<TEntity>().Any(predicate);
            return result;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return false;
    }
}
