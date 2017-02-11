using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using VideoclubAPI.Models.EF;
using VideoclubAPI.Models.EF.Views.Base;

namespace VideoclubAPI.Repositorio.Base
{
    public class Repositorio<TView, TEntity> :
        IRepositorio<TView, TEntity> where TView : class,
        IViewModel<TEntity>, new() where TEntity : class
    {
        private pruebatajamarjrEntities Context;
        public Repositorio(pruebatajamarjrEntities context)
        {
            Context = context;
        }
        protected DbSet<TEntity> DbSet
        {
            get { return Context.Set<TEntity>(); }
        }

        public void Dispose()
        {
            if (Context != null)
                Context.Dispose();
        }

        // MARCAR COMO "VIRTUAL", PARA PERMITIR SOBREESCRIBIR EL MÉTODO
        public virtual TView Add(TView model)
        {
            var data = model.ToModel();
            DbSet.Add(data);
            try
            {
                Context.SaveChanges();
                model.FromModel(data);
            }
            catch
            {
                Console.WriteLine();
                return null;
            }
            return model;
        }

        public virtual int Delete(int id)
        {
            var obj = DbSet.Find(id);
            DbSet.Remove(obj);

            int n = 0;

            try
            {
                n = Context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return n;
        }

        public virtual int Delete(Expression<Func<TEntity, bool>> busqueda)
        {
            var data = DbSet.Where(busqueda);
            foreach (var view in data)
            {
                DbSet.Remove(view);
            }

            try
            {
                return Context.SaveChanges();
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public virtual List<TView> Find(Expression<Func<TEntity, bool>> busqueda)
        {
            var data = DbSet.Where(busqueda);
            var lista = new List<TView>();
            foreach (var obj in data)
            {
                var view = new TView();
                view.FromModel(obj);
                lista.Add(view);
            }
            return lista;
        }

        public virtual List<TView> Get()
        {
            var lista = new List<TView>();
            var data = DbSet;
            foreach (var obj in data)
            {
                var v = new TView();
                v.FromModel(obj);
                lista.Add(v);
            }
            return lista;
        }

        public virtual TView Get(int pk)
        {
            var model = DbSet.Find(pk);
            var view = new TView();
            view.FromModel(model);
            return view;
        }

        public virtual TEntity GetModelByPk(TView model)
        {
            int[] pks = model.GetPk();
            TEntity data = null;
            if (pks.Length == 1)
            {
                data = DbSet.Find(pks[0]);
            }
            else if (pks.Length == 2)
            {
                data = DbSet.Find(pks[0], pks[1]);
            }
            else if (pks.Length == 3)
            {
                data = DbSet.Find(pks[0], pks[1], pks[2]);
            }

            return data;
        }

        public virtual TView Update(TView model)
        {
            var data = GetModelByPk(model);
            model.UpdateModel(data);
            try
            {
                int r = Context.SaveChanges();
                model.FromModel(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            return model;
        }
    }
}