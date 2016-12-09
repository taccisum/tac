using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Entity;
using Repository.Generic;

namespace Repository.Test
{
    [TestClass]
    public class RepositoryFactoryTest
    {
        private RepositoryFactory _factory;

        [TestInitialize]
        public void Init()
        {
            _factory = new RepositoryFactory();
        }

        [TestMethod]
        public void TestUniqueRepository()
        {
            var repo1 = _factory.At<SysUserDemo>();
            var repo2 = _factory.At<SysUserDemo>();
            if (!repo1.Equals(repo2))
            {
                Assert.Fail("两个Repository不是同一实例");
            }
        }
    }
}
