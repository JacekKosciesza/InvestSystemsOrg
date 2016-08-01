using System;

namespace InvSys.Shared.Core.State
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
