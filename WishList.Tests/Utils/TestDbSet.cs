﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;


namespace WishList.Tests.Utils
{
        public class TestDbSet<T> : System.Data.Entity.DbSet<T>, IQueryable, IEnumerable<T>
        where T : class
        {
            ObservableCollection<T> _data;
            IQueryable _query;

            public TestDbSet()
            {
                _data = new ObservableCollection<T>();
                _query = _data.AsQueryable();
            }

            public override T Add(T entity)
            {
                _data.Add(entity);
                return entity;
            }
        

        public override T Remove(T item)
            {
                _data.Remove(item);
                return item;
            }

            public override T Attach(T item)
            {
                _data.Add(item);
                return item;
            }

            public override T Create()
            {
                return Activator.CreateInstance<T>();
            }

            public override TDerivedEntity Create<TDerivedEntity>()
            {
                return Activator.CreateInstance<TDerivedEntity>();
            }

            public override ObservableCollection<T> Local
            {
                get { return new ObservableCollection<T>(_data); }
            }

            Type IQueryable.ElementType
            {
                get { return _query.ElementType; }
            }

            System.Linq.Expressions.Expression IQueryable.Expression
            {
                get { return _query.Expression; }
            }

            IQueryProvider IQueryable.Provider
            {
                get { return _query.Provider; }
            }

        public override IEntityType EntityType => throw new NotImplementedException();

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return _data.GetEnumerator();
            }

            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                return _data.GetEnumerator();
            }
        }
    }