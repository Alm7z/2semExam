using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ObjLinq
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("*****T7*****");
			Task7();
			Console.WriteLine("*****T17*****");
			Task17();
			Console.WriteLine("*****T27*****");
			Task27();
			Console.WriteLine("*****T37*****");
			Task37();
			Console.WriteLine("*****T47*****");
			Task47();
			Console.WriteLine("*****T57*****");
			Task57();
			Console.WriteLine("*****T67*****");
			Task67();
			Console.WriteLine("*****T77*****");
			Task77();
			Console.WriteLine("*****T87*****");
			Task87();
			Console.WriteLine("*****T97*****");
			Task97();
		}

		static void Task7()
		{
			int k = 1;
			var r = File.ReadAllLines("7.txt").Select(x =>
			{
				Console.WriteLine("input: " + x);
				string[] s = x.Split(' ');
				return new
				{
					hours = int.Parse(s[0]),
					year = s[1],
					month = int.Parse(s[2]),
					code = int.Parse(s[3])
				};
			})
			.Where(x => x.code == k)
			.GroupBy(x => x.year).Select(y => y.OrderBy(z => z.hours).First()).ToList();
			if (r.Count() > 0)
			{
				r.ForEach(x => Console.WriteLine(x.year + " " + x.month + " " + x.hours));
			}
			else
			{
				Console.WriteLine("Нет данных");
			}

		}

		static void Task17()
		{
			File.ReadAllLines("17.txt").Select(x =>
			{
				Console.WriteLine("input: " + x);
				string[] s = x.Split(' ');
				return new
				{
					school = s[0],
					year = s[1],
					name = s[2]
				};
			})
			.GroupBy(x => x.year)
			.Select(y => y.GroupBy(z => z.school))
			.OrderBy(x => x.Count())
			.ToList()
			.ForEach(x => Console.WriteLine(x.Count() + " " + x.First().First().year));
		}

		static void Task27()
		{
			File.ReadAllLines("27.txt").Select(x =>
			{
				Console.WriteLine("input: " + x);
				string[] s = x.Split(' ');
				return new
				{
					name = s[0],
					num = int.Parse(s[1]),
					money = double.Parse(s[2])
				};
			})
			.GroupBy(x => (x.num - 1) / 16)
			.OrderBy(y => y.Count())
			.ToList()
			.ForEach(y => Console.WriteLine(y.Count() + " " + ((y.First().num - 1) / 16 + 1) + " " + y.Sum(x => x.money)));

		}

		static void Task37()
		{
			File.ReadAllLines("37.txt").Select(x =>
			{
				Console.WriteLine("input: " + x);
				string[] s = x.Split(' ');
				return new
				{
					company = s[0],
					marka = int.Parse(s[1]),
					price = int.Parse(s[2]),
					street = s[3]
				};
			})
			.GroupBy(x => x.marka)
			.OrderBy(y => y.First().marka)
			.ToList()
			.ForEach(y => Console.WriteLine(y.First().marka + " " + y.Min(x => x.price) + " " + y.Max(x => x.price)));
		}

		static void Task47()
		{
			bool ok = false;
			File.ReadAllLines("47.txt").Select(x =>
			 {
				 Console.WriteLine("input: " + x);
				 string[] s = x.Split(' ');
				 return new
				 {
					 company = s[0],
					 marka = int.Parse(s[1]),
					 price = int.Parse(s[2]),
					 street = s[3]
				 };
			 })
			.OrderBy(x => x.street)
			.OrderBy(x => x.company)
			.GroupBy(x => x.company)
			.ToList().ForEach(
				y => y.GroupBy(x => x.street).
				ToList().ForEach(y1 =>
				{
					if (y1.Count() >= 2)
					{
						Console.WriteLine(y1.First().company + " " + y1.First().street + " " + y1.Count());
						ok = true;
					}
				}));

			if (!ok) { Console.WriteLine("Нет"); }

		}

		static void Task57()
		{
			bool ok = false;
			File.ReadAllLines("57.txt").Select(x =>
			{
				Console.WriteLine("input: " + x);
				string[] s = x.Split(' ');
				return new
				{
					school = s[0],
					name = s[1] + " " + s[2],
					score1 = int.Parse(s[3]),
					score2 = int.Parse(s[4]),
					score3 = int.Parse(s[5])
				};
			})
			.GroupBy(x => x.school)
			.ToList().ForEach(
				y => y
				.Where(x => x.score1 < 50 && x.score2 < 50 && x.score3 < 50)
				.Where((x, i) => i <= 2)
				.ToList().ForEach(x =>
				{
					Console.WriteLine(x.school + " " + x.name + " ");
					ok = true;
				}));

			if (!ok) { Console.WriteLine("Требуемые  учащиеся  не  найдены"); }

		}

		static void Task67()
		{
			bool ok = false;
			File.ReadAllLines("67.txt").Select(x =>
			{
				Console.WriteLine("input: " + x);
				string[] s = x.Split(' ');
				return new
				{
					clas = s[0],
					subject = s[1],
					name = s[2] + " " + s[3],
					score = int.Parse(s[4])
				};
			})
			.Where(x => x.score == 2)
			.OrderBy(x => x.name)
			.OrderBy(x => x.clas)
			.GroupBy(x => x.name)
			.ToList().ForEach(
				y =>
				{
					Console.WriteLine(y.First().clas + " " + y.First().name + " " + y.Count());
					ok = true;
				});

			if (!ok) { Console.WriteLine("Требуемые  учащиеся  не  найдены"); }

		}

		static void Task77()
		{
			var b = File.ReadAllLines("77B.txt").Select(x =>
			  {
				  Console.WriteLine("input B: " + x);
				  string[] s = x.Split(' ');
				  return new
				  {
					  kat = s[0],
					  art = s[1],
					  country = s[2]
				  };
			  }).ToList();

			var d = File.ReadAllLines("77D.txt").Select(x =>
			{
				Console.WriteLine("input D: " + x);
				string[] s = x.Split(' ');
				return new
				{
					art = s[0],
					cost = s[1],
					name = s[2]
				};
			}).ToList();

			b.GroupBy(x => x.kat).ToList().ForEach(y =>
			{
				int shops = 0;
				foreach (var item in y)
				{
					shops += d.Count(x => x.art == item.art);
				}
				if (shops > 0)
				{
					Console.WriteLine(shops + " " + y.First().kat + " " + y.GroupBy(x => x.country).Count());
				}
			});

		}

		static void Task87()
		{
			var a = File.ReadAllLines("87A.txt").Select(x =>
			{
				Console.WriteLine("input A: " + x);
				string[] s = x.Split(' ');
				return new
				{
					year = s[0],
					street = s[1],
					code = s[2]
				};
			}).OrderBy(x => x.street).ToList();

			var d = File.ReadAllLines("87D.txt").Select(x =>
			{
				Console.WriteLine("input D: " + x);
				string[] s = x.Split(' ');
				return new
				{
					art = s[0],
					name = s[1],
					cost = int.Parse(s[2])
				};
			}).ToList();

			var e = File.ReadAllLines("87E.txt").Select(x =>
			{
				Console.WriteLine("input E: " + x);
				string[] s = x.Split(' ');
				return new
				{
					name = s[0],
					code = s[1],
					art = s[2]
				};
			}).OrderBy(x => x.name).ToList();

			a.GroupBy(a1 => a1.street).ToList().ForEach(a2 =>
			  {
				  e.GroupBy(e1 => e1.name).ToList().ForEach(e2 =>
					{
						int k = 0;
						e2.ToList().ForEach(e1 =>
						{
							if (a2.Count(a1 => a1.code == e1.code) > 0)
							{
								k += d.Find(d1 => d1.art == e1.art && d1.name == e1.name).cost;
							}
						});
						Console.WriteLine(a2.Key + " " + e2.Key + " " + k);
					});
			  });
		}

		static void Task97()
		{
			//File.ReadAllLines("97B.txt").ToList().ForEach(x => Console.WriteLine("input B: " + x));
			//File.ReadAllLines("97C.txt").ToList().ForEach(x => Console.WriteLine("input C: " + x));
			//File.ReadAllLines("97D.txt").ToList().ForEach(x => Console.WriteLine("input D: " + x));
			//File.ReadAllLines("97E.txt").ToList().ForEach(x => Console.WriteLine("input E: " + x));

			File.ReadAllLines("97B.txt").Select(x => { string[] s = x.Split(' '); return new { kat = s[0], art = s[1], country = s[2] }; }).OrderBy(b1 => b1.country).ToList().GroupBy(b1 => b1.country).ToList().ForEach(b2 => { File.ReadAllLines("97E.txt").Select(x => { string[] s = x.Split(' '); return new { name = s[0], code = s[1], art = s[2] }; }).OrderBy(e1 => e1.code).ToList().GroupBy(e1 => e1.code).ToList().ForEach(e2 => { bool ok = false; int sum = 0; e2.ToList().ForEach(e1 => { if (b2.Count(b1 => b1.art == e1.art) > 0) { ok = true; sum += File.ReadAllLines("97D.txt").Select(x => { string[] s = x.Split(' '); return new { cost = int.Parse(s[0]), name = s[1], art = s[2] }; }).ToList().Find(d1 => d1.art == e1.art && d1.name == e1.name).cost; if (File.ReadAllLines("97C.txt").Select(x => { string[] s = x.Split(' '); return new { discount = int.Parse(s[0]), name = s[1], code = s[2] }; }).ToList().Count(c1 => c1.code == e1.code && c1.name == e1.name) > 0) { sum -= File.ReadAllLines("97D.txt").Select(x => { string[] s = x.Split(' '); return new { cost = int.Parse(s[0]), name = s[1], art = s[2] }; }).ToList().Find(d1 => d1.art == e1.art && d1.name == e1.name).cost * File.ReadAllLines("97C.txt").Select(x => { string[] s = x.Split(' '); return new { discount = int.Parse(s[0]), name = s[1], code = s[2] }; }).ToList().Find(c1 => c1.code == e1.code && c1.name == e1.name).discount / 100; } } }); if (ok) { Console.WriteLine(b2.Key + " " + e2.Key + " " + sum); } }); });

		}
	}
}
