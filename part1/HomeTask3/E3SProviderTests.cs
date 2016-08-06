using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinqProviderTelescope.E3SClient.Entities;
using LinqProviderTelescope.E3SClient;
using System.Configuration;
using System.Linq;

namespace LinqProviderTelescope
{
	[TestClass]
	public class E3SProviderTests
	{
        /// <summary>
        /// Метод для тестирования запросов к E3SClient (Telescope)
        /// </summary>
		[TestMethod]
        public void E3SClientWithProvider()
		{
			var employees = new E3SEntitySet<EmployeeEntity>(ConfigurationManager.AppSettings["user"], ConfigurationManager.AppSettings["password"]);

            Console.WriteLine("Constant = Member -> test");
            foreach (var emp in employees.Where(e => "EPRUIZHW0249" == e.workstation))
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", emp.workstation, emp.nativename, emp.startworkdate, emp.office, emp.room);
            }
            Console.WriteLine("\n");

            Console.WriteLine("Member = Constant -> test");
            foreach (var emp in employees.Where(e => e.workstation == "EPRUIZHW0249"))
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", emp.workstation, emp.nativename, emp.startworkdate, emp.office, emp.room);
            }
            Console.WriteLine("\n");

            Console.WriteLine("StartsWith -> test");
            foreach (var emp in employees.Where(e => e.workstation.StartsWith("EPRUIZHW006")))
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", emp.workstation, emp.nativename, emp.startworkdate, emp.office, emp.room);
            }
            Console.WriteLine("\n");

            Console.WriteLine("EndsWith -> test");
            foreach (var emp in employees.Where(e => e.workstation.EndsWith("IZHW0066")))
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", emp.workstation, emp.nativename, emp.startworkdate, emp.office, emp.room);
            }
            Console.WriteLine("\n");

            Console.WriteLine("Contains -> test");
            foreach (var emp in employees.Where(e => e.workstation.Contains("IZHW")))
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", emp.workstation, emp.nativename, emp.startworkdate, emp.office, emp.room);
            }
            Console.WriteLine("\n");

            Console.WriteLine("AND operator + Contains + Equals -> test");
            foreach (var emp in employees.Where(e => e.workstation.Contains("IZHW00") && e.room == "2" && e.office.Contains("Marx")))
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", emp.workstation, emp.nativename, emp.startworkdate, emp.office, emp.room);
            }
        }
	}
}
