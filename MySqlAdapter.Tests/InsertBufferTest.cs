using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ITsoft.Extensions.MySql.Tests
{
    /// <summary>Этот класс содержит параметризованные модульные тесты для InsertBuffer</summary>
    [TestClass]
    public partial class InsertBufferTest
    {
        MySqlAdapter adapter;


        [TestInitialize]
        public void Initialize()
        {
            adapter = new MySqlAdapter("User Id=test; Password=test; Host=localhost;Character Set=utf8;");
            adapter.Error += Adapter_Error;
        }

        [TestMethod]
        public void InsertTest()
        {
            int packageSize = 3;
            int totalCount = 5;

            adapter.Execute(@"
                            DROP TABLE IF EXISTS test.buffer_test;
                            CREATE TABLE test.buffer_test (
                              id int(11) NOT NULL,
                              value varchar(255) DEFAULT NULL,
                              PRIMARY KEY (id)
                            )
                            ENGINE = INNODB;
                            ");

            InsertBuffer buffer = new InsertBuffer(adapter, packageSize, "test.buffer_test", false, "id", "value");
            for (int i = 0; i < totalCount; i++)
            {
                buffer.Add(i, $"value_{i}");
            }

            //автоматическая вставка
            var firstResult = adapter.SelectScalar<int>("SELECT COUNT(bt.id) FROM test.buffer_test bt");
            Assert.AreEqual(firstResult.Value, packageSize);

            //принудитеьная вставка
            buffer.Insert();
            var secondResult = adapter.SelectScalar<int>("SELECT COUNT(bt.id) FROM test.buffer_test bt");
            Assert.AreEqual(secondResult.Value, totalCount);
        }

        private void Adapter_Error(Exception ex, string query)
        {
            throw new Exception("Ошибка выполнения запроса");
        }
    }
}
