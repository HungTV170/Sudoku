using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace bai3
{
    
    internal class Program
    {
        

        static void show(List<int[]> ls)
        {
            foreach (int[] l in ls)
            {
                for(int i=0; i<l.Length; i++)
                {
                    Console.Write($"{l[i]}-");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            
            
            ProcessData processData = new ProcessData();
            show(processData.storeData.banCo);
            processData.AllSolution(processData.firstX, processData.firstY);
            Console.WriteLine("Ket Qua");
            foreach (var item in processData.dsKetQua)
            {
                show(item);
                Console.WriteLine("-------------------------");
            }
            
            Console.ReadKey();
        }
    }
}
