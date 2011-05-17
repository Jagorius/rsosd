namespace SchoolRegister.Model.Abstract
{
    using System.Collections;
    using System.Collections.Generic;

    public interface IPersonsCollection<T> : IEnumerable<T>
    {
        int Count { get; }

        void Add(T item);

        bool Remove(T item);


        void Clear();
    }
}