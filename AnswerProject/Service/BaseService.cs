using AnswerProject.DTO;
using AnswerProject.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AnswerProject.Service
{
    public abstract class BaseService
    {
        readonly protected AnswerContext ctx;
        readonly protected ILogger logger;
        readonly protected IMapper mapper;

        public BaseService(AnswerContext ctx, ILogger logger, IMapper mapper)
        {
            this.ctx = ctx;
            this.logger = logger;
            this.mapper = mapper;
        }

        protected Task<List<TDTO>> GetItems<TDTO, T>(Expression<Func<TDTO, object>> order = null,
            Expression<Func<T, bool>> whereFunc = null)
            where T : BaseEntity
            where TDTO : BaseEntityDTO
        {
            IQueryable<T> query = ctx.Set<T>();
            if (whereFunc != null)
                query = query.Where(whereFunc);
            var result = mapper.ProjectTo<TDTO>(query);
            if (order == null)
                result = result.OrderBy(c => c.Id);
            else
                result = result.OrderBy(order);
            return result.ToListAsync();
        }

        protected async Task<TDTO> GetItem<TDTO, T>(long id)
            where T : BaseEntity
            where TDTO : BaseEntityDTO
        {
            var item = await ctx.Set<T>().FindAsync(id);
            if (item == null)
                return null;
            var itemDto = mapper.Map<TDTO>(item);
            return itemDto;
        }

        protected async Task<TDTO> GetItemByFunc<TDTO, T>(Expression<Func<T, bool>> func)
            where T : BaseEntity
            where TDTO : BaseEntityDTO
        {
            var item = await ctx.Set<T>().Where(func).FirstOrDefaultAsync();
            if (item == null)
                return null;
            var itemDto = mapper.Map<TDTO>(item);
            return itemDto;
        }

        protected T AddItem<T>(BaseEntityDTO dto)
            where T : BaseEntity
        {
            var item = mapper.Map<T>(dto);
            ctx.Set<T>().Add(item);
            return item;
        }

        protected async Task<bool> EditItem<T>(BaseEntityDTO dto,
            Action<T> action = null, bool mapToOne = true)
            where T : BaseEntity
        {
            var ent = mapper.Map<T>(dto);
            var item = await ctx.Set<T>().FindAsync(ent.Id);
            if (item == null)
                return false;
            if (mapToOne)
                mapper.Map(dto, item);
            else
                item = mapper.Map<T>(dto);
            if (action != null)
                action.Invoke(item);
            return await ctx.SaveChangesAsync() > 0;
        }

        protected async Task<bool> DeleteItem<T>(BaseEntityDTO dto)
            where T : BaseEntity
        {
            var set = ctx.Set<T>();
            var ent = mapper.Map<T>(dto);
            var item = await set.FindAsync(ent.Id);
            if (item == null)
                return false;
            set.Remove(item);
            return await ctx.SaveChangesAsync() > 0;
        }
    }
}
