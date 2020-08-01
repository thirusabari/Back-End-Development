using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Query_Method_Example
{
	public class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("LINQ Query Method Example");
			Console.WriteLine("");
			List<Customers> customers = new List<Customers>()
			{
				new Customers { CustomerId=1,  CustomerName="John", Age=13},
				new Customers { CustomerId=2,  CustomerName="Smith", Age=45},
				new Customers { CustomerId=3,  CustomerName="Will", Age=23},
				new Customers { CustomerId=4,  CustomerName="rocky", Age=55},
				new Customers { CustomerId=5,  CustomerName="rick", Age=67}
			};
			List<Customers> customers1 = new List<Customers>()
			{
				new Customers { CustomerId=5, CustomerName="rick", Age=67},
				new Customers { CustomerId=6, CustomerName="Vasu", Age=34},
				new Customers { CustomerId=7, CustomerName="Ammu", Age=48}
			};
			Console.WriteLine("Combining Two Lists");
			Console.WriteLine();
			var cusCombine = customers.Union(customers1).ToList();
			foreach(var cm in cusCombine)
			{
				Console.WriteLine("CustomerId: {0} , CustomerName: {1} , Age: {2}", cm.CustomerId, cm.CustomerName, cm.Age);
			}
			Console.WriteLine();
			Console.WriteLine("concatListByCustomerId");
			Console.WriteLine();
			var concatListByCustomerId = (from cus in customers
							   where cus.CustomerId != 5
							   select cus).Concat(from cus1 in customers1
											   where cus1.CustomerId != 5
											   select cus1);

			foreach (var con in concatListByCustomerId)
			{
				Console.WriteLine("CustomerId: {0} , CustomerName: {1} , Age: {2}", con.CustomerId, con.CustomerName, con.Age);
			}
			Console.WriteLine();
			Console.WriteLine("Combining Two Interger Lists");
			Console.WriteLine();
			List<int> Section1 = new List<int>() { 1,2,3,4,6,8,9,10};
			List<int> Section2 = new List<int>() { 1, 2, 5,8,9,10,11,45,57,15,20 };
			var uniqueSections = Section1.Union(Section2).Distinct().OrderBy(i=> i).ToList();
			foreach(var uq in uniqueSections)
			{
				Console.WriteLine(uq);
			}
			Console.WriteLine();
			Console.WriteLine("Section1 Except Section2");
			var exceptSection2 = Section1.Except(Section2);
			foreach (var exp in exceptSection2)
			{
				Console.WriteLine(exp);
			}
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("Section2 Except Section1");
			var exceptSection1 = Section2.Except(Section1);
			foreach (var expsec1 in exceptSection1)
			{
				Console.WriteLine(expsec1);
			}
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("Number of Elements in Sections");
			var combineSections = Section1.Union(Section2);
			foreach (var expsec1 in combineSections)
			{
				Console.WriteLine(expsec1);
			}
			Console.WriteLine();
			List<Customers> customers2 = new List<Customers>()
			{
				new Customers { CustomerId=10, CustomerName="Arul", Age=23},
				new Customers { CustomerId=11, CustomerName="Vimala", Age=45},
				new Customers { CustomerId=12, CustomerName="Thirunavukkarasu", Age=89}
			};
			Console.WriteLine("Add Customers2 with Customers Table");
			customers.AddRange(customers2);
			foreach (var customer in customers)
			{
				Console.WriteLine("CustomerId: {0} , CustomerName: {1} , Age: {2}", customer.CustomerId, customer.CustomerName, customer.Age);
			}
			Console.WriteLine();
			Console.WriteLine("Removing Elements from Customers2 And Count the Total Number of Elements in Customers2");
			customers2.Clear();
			Console.WriteLine("The Number of Elements in Customers2:{0}",customers2.Count());
			Console.WriteLine();
			Console.WriteLine("All Method: Check Customer List  Values are Greater than 20");
			var isAgeGreaterThan20 = customers.All(cs => cs.Age > 20);
			Console.WriteLine("isAgeGreaterThan20 Exists in Customers List = {0}",isAgeGreaterThan20);
			Console.WriteLine();
			Console.WriteLine("Any Method: Check Customer List  Values having age of 13");
			var isAgehaving13 = customers.Any(cs => cs.Age == 13);
			Console.WriteLine("isAgeGreaterThan13 Exists in Customers List = {0}", isAgehaving13);
			Console.WriteLine();
			Console.WriteLine("Contains Method: Check Customers Contains John");
			var containsJohn = (from cus in customers
								 where cus.CustomerName == "John"
								 select cus).FirstOrDefault();
			Console.WriteLine("CustomerId: {0} , CustomerName: {1} , Age: {2}", containsJohn.CustomerId, containsJohn.CustomerName, containsJohn.Age);
			Console.WriteLine();
			Console.WriteLine("ForEach Method: update Customers1 List Customer Name into Thiru Arasu");
			customers1.ForEach(cus=> {
				cus.CustomerName = "Thiru Arasu";
			});
			foreach (var c1 in customers1)
			{
				Console.WriteLine("CustomerId: {0} , CustomerName: {1} , Age: {2}", c1.CustomerId, c1.CustomerName, c1.Age);
			}
			
			Console.ReadLine();
		}
	}
	public class Customers
	{
		public int CustomerId { get; set; }
		public string CustomerName { get; set; }
		public int Age { get; set; }
	}

}
