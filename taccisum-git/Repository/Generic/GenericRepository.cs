﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Common.CustomerException;
using Common.Global;
using Common.Tool.Extend;
using Common.Tool.Utility;
using Model.Common;
using Model.Entity;
using Repository.Context;


namespace Repository.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : DTO
    {
        private TacContext db;
        private DbSet<T> dbSet;

        public GenericRepository()
        {
            db = new TacContext();
            dbSet = db.Set<T>();
        }

        public GenericRepository(TacContext context)
        {
            db = context;
            dbSet = db.Set<T>();
        }


        public IQueryable<T> Get(bool isDeleted = false)
        {
            return Get(t => true, isDeleted);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> expression, bool isDeleted = false)
        {
            if (isDeleted)
            {
                return dbSet.Where(expression);
            }
            else
            {
                return dbSet.Where(t => t.IsDeleted == false).Where(expression);
            }
        }

        public T FirstOrDefault(Expression<Func<T, bool>> expression, bool isDeleted = false)
        {
            return Get(expression, isDeleted).FirstOrDefault();
        }

        public T GetEntryByPrimaryKey(params object[] primaryKey)
        {
            return dbSet.Find(primaryKey);
        }

        public T Insert(T entity)
        {
            if (entity.ID == Guid.Empty)
            {
                entity.ID = Guid.NewGuid();
            }
            
            entity.CreatedOn = DateTime.Now;
            if (entity.CreatedBy == Guid.Empty)
            {
                entity.CreatedBy = CheckCurrentUser().ID;
            }

            dbSet.Add(entity);
            return entity;
        }

        public void Delete(T entity, bool isLogic = true)
        {
            if (isLogic)
            {
                entity.IsDeleted = true;
                Update(entity);
            }
            else
            {
                dbSet.Remove(entity);
            }
        }

        public void Delete(object primaryKey, bool isLogic = true)
        {
            var entity = dbSet.Find(primaryKey);
            if (entity != null)
                Delete(entity, isLogic);
        }

        public void Update(T entity)
        {
            var oldEntity = dbSet.Where(t=>t.ID == entity.ID).AsNoTracking().First();       //不从缓存加载
            entity.CreatedOn = oldEntity.CreatedOn;
            entity.CreatedBy = oldEntity.CreatedBy;
            entity.ModifiedOn = DateTime.Now;
#if DEBUG
            try
            {
                entity.ModifiedBy = CheckCurrentUser().ID;
            }
            catch (CommonException)
            {
                entity.ModifiedBy = new Guid(GlobalConfig.ADMIN_ID);
            }
#else
            entity.ModifiedBy = CheckCurrentUser().ID;
#endif
            
            db.Entry(entity).State = EntityState.Modified;
        }


        public int Submit()
        {
            return db.SaveChanges();
        }

        private SysUser CheckCurrentUser()
        {
            CurrentUserInfo userInfo = null;
            try
            {
                userInfo = SessionHelper.Get(GlobalConfig.CURRENT_USER) as CurrentUserInfo;
            }
            catch (NullReferenceException) { }
             
            if (userInfo == null)
                throw new CommonException("用户未登陆");

            var userId = userInfo.UserID;
            var currentUser = db.SysUsers.FirstOrDefault(u => u.ID == userId);
            if (currentUser == null)
                throw new CommonException("当前登陆用户不存在");

            return currentUser;
        }

    }
}