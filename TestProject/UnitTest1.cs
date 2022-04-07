using DataAccessLib;
using Medicure_Entity;
using NUnit.Framework;

namespace TestProject
{
    public class Tests
    {
        //[SetUp]
        //public void Setup()
        //{
        //}

        [Test]
        public void GetPaitentById()
        {
            Paitents_Dal p = new Paitents_Dal();

            var er = p.GetPaitentById(1).Name;
            var ar = "dasfa";

            Assert.AreEqual(er,ar);
        }
        public void NewPaitents()
        {

        }
    }
}