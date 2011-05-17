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

    public abstract class PersonsCollection<T> : IPersonsCollection<T>
    {
        private readonly SchoolRegisterTableSeviceContext _context;

        private readonly IList<T> _objectList;

        protected PersonsCollection(SchoolRegisterTableSeviceContext context)
        {
            _context = context;
            _objectList = new List<T>();
        }

        protected PersonsCollection(SchoolRegisterTableSeviceContext context, IList<T> list)
        {
            _context = context;
            _objectList = list;
        }

        protected SchoolRegisterTableSeviceContext Context
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
//            this IEnumerable<T> enumerable, SchoolRegisterTableSeviceContext context)
//        {
//            return new TableMappingObjectCollection<T>(context, enumerable.ToList());
//        }
//    }
}