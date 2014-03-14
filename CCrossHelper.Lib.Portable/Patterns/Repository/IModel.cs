/* Author : 
 * Philippe Matray
 * 
 * Date:
 * 2014-03-13
 */

using System;

namespace CCrossHelper.Lib.Portable.Patterns.Repository
{
    public interface IModel
    {
        Guid Id { get; set; }
    }
}