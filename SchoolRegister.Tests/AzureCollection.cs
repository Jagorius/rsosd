namespace SchoolRegister.Tests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using SchoolRegister.Model.Abstract;

    public class FakePersonsCollection<T> : IPersonsCollection<T>, ICollection<T>
    {

        private IList<T> _collection;

        public FakePersonsCollection()
        {
            _collection = new List<T>();
        }


        public IEnumerator<T> GetEnumerator()
        {
            return _collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count
        {
            get
            {
                return _collection.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(T item)
        {
            _collection.Add(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _collection.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return _collection.Remove(item);
        }

        public void Update(T item)
        {
            _collection.Remove(item);
            _collection.Add(item);
        }

        public void Clear()
        {
            _collection.Clear();
        }

        public bool Contains(T item)
        {
            return _collection.Contains(item);
        }
    }
}