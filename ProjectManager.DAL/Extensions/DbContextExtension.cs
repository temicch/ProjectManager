using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjectManager.DAL.Entities;

namespace ProjectManager.DAL.Extensions
{
    internal static class DbContextExtension
    {
        public static void DetachLocal<T>(this DbContext context, T t, int entryId)
            where T : class, IBaseEntity<int>
        {
            var local = context.Set<T>()
                .Local
                .FirstOrDefault(entry => entry.Id == entryId);

            if (local != null) context.Entry(local).State = EntityState.Detached;
            context.Entry(t).State = EntityState.Modified;
        }
    }
}