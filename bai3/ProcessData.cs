using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai3
{
    struct ketQua
    {
        List<int[]> kq;
    }
    internal class ProcessData
    {
        public InputData storeData { get; set; } // dữ liệu đầu vào.
        public List<List<int[]>> dsKetQua { get; set; } // tất cả lời giải .

        public int firstX {  get; set; }
        public int firstY { get; set; }
        public ProcessData() 
        {
            this.storeData = new InputData();
            this.dsKetQua = new List<List<int[]>>();
            Boolean flag = false;
            for (int i=0; i < 9; i++)
            {
                for (int j=0; j < 9; j++)
                {
                    if (storeData.banCo[i][j] == 0)
                    {
                        firstX = i;
                        firstY = j;
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    break;
                }
            }
        }

        //List<int> giaTri = new List<int>(){ 1, 2, 3, 4, 5, 6, 7, 8, 9 };// tập giá trị mà một ô có thể nhận

        public Boolean isTMHang(int x, int y, int value)
        {
            int[] hangX = storeData.banCo[x];

            for (int i = 0; i < 9; i++)
            {
                if (hangX[i] == value)
                {
                    return false;
                }
            }

            return true;
        }

        public Boolean isTMCot(int x, int y, int value)
        {
            foreach (var item in storeData.banCo)
            {
                if (item[y] == value)
                {
                    return false;
                }

            }

            return true;
        }

        public Boolean isTMVung(int x, int y, int value)
        {
            int u = x / 3;
            int v = y / 3;

            for (int i = 0; i <= 2; i++)
            {

                for (int j = 0; j <= 2; j++)
                {
                    if (storeData.banCo[u*3 + i][v*3 + j] == value)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        
        public void OneSolution(int x,int y)
        {
            int i = 1;
            do
            {
                if(isTMCot(x, y, i) && isTMHang(x, y, i) && isTMVung(x, y, i))
                {
                    storeData.banCo[x][y] = i; // điền kết quả vào ô
                    storeData.dem += 1; // đã thêm 1 ô có giá trị
                    int u=0;
                    int v=0;
                    Boolean flag = false;
                    for(int m = x; m < 9; m++)
                    {
                        for(int n = 0; n < 9; n++)
                        {
                            if (storeData.banCo[m][n] == 0)
                            {
                                u = m;
                                v = n;
                                flag= true;
                                break;
                            }
                        }
                        if (flag)
                        {
                            break;
                        }
                    }
                    if (storeData.dem == 81)
                    {
                        List<int[]> result = new List<int[]>();
                        for(int xR  = 0; xR < 9; xR++)
                        {
                            int[] array = new int[9];
                            for (int yR = 0; yR < 9; yR++)
                            {
                                array[yR] = storeData.banCo[xR][yR];
                               
                            }
                            result.Add(array);
                        }
                        dsKetQua.Add(result); // them giải pháp tìm được vào danh sách kết quả.
                        
                        
                        
                    }
                    else
                    {
                        OneSolution(u,v);
                        storeData.banCo[x][y] = 0;
                        storeData.dem--;

                    }
                    
                }
                
                
                i++;
            } while (storeData.dem<81&&i<=9);

            
        }

    
        public void AllSolution(int x,int y)
        {
           

            for(int i = 1; i <= 9; i++)
            {
                if (isTMCot(x, y, i) && isTMHang(x, y, i) && isTMVung(x, y, i))
                {
                    storeData.banCo[x][y] = i; // điền kết quả vào ô
                    storeData.dem += 1; // đã thêm 1 ô có giá trị
                    int u = 0;
                    int v = 0;
                    Boolean flag = false;
                    for (int m = x; m < 9; m++)
                    {
                        for (int n = 0; n < 9; n++)
                        {
                            if (storeData.banCo[m][n] == 0)
                            {
                                u = m;
                                v = n;
                                flag = true;
                                break;
                            }
                        }
                        if (flag)
                        {
                            break;
                        }
                    }
                    if (storeData.dem == 81)
                    {
                        
                        List<int[]> result = new List<int[]>();
                        for (int xR = 0; xR < 9; xR++)
                        {
                            int[] array = new int[9];
                            for (int yR = 0; yR < 9; yR++)
                            {
                                array[yR] = storeData.banCo[xR][yR];

                            }
                            result.Add(array);
                        }
                        dsKetQua.Add(result); // them giải pháp tìm được vào danh sách kết quả.
                        

                    }
                    else
                    {
                        AllSolution(u, v);
                        storeData.banCo[x][y] = 0;
                        storeData.dem--;

                    }

                }

               
            }
            
        }
      
    void show()
        {
            foreach (int[] l in storeData.banCo)
            {
                for (int i = 0; i < l.Length; i++)
                {
                    Console.Write($"{l[i]}-");
                }
                Console.WriteLine();
            }
        }

    }
}
