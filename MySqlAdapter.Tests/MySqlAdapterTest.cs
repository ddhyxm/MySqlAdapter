// <copyright file="MySqlAdapterTest.cs">Copyright ©  2019</copyright>
using System;
using ITsoft.Extensions.MySql;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ITsoft.Extensions.MySql.Tests
{
    /// <summary>Этот класс содержит параметризованные модульные тесты для MySqlAdapter</summary>
    [PexClass(typeof(MySqlAdapter))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class MySqlAdapterTest
    {
        MySqlAdapter adapter;
        string testrResult = null;

        [TestInitialize]
        public void Initialize()
        {
            adapter = new MySqlAdapter("User Id=test; Password=test; Host=localhost;Character Set=utf8;");
            adapter.Error += Adapter_Error;
        }

        private void Adapter_Error(Exception ex, string query)
        {
            testrResult = query;
        }

        [TestMethod]
        public void SelectDataTableTest()
        {
            var dt = adapter.Select("SELECT * FROM test.test_table WHERE id = 1", 0);

            Assert.IsNotNull(dt);
            Assert.AreEqual(dt.Rows.Count, 1);
        }

        [TestMethod]
        public void SelectReaderTest()
        {
            adapter.SelectReader("SELECT * FROM test.test_table WHERE id = 1", (row) => 
            {
                int id = Convert.ToInt32(row[0]);
                Assert.AreEqual(id, 1);
            });
        }

        [TestMethod]
        public void SelectRowTest()
        {
            var dt = adapter.SelectRow("SELECT * FROM test.test_table WHERE id = 1", 0);

            Assert.IsNotNull(dt);
        }

        [TestMethod]
        public void SelectScalarTest()
        {
            var result = adapter.SelectScalar<string>("SELECT value FROM test.test_table WHERE id = 1", 0);

            Assert.IsNotNull(result);
            Assert.IsFalse(result.DbNull);
            Assert.AreEqual(result.Value, "test");
        }

        [TestMethod]
        public void SelectDataSetTest()
        {
            var dt = adapter.SelectDataSet("SELECT * FROM test.test_table WHERE id = 1", 0);

            Assert.IsNotNull(dt);
            Assert.AreEqual(dt.Tables.Count, 1);
            Assert.AreEqual(dt.Tables[0].Rows.Count, 1);
        }

        [TestMethod]
        public void ExecuteWithSyntaxError()
        {
            var dt = adapter.SelectRow("syntax error", 0);
            Assert.IsNull(dt);
            Assert.AreEqual(testrResult, "syntax error");
        }
    }
}
