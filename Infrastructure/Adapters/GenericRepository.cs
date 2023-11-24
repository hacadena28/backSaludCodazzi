using System.Linq.Expressions;
using Domain.Entities.Base;
using Domain.Ports;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Adapters;

public class GenericRepository<E> : IGenericRepository<E> where E : DomainEntity
{
    private readonly PersistenceContext _context;

    public GenericRepository(PersistenceContext context)
    {
        _context = context;
    }

    public async Task<E> AddAsync(E entity)
    {
        _ = entity ?? throw new ArgumentNullException(nameof(entity), "Entity can not be null");
        _context.Set<E>().Add(entity);
        await CommitAsync();
        return entity;
    }

    public async Task DeleteAsync(ISoftDelete entity, bool deleteCascade = true)
    {
        if (entity is { DeletedOn: not null })
        {
            return;
        }

        entity.SetDelete();

        if (deleteCascade)
        {
            var relatedEntities = entity.GetType()
                .GetProperties()
                .Where(prop => typeof(ISoftDelete).IsAssignableFrom(prop.PropertyType))
                .Select(prop => prop.GetValue(entity) as ISoftDelete);

            foreach (var relatedEntity in relatedEntities)
            {
                if (relatedEntity is { DeletedOn: null }) await DeleteAsync(relatedEntity);
            }
        }

        await CommitAsync();
    }

    public async Task<PagedResult<E>> GetPagedAsync(int page, int pageSize)
    {
        var result = new PagedResult<E>
        {
            TotalRecords = await _context.Set<E>().CountAsync()
        };

        result.TotalPages = (int)Math.Ceiling(result.TotalRecords / (double)pageSize);

        result.Records = await _context.Set<E>()
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return result;
    }


    public async Task<PagedResult<E>> GetPagedFilterAsync(int page, int pageSize, Expression<Func<E, bool>>? filter =
            null,
        Func<IQueryable<E>, IOrderedQueryable<E>>? orderBy = null, string includeStringProperties = "",
        bool isTracking = false)
    {
        IQueryable<E> query = _context.Set<E>();

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (!string.IsNullOrEmpty(includeStringProperties))
        {
            foreach (var includeProperty in includeStringProperties.Split
                         (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
        }

        var resultPagination = new PagedResult<E>
        {
            TotalRecords = await query.CountAsync()
        };

        resultPagination.TotalPages = (int)Math.Ceiling(resultPagination.TotalRecords / (double)pageSize);

        if (orderBy != null)
        {
            resultPagination.Records = await orderBy(query)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync().ConfigureAwait(false);

            return resultPagination;
        }

        resultPagination.Records = (!isTracking) ? await query.AsNoTracking().ToListAsync() : await query.ToListAsync();

        return resultPagination;
    }

    public async Task<IEnumerable<E>> GetAsync(Expression<Func<E, bool>>? filter = null,
        Func<IQueryable<E>, IOrderedQueryable<E>>? orderBy = null, string includeStringProperties = "",
        bool isTracking = false)
    {
        IQueryable<E> query = _context.Set<E>();

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (!string.IsNullOrEmpty(includeStringProperties))
        {
            foreach (var includeProperty in includeStringProperties.Split
                         (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
        }

        if (orderBy != null)
        {
            return await orderBy(query).ToListAsync().ConfigureAwait(false);
        }

        return (!isTracking) ? await query.AsNoTracking().ToListAsync() : await query.ToListAsync();
    }

    public async Task<IEnumerable<E>> GetAsync(Expression<Func<E, bool>>? filter = null,
        Func<IQueryable<E>, IOrderedQueryable<E>>? orderBy = null, bool isTracking = false,
        params Expression<Func<E, object>>[] includeObjectProperties)
    {
        IQueryable<E> query = _context.Set<E>();

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (includeObjectProperties != null)
        {
            foreach (Expression<Func<E, object>> include in includeObjectProperties)
            {
                query = query.Include(include);
            }
        }

        if (orderBy != null)
        {
            return await orderBy(query).ToListAsync();
        }

        return (!isTracking) ? await query.AsNoTracking().ToListAsync() : await query.ToListAsync();
    }

    public async Task<E> GetByIdAsync(object id)
    {
        return await _context.Set<E>().FindAsync(id);
    }

    public async Task<bool> Exist(Expression<Func<E, bool>> filter)
    {
        return await _context.Set<E>().AnyAsync(filter);
    }

    public async Task UpdateAsync(E entity)
    {
        if (entity != null)
        {
            _context.Set<E>().Update(entity);
            await CommitAsync();
        }
    }

    private async Task CommitAsync()
    {
        _context.ChangeTracker.DetectChanges();

        foreach (var entry in _context.ChangeTracker.Entries())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Property("CreatedOn").CurrentValue = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Property("LastModifiedOn").CurrentValue = DateTime.UtcNow;
                    break;
                case EntityState.Detached:
                    break;
                case EntityState.Unchanged:
                    break;
                case EntityState.Deleted:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        await _context.CommitAsync().ConfigureAwait(false);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        this._context.Dispose();
    }
}