using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace LinqConsoleApp
{
    public class LinqSamples
    {
        public static IEnumerable<Emp> Emps { get; set; }
        public static IEnumerable<Dept> Depts { get; set; }

        public LinqSamples()
        {
            LoadData();
        }

        public void LoadData()
        {
            var empsCol = new List<Emp>();
            var deptsCol = new List<Dept>();

            #region Load depts
            var d1 = new Dept
            {
                Deptno = 1,
                Dname = "Research",
                Loc = "Warsaw"
            };

            var d2 = new Dept
            {
                Deptno = 2,
                Dname = "Human Resources",
                Loc = "New York"
            };

            var d3 = new Dept
            {
                Deptno = 3,
                Dname = "IT",
                Loc = "Los Angeles"
            };

            deptsCol.Add(d1);
            deptsCol.Add(d2);
            deptsCol.Add(d3);
            Depts = deptsCol;
            #endregion

            #region Load emps
            var e1 = new Emp
            {
                Deptno = 1,
                Empno = 1,
                Ename = "Jan Kowalski",
                HireDate = DateTime.Now.AddMonths(-5),
                Job = "Backend programmer",
                Mgr = null,
                Salary = 2000
            };

            var e2 = new Emp
            {
                Deptno = 1,
                Empno = 20,
                Ename = "Anna Malewska",
                HireDate = DateTime.Now.AddMonths(-7),
                Job = "Frontend programmer",
                Mgr = e1,
                Salary = 4000
            };

            var e3 = new Emp
            {
                Deptno = 1,
                Empno = 2,
                Ename = "Marcin Korewski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Frontend programmer",
                Mgr = null,
                Salary = 5000
            };

            var e4 = new Emp
            {
                Deptno = 2,
                Empno = 3,
                Ename = "Paweł Latowski",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Frontend programmer",
                Mgr = e2,
                Salary = 5500
            };

            var e5 = new Emp
            {
                Deptno = 2,
                Empno = 4,
                Ename = "Michał Kowalski",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Backend programmer",
                Mgr = e2,
                Salary = 5500
            };

            var e6 = new Emp
            {
                Deptno = 2,
                Empno = 5,
                Ename = "Katarzyna Malewska",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Manager",
                Mgr = null,
                Salary = 8000
            };

            var e7 = new Emp
            {
                Deptno = null,
                Empno = 6,
                Ename = "Andrzej Kwiatkowski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "System administrator",
                Mgr = null,
                Salary = 7500
            };

            var e8 = new Emp
            {
                Deptno = 2,
                Empno = 7,
                Ename = "Marcin Polewski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Mobile developer",
                Mgr = null,
                Salary = 4000
            };

            var e9 = new Emp
            {
                Deptno = 2,
                Empno = 8,
                Ename = "Władysław Torzewski",
                HireDate = DateTime.Now.AddMonths(-9),
                Job = "CTO",
                Mgr = null,
                Salary = 12000
            };

            var e10 = new Emp
            {
                Deptno = 2,
                Empno = 9,
                Ename = "Andrzej Dalewski",
                HireDate = DateTime.Now.AddMonths(-4),
                Job = "Database administrator",
                Mgr = null,
                Salary = 9000
            };

            empsCol.Add(e1);
            empsCol.Add(e2);
            empsCol.Add(e3);
            empsCol.Add(e4);
            empsCol.Add(e5);
            empsCol.Add(e6);
            empsCol.Add(e7);
            empsCol.Add(e8);
            empsCol.Add(e9);
            empsCol.Add(e10);
            Emps = empsCol;

            #endregion

        }


        /*
            Celem ćwiczenia jest uzupełnienie poniższych metod.
         *  Każda metoda powinna zawierać kod C#, który z pomocą LINQ'a będzie realizować
         *  zapytania opisane za pomocą SQL'a.
         *  
         *  
         *  to co dalej ninewazne =>
         *  Rezultat zapytania powinien zostać wyświetlony za pomocą kontrolki DataGrid.
         *  W tym celu końcowy wynik należy rzutować do Listy (metoda ToList()).
         *  Jeśli dane zapytanie zwraca pojedynczy wynik możemy je wyświetlić w kontrolce
         *  TextBox WynikTextBox.
        */

        /// <summary>
        /// SELECT * FROM Emps WHERE Job = "Backend programmer";
        /// </summary>
        public void Przyklad1()
        {
            //var res = new List<Emp>();
            //foreach(var emp in Emps)
            //{
            //    if (emp.Job == "Backend programmer") res.Add(emp);
            //}

            //1. Query syntax (SQL)
            var res = from emp in Emps
                      where emp.Job == "Backend programmer"
                      select new
                      {
                          Nazwisko = emp.Ename,
                          Zawod = emp.Job
                      };
            foreach (var aaa in res)
            {
                Console.WriteLine(aaa);
            }

            //2. Lambda and Extension methods

            var res2 = Emps.Where(x => x.Job == "Backend programmer").Select(x => new
            {
                Nazwisko = x.Ename,
                Zawod = x.Job
            });

            foreach (var emp in res2)
            {
                Console.WriteLine(emp);
            }
        }

        /// <summary>
        /// SELECT * FROM Emps Job = "Frontend programmer" AND Salary>1000 ORDER BY Ename DESC;
        /// </summary>
        public void Przyklad2()
        {
            var res3 = Emps.Where(x => x.Job == "Frontend programmer").Where(x => x.Salary > 1000).OrderByDescending(x => x.Ename);

            foreach (var emp in res3)
            {
                Console.WriteLine(emp);
            }

            var res31  = from emp in Emps
                         orderby emp.Ename descending
                         where emp.Job == "Frontend programmer" && emp.Salary > 1000
                         select emp;
            foreach (var e in res31)
            {
                Console.WriteLine(e);
            }

        }

        /// <summary>
        /// SELECT MAX(Salary) FROM Emps;
        /// </summary>
        public void Przyklad3()
        {
            var maxSal = (from emp in Emps
                          select emp.Salary).Max();
            Console.WriteLine(maxSal);
            var maxSal2 = Emps.Max(x => x.Salary);
            Console.WriteLine(maxSal2);
        }

        /// <summary>
        /// SELECT * FROM Emps WHERE Salary=(SELECT MAX(Salary) FROM Emps);
        /// </summary>
        public void Przyklad4()
        {
            var res4 = Emps.Where(x => x.Salary == Emps.Select(x => x.Salary).Max());

            foreach (var emp in res4)
            {
                Console.WriteLine(emp);
            }
            var res41 = from emp in Emps where emp.Salary == (from e in Emps select e.Salary).Max()
                      select emp;
            foreach (var emp in res41)
            {
                Console.WriteLine(emp);
            }
        }

        /// <summary>
        /// SELECT ename AS Nazwisko, job AS Praca FROM Emps;
        /// </summary>
        public void Przyklad5()
        {
            var res5 = Emps.Select(x => new
            {
                Nazwisko = x.Ename,
                Praca = x.Job
            });

            foreach (var emp in res5)
            {
                Console.WriteLine(emp);
            }

            var res51 = from emp in Emps
                      select new
                      {
                          Nazwisko = emp.Ename,
                          Praca = emp.Job
                      };
            foreach (var emp in res51)
            {
                Console.WriteLine(emp);
            }
        }

        /// <summary>
        /// SELECT Emps.Ename, Emps.Job, Depts.Dname FROM Emps
        /// INNER JOIN Depts ON Emps.Deptno=Depts.Deptno
        /// Rezultat: Złączenie kolekcji Emps i Depts.
        /// </summary>
        public void Przyklad6()
        {
            var res6 = Depts.Join(Emps,
       dept => dept.Deptno,
       emp => emp.Deptno,
       (dept, emp) => new { dept, emp });

            foreach (var emp in res6)
            {
                Console.WriteLine(emp);
            }
            var res61 = from emp in Emps join dept in Depts on emp.Deptno equals dept.Deptno
                      select new
                      {
                          dept,
                          emp
                      };
            foreach (var emp in res61)
            {
                Console.WriteLine(emp);
            }
        }

        /// <summary>
        /// SELECT Job AS Praca, COUNT(1) LiczbaPracownikow FROM Emps GROUP BY Job;
        /// </summary>
        public void Przyklad7()
        {
            var res = from emp in Emps
                      group emp by emp.Job into Zawod
                      select new
                      {
                          Praca = Zawod.Key,
                          LiczbaPracownaikow = Zawod.Count()
                      };
            foreach (var em in res)
            {
                Console.WriteLine(em);
            }
            var res2 = Emps.GroupBy(emp => emp.Job).Select(zaw => new
            {
                Praca = zaw.Key,
                LiczbaPracownikow = zaw.Count()
            });
            foreach (var em in res2)
            {
                Console.WriteLine(em);
            }
        }

        /// <summary>
        /// Zwróć wartość "true" jeśli choć jeden
        /// z elementów kolekcji pracuje jako "Backend programmer".
        /// </summary>
        public void Przyklad8()
        {
            var res = from emp in Emps
                      where emp.Job == "Backend programmer"
                      select new
                      {
                          Nazwisko = emp.Ename
                      };
            Console.WriteLine(res.Any());
            var res2 = Emps.Where(emp => emp.Job == "Backend programmer").Any();
            Console.WriteLine(res2);
        }

        /// <summary>
        /// SELECT TOP 1 * FROM Emp WHERE Job="Frontend programmer"
        /// ORDER BY HireDate DESC;
        /// </summary>
        public void Przyklad9()
        {
            var res = Emps.Where(x => x.Job == "Frontend programmer").OrderByDescending(x => x.HireDate).FirstOrDefault();

                Console.WriteLine(res);
            var res2 = (from emp in Emps
                       orderby emp.HireDate descending
                       where emp.Job == "Frontend programmer"
                       select emp).FirstOrDefault();
            Console.WriteLine(res2);
        }

        /// <summary>
        /// SELECT Ename, Job, Hiredate FROM Emps
        /// UNION
        /// SELECT "Brak wartości", null, null;
        /// </summary>
        public void Przyklad10Button_Click()
        {
            var res11 = from emp in Emps
                       select new
                       {
                           Ename = emp.Ename,
                           Job = emp.Job,
                           HireDate = emp.HireDate
                       };
            var res12 = from emp in Emps
                       select new
                       {
                           Ename = "Brak wartosci",
                           Job = (string)null,
                           HireDate = (DateTime?)null
                       };
            foreach (var e in res11.Union(res12))
            {
                Console.WriteLine(e);
            }
            var res2 = Emps.Select(emp => new
            {
                emp.Ename,
                emp.Job,
                emp.HireDate
            }).Union(new[] { new { Ename = "Brak wartości", Job = (string)null, HireDate = (DateTime?)null } });
            foreach (var e in res2)
            {
                Console.WriteLine(e);
            }
        }

        //Znajdź pracownika z najwyższą pensją wykorzystując metodę Aggregate()
        public void Przyklad11()
        {
            var res = (from emp in Emps select emp
                       ).Aggregate((emp, next) => emp.Salary > next.Salary ? emp : next);
            Console.WriteLine(res);
            var res2 = Emps.Aggregate((res, next) => next.Salary > res.Salary ? next : res);
            Console.WriteLine(res2);
        }

        //Z pomocą języka LINQ i metody SelectMany wykonaj złączenie
        //typu CROSS JOIN
        public void Przyklad12()
        {
            var res = Emps.SelectMany(x => Depts, (emp, dept) => new
            {
                emp,
                dept
            });
            foreach (var e in res)
            {
                Console.WriteLine(e);
            }
            var res2 = from emp in Emps
                      from dept in Depts
                      select new
                      {
                          emp,
                          dept
                      };
            foreach (var e in res2)
            {
                Console.WriteLine(e);
            }
        }
    }
}
