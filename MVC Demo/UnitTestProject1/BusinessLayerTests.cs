using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class BusinessLayerTests
    {
        [TestMethod]
        public void EmployeesProperty()
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            List<Employee> emps = employeeBusinessLayer.Employees.ToList();

            Assert.AreEqual(4, emps.Count);
            

        }
    }
}
