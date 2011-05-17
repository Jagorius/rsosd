namespace SchoolRegister.Model.Objects
{
    #region Usings

    using System;
    using System.Collections;
    using System.Collections.Generic;

    using SchoolRegister.Model.Abstract;
    using SchoolRegister.Model.Other;
    using SchoolRegister.Model.Repositories;

    #endregion

    /// <summary>
    /// Ta klasa potem zniknie, bo Context bêdzie gdzie w singletonie
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AzureAbstractionCollection<T> : IPersonsCollection<T>
    {
        private readonly AzureTablesSource _context;

        private readonly IList<T> _objectList;

        protected AzureAbstractionCollection(AzureTablesSource context)
        {
            _context = context;
            _objectList = new List<T>();
        }

        protected AzureAbstractionCollection(AzureTablesSource context, IList<T> list)
        {
            _context = context;
            _objectList = list;
        }

        protected AzureTablesSource Context
        {
            get
            {
                return _context;
            }
        }

        #region ICollection<T> Members

        public int Count
        {
            get
            {
                return _objectList.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public abstract void Add(T item);

        public abstract void Clear();

        public abstract bool Contains(T item);

//        public void CopyTo(T[] array, int arrayIndex)
//        {
//            throw new NotImplementedException();
//        }

        public abstract bool Remove(T item);

        public abstract void Update(T item);

        public abstract IEnumerator<T> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
//
//    public static class LinqExtensions
//    {
//        public static TableMappingObjectCollection<T> ToObjectCollection<T>(
//            this IEnumerable<T> enumerable, AzureTablesSource context)
//        {
//            return new TableMappingObjectCollection<T>(context, enumerable.ToList());
//        }
//    }
}