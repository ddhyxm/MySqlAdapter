using System;
using Extensions.MySql;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Extensions.MySql.Tests
{
    /// <summary>Этот класс содержит параметризованные модульные тесты для InsertBuffer</summary>
    [TestClass]
    [PexClass(typeof(InsertBuffer))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class InsertBufferTest
    {

        /// <summary>Тестовая заглушка для .ctor(MySqlAdapter, Int32, String, Boolean, String[])</summary>
        [PexMethod]
        public InsertBuffer ConstructorTest(
            MySqlAdapter adapter,
            int packegeSize,
            string table,
            bool insertIgnore,
            string[] columns
        )
        {
            InsertBuffer target = new InsertBuffer(adapter, packegeSize, table, insertIgnore, columns);
            return target;
            // TODO: добавление проверочных утверждений в метод InsertBufferTest.ConstructorTest(MySqlAdapter, Int32, String, Boolean, String[])
        }

        /// <summary>Тестовая заглушка для Add(String)</summary>
        [PexMethod]
        public int AddTest([PexAssumeUnderTest]InsertBuffer target, string values)
        {
            int result = target.Add(values);
            return result;
            // TODO: добавление проверочных утверждений в метод InsertBufferTest.AddTest(InsertBuffer, String)
        }

        /// <summary>Тестовая заглушка для Add(String[])</summary>
        [PexMethod]
        public int AddTest01([PexAssumeUnderTest]InsertBuffer target, string[] values)
        {
            int result = target.Add(values);
            return result;
            // TODO: добавление проверочных утверждений в метод InsertBufferTest.AddTest01(InsertBuffer, String[])
        }

        /// <summary>Тестовая заглушка для Add(Object[])</summary>
        [PexMethod]
        public int AddTest02([PexAssumeUnderTest]InsertBuffer target, object[] values)
        {
            int result = target.Add(values);
            return result;
            // TODO: добавление проверочных утверждений в метод InsertBufferTest.AddTest02(InsertBuffer, Object[])
        }

        /// <summary>Тестовая заглушка для AddSingle(String)</summary>
        [PexMethod]
        public void AddSingleTest([PexAssumeUnderTest]InsertBuffer target, string value)
        {
            target.AddSingle(value);
            // TODO: добавление проверочных утверждений в метод InsertBufferTest.AddSingleTest(InsertBuffer, String)
        }

        /// <summary>Тестовая заглушка для BeginAdd()</summary>
        [PexMethod]
        public void BeginAddTest([PexAssumeUnderTest]InsertBuffer target)
        {
            target.BeginAdd();
            // TODO: добавление проверочных утверждений в метод InsertBufferTest.BeginAddTest(InsertBuffer)
        }

        /// <summary>Тестовая заглушка для EndAdd(Boolean)</summary>
        [PexMethod]
        public void EndAddTest([PexAssumeUnderTest]InsertBuffer target, bool apply)
        {
            target.EndAdd(apply);
            // TODO: добавление проверочных утверждений в метод InsertBufferTest.EndAddTest(InsertBuffer, Boolean)
        }

        /// <summary>Тестовая заглушка для Insert()</summary>
        [PexMethod]
        public int InsertTest([PexAssumeUnderTest]InsertBuffer target)
        {
            int result = target.Insert();
            return result;
            // TODO: добавление проверочных утверждений в метод InsertBufferTest.InsertTest(InsertBuffer)
        }
    }
}
