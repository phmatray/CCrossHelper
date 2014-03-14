/* Author : 
 * Philippe Matray
 * 
 * Date:
 * 2014-03-13
 */

using System;
using System.Collections.Generic;

namespace CCrossHelper.Lib.Portable.Patterns.Repository
{
    public interface IRepository<T>
        where T : IModel
    {
        IList<T> GetAll();
        T GetById(Guid elementId);
        bool Insert(T element);
        bool Delete(Guid elementId);
        bool Update(T element);
        bool Save();
    }
}