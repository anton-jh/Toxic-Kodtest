using RestaurantChooser.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChooser.Domain.Entities;
public class EntityBase<TId> : LazyLoadingEntityBase
{
    protected TId? _id;

    public TId Id => _id ?? throw new EntityNotAttachedException();
}
