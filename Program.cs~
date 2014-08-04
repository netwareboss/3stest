using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 c1 = new Class1();
            Console.WriteLine("請輸入統編:");
            Console.ReadLine(string CompanyN);
            Console.WriteLine(c1.CheckCompanyN(CompanyN));
            Console.Read();
        }
    }
}
public class Class1
{
    public Boolean CheckCompanyN(string CompanyId)
    {
        int CompanyNo;
        if (CompanyId == null || CompanyId.Trim().Length != 8)
            return false;
        if (!int.TryParse(CompanyId, out CompanyNo))
            return false;
        int[] Logic = new int[] { 1, 2, 1, 2, 1, 2, 4, 1 };
        int addition, sum = 0, j = 0, x;
        for (x = 0; x < Logic.Length; x++)
        {
            int no = Convert.ToInt32(CompanyId.Substring(x, 1));
            j = no * Logic[x];
            addition = ((j / 10) + (j % 10));
            sum += addition;
        }
        if (sum % 10 == 0)
        {
            return true;
        }
        if (CompanyId.Substring(6, 1) == "7")
        {
            if (sum % 10 == 9)
            {
                return true;
            }
        }
        return false;
    }
}
