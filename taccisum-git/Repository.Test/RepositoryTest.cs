using System;
using Common.Global;
using Common.Tool.Extend;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Entity;
using Repository.Generic;

namespace Repository.Test
{
    [TestClass]
    public class RepositoryTest
    {
        private RepositoryFactory _factory;
        private IGenericRepository<SysUserDemo> _repo;

        [TestInitialize]
        public void Init()
        {
            _factory = new RepositoryFactory();
            _repo = _factory.At<SysUserDemo>();
        }


        [TestMethod]
        public void TestGet()
        {
            var entry = _repo.FirstOrDefault(u => true);
            _repo.Get();
            _repo.GetEntryByPrimaryKey(entry.ID);
        }

        [TestMethod]
        public void TestAdd()
        {
            var entry = InsertAndSubmit(GetTestEntry());

            if (entry.ID == Guid.Empty)
            {
                Assert.Fail("未设置实体ID的情况下插入的数据ID不应为空");
            }
            if (entry.CreatedBy != new Guid(GlobalConfig.ADMIN_ID))
            {
                Assert.Fail("未设置实体CreatedBy的情况下插入的数据CreatedBy字段应该是当前登陆用户ID（DEBUG模式下为ADMIN用户ID）");
            }

            if (entry.IsDeleted)
            {
                Assert.Fail("新插入的数据IsDeleted为true毫无意义");
            }
        }

         [TestMethod]
        public void TestAddSpecifyIdAndCreatedBy()
        {
            var id = Guid.NewGuid();
             var c_id = Guid.NewGuid();

            var entry = InsertAndSubmit(new SysUserDemo()
             {
                 ID = id,
                 Account = "test_" + new Random().Next(10000000),
                 Password = "123456".ToMD5(),
                 NickName = "TEST_ENTRY",
                 CreatedBy = c_id
             });

            if (entry.ID != id)
            {
                Assert.Fail("插入的数据ID不为" + id);
            }

            if (entry.CreatedBy != c_id)
             {
                 Assert.Fail("插入的数据CreatedBy值不为" + c_id);
             }
        }

        [TestMethod]
        public void TestLogicalDelete()
        {
            var entry = InsertAndSubmit(GetTestEntry());

            _repo.Delete(entry);
            _factory.Submit();
            var newEntry = _repo.GetEntryByPrimaryKey(entry.ID);

            if (!newEntry.IsDeleted)
            {
                Assert.Fail("逻辑删除失败，ID为" + entry.ID + "的IsDeleted标识仍为false");
            }
        }

        [TestMethod]
        public void TestPhysicalDelete()
        {
            var entry = InsertAndSubmit(GetTestEntry());

            _repo.Delete(entry, false);
            _factory.Submit();

            if (_repo.GetEntryByPrimaryKey(entry.ID) != null)
            {
                Assert.Fail("物理删除失败，实体仍然存在");
            }
        }

        [TestMethod]
        public void TestUpdate()
        {
            var entry = InsertAndSubmit(GetTestEntry());

            entry.NickName = "abcdefghello";
            _repo.Update(entry);
            _factory.Submit();

            var newEntry = _repo.GetEntryByPrimaryKey(entry.ID);

            if (newEntry.NickName != "abcdefghello")
            {
                Assert.Fail("更新条目失败");
            }
        }

        [TestMethod]
        public void TestCantBeUpdateFiled()
        {
            var entry = InsertAndSubmit(GetTestEntry());

            entry.CreatedOn = new DateTime(1999, 9, 9);
            entry.CreatedBy = Guid.Empty;
            entry.ModifiedOn = new DateTime(1999, 9, 9);
            entry.ModifiedBy = Guid.Empty;

            _repo.Update(entry);
            _factory.Submit();

            var newEntry = _repo.GetEntryByPrimaryKey(entry.ID);
            if (newEntry.CreatedOn == new DateTime(1999, 9, 9))
            {
                Assert.Fail("条目的字段CreatedOn不应被更新，该字段为不允许更改的字段");
            }
            if (newEntry.CreatedBy == Guid.Empty)
            {
                Assert.Fail("条目的字段CreatedBy不应被更新，该字段为不允许更改的字段");
            }
            if (newEntry.ModifiedOn == new DateTime(1999, 9, 9))
            {
                Assert.Fail("条目的字段ModifiedOn不应被更新，该字段为不允许更改的字段");
            }
            if (newEntry.ModifiedBy == Guid.Empty)
            {
                Assert.Fail("条目的字段ModifiedBy不应被更新，该字段为不允许更改的字段");
            }
        }

        #region private method
        private SysUserDemo InsertAndSubmit(SysUserDemo entry)
        {
            var temp = _repo.Insert(entry);
            _factory.Submit();
            return temp;
        }

        private SysUserDemo GetTestEntry()
        {
            return new SysUserDemo()
            {
                Account = "test_" + new Random().Next(10000000),
                Password = "123456".ToMD5(),
                NickName = "TEST_ENTRY",
                CreatedBy = new Guid(GlobalConfig.ADMIN_ID), //TODO::
            };
        }
        #endregion
    }
}
