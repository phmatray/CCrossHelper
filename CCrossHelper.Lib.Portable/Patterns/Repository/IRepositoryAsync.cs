/* Author : 
 * Philippe Matray
 * 
 * Date:
 * 2014-03-13
 */

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCrossHelper.Lib.Portable.Patterns.Repository
{
    public interface IRepositoryAsync<T>
        where T : IModel
    {
        Task<IList<T>> GetAll();
        Task<T> GetById(Guid elementId);
        Task<bool> Insert(T element);
        Task<bool> Delete(Guid elementId);
        Task<bool> Update(T element);
        Task<bool> Save();
    }
}