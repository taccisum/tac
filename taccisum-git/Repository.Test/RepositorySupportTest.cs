using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Dao.Impl.Sys;
using Repository.Dao.Interf.Sys;

namespace Repository.Test
{
    [TestClass]
    public class RepositorySupportTest
    {
        private ISysUserDemoDao dao;


        [TestInitialize]
        public void Init()
        {
            dao = new SysUserDemoDaoImpl();
        }


        [TestMethod]
        public void TestQuery()
        {
            dao.Query();
            dao.Query(d => d.IsDeleted);
        }
    }
}
