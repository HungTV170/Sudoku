using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai3
{
    
    internal class InputData
    {
        public int dem {  get; set; }
        public List<int[]> banCo {  get; set; }

        void duLieuDauVao()
        {
            int[] d1 = { 2, 9, 0, 8, 0, 0, 0, 0, 0 };
            int[] d2 = { 0, 0, 0, 0, 0, 0, 6, 0, 0 };
            int[] d3 = { 7, 0, 0, 0, 9, 0, 0, 2, 0 };
            int[] d4 = { 0, 0, 0, 0, 2, 0, 0, 0, 0 };
            int[] d5 = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] d6 = { 0, 0, 3, 5, 0, 0, 2, 1, 0 };
            int[] d7 = { 0, 0, 5, 0, 0, 4, 0, 0, 0 };
            int[] d8 = { 3, 0, 0, 0, 0, 0, 9, 7, 0 };
            int[] d9 = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            this.banCo = new List<int[]>() { d1, d2, d3, d4, d5, d6, d7, d8, d9 };
            this.dem = 0;
            foreach (int[] b in this.banCo)
            { 
                for(int i = 0;i < 9; i++)
                {
                    if (b[i] != 0)
                    {
                        this.dem++;
                    }
                }
            }
            
        }
        public InputData() 
        {
            duLieuDauVao();
        }
    }
}
