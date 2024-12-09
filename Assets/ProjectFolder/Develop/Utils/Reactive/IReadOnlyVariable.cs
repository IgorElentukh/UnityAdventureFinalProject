using System;

namespace Assets.ProjectFolder.Develop.Utils.Reactive
{
    public interface IReadOnlyVariable<T>
    {
        event Action<T, T> Changed;

        T Value { get; }
    }
}
