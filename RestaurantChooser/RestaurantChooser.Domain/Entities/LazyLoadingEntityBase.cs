using RestaurantChooser.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChooser.Domain.Entities;
public abstract class LazyLoadingEntityBase
{
    /// <summary>
    /// Will be injected by EF when the entity is attached to a context
    /// </summary>
    protected Action<object, string>? LazyLoader { get; private set; }

    /// <summary>
    /// IMPORTANT! Needs to be called either directly from the navigation property's getter,
    /// or with the second argument set to the navigation property's name!
    /// </summary>
    /// <typeparam name="TRelated"></typeparam>
    /// <param name="navigationField"></param>
    /// <param name="navigationName"></param>
    /// <returns>The entity guaranteed to be loaded by Ef</returns>
    /// <exception cref="EntityNotAttachedException"></exception>
    protected TRelated LazyLoad<TRelated>(
        ref TRelated? navigationField,
        [CallerMemberName] string navigationName = null!)
        where TRelated : class?
    {
        // Throw if the LazyLoader has not been set by EF (an effect of the entity not being attached to a context)
        if (LazyLoader is null)
        {
            throw new EntityNotAttachedException();
        }

        // Use the lazy loader action
        LazyLoader.Invoke(this, navigationName);

        // Assure that the navigationField now is not null. It being null would indicate an issue with the EF setup.
        return navigationField!;
    }

    /// <summary>
    /// A shorthand for getting the HashSet behind a lazy loaded IEnumerable property
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="enumerable"></param>
    /// <returns></returns>
    protected static HashSet<T> Actual<T>(IEnumerable<T> enumerable) => (HashSet<T>)enumerable;
}
