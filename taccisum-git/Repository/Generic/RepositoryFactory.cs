using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using Common.Global;
using Model.Entity;
using Repository.Context;

namespace Repository.Generic
{
    public class RepositoryFactory
    {
        private Dictionary<string, object> _units;
        private TacContext _context;
        

        public RepositoryFactory()
        {
            //建立线程内唯一的db context，减少不必要的资源开销
            var temp = CallContext.GetData(GlobalConfig.DataSink.EF_DB_CONTEXT) as TacContext;
            if (temp == null)
            {
                temp = new TacContext();
                CallContext.SetData(GlobalConfig.DataSink.EF_DB_CONTEXT, temp);
            }
            _context = temp;

            _units = new Dictionary<string, object>();
        }


        public IGenericRepository<TModel> At<TModel>() where TModel : DTO
        {
            var key = typeof (TModel).FullName;

            if (_units.ContainsKey(key))
            {
                return (IGenericRepository<TModel>) _units[key];
            }
            else
            {
                var unit = new GenericRepository<TModel>(_context);
                _units.Add(key, unit);

                return unit;
            }
        }

        public int Submit()
        {
            return _context.SaveChanges();
        }
    }
}
