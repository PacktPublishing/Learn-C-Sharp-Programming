using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.ExceptionServices;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace chapter_14_02_05
{
    [TestClass]
    public class CustomExceptions
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.ThrowsException<DataLayerException>(() => GetCustomerNames("John"));
        }

        public IList<string> GetCustomerNames(string queryKeyword)
        {
            var repository = new Repository();
            try
            {
                return repository.GetCustomerNames(queryKeyword);
            }
            catch (Exception err)
            {
                throw new DataLayerException($"Error on repository {repository.RepositoryName}",
                    err, queryKeyword);
            }
        }

        public class Repository
        {
            public string RepositoryName { get; } = "DiskRepository";
            public IList<string> GetCustomerNames(string queryKeyword)
            {
                throw new IOException("Something got wrong");
            }
        }

        public class DataLayerException : Exception
        {
            public DataLayerException(string queryKeyword = null)
                : base()
            {
                this.QueryKeyword = queryKeyword;
            }

            public DataLayerException(string message, string queryKeyword = null)
                : base(message)
            {
                this.QueryKeyword = queryKeyword;
            }

            public DataLayerException(string message, Exception innerException, string queryKeyword = null)
                : base(message, innerException)
            {
                this.QueryKeyword = queryKeyword;
            }

            public string QueryKeyword { get; private set; }
        }
    }
}
