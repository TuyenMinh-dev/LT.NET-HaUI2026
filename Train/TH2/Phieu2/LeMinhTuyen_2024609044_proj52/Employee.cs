using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeMinhTuyen_2024609044_proj52
{
    class Employee
    {
        public string id { set; get; }
        public string name { set; get; }
        public int age { set; get; }
        public int workingdays { set; get; }

        public double salary;
        public const double PRICE = 50;
        public List<Employee> ListE = new List<Employee>();

        public double getSalary()
        {
            return workingdays * PRICE;
        }
        public void Input()
        {
            Employee e = new Employee();
            Console.Write("ID: ");
            e.id = Console.ReadLine();
            Console.Write("Name: ");
            e.name = Console.ReadLine();
            Console.Write("Age: ");
            e.age = EnterAnInteger();
            Console.WriteLine("WorkingDays: ");
            e.workingdays = EnterAnInteger();

            ListE.Add(e);
            Console.WriteLine("Them thanh cong nhan vien co ma "+e.id);
            
        }
        public void Ouput()
        {
            if (ListE.Count == 0)
            {
                Console.WriteLine("Chua co nhan vien nao!");
                return;
            }
            Console.WriteLine("---DSNV---");
            Title();
            foreach(Employee e in ListE)
            {
                e.Information();
            }
        }
        public void Title()
        {
            Console.WriteLine("| {0,-10} | {1,-15} | {2,-10} | {3,-15} | {4,-15} |","ID","Name","Age","Days","Salary");
            Console.WriteLine(new string('-',60));
        }
        public void Information()
        {
            Console.WriteLine("| {0,-10} | {1,-15} | {2,-10} | {3,-15} | {4,-15} |", id, name, age, workingdays, getSalary());
        }
   
        public int EnterAnInteger()
        {
            int res;
            while(!int.TryParse(Console.ReadLine(),out res)|| res<0)
            {
                Console.Write("Du lieu khong hop le. Vui long nhap lai 1 so nguyen duong: ");
            }
            return res;
        }

        public double EnterAnDouble()
        {
            double res;
            while (!double.TryParse(Console.ReadLine(), out res) || res < 0)
            {
                Console.Write("Du lieu khong hop le. Vui long nhap lai 1 so thuc: ");
            }
            return res;
        }

        

    }
}
