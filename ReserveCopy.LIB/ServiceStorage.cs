using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveCopy.LIB
{
    public enum TypeDevice { Flash, DVD , HDD}
    public class ServiceStorage
    {
        static List<Flash> Flashes;
        static ServiceStorage()
        {
            Flashes = new List<Flash>();
            
        }
        public static void AddFlash(Flash flash)
        {
            Flashes.Add(flash);
        }

       static double totalMem = 0;

        public static double GetMemoryDevice()
        {
            totalMem=Flashes.Sum(s=>s.GetMemory());
            Console.WriteLine("Объем всех носителей={0}", totalMem);
            
            return totalMem;
        }
        public static double GetFreeMemoryDevice()
        {
            totalMem = Flashes.Sum(s => s.GetFreeMemory());
            Console.WriteLine("Свободный объем всех носителей={0}", totalMem);

            return totalMem;
        }
        public static void GetCountDevice(TypeDevice typeDevice, double sizeData)
        {
            double total = 0;
            switch (typeDevice)
            {
                case TypeDevice.Flash:
                    {
                        int i = 1;
                        foreach (Flash item in Flashes)
                        {
                            total = Math.Floor(sizeData / item.Memory);
                            if (total == 0)
                                total++;

                            Console.WriteLine("{0}. {1} ({2})- {3}гб \t-{4} штук", 
                                i++, item.Name, item.Model, item.Memory, total);
                        }
                        Console.Write("Выберите тип флешки: ");
                        i = Int32.Parse(Console.ReadLine());

                        GetTimeToCopyDevice(typeDevice, i, sizeData);
                    }
                    break;
                case TypeDevice.DVD:
                    break;
                case TypeDevice.HDD:
                    break;
                default:
                    break;
            }
        }
        
        public static void GetTimeToCopyDevice(TypeDevice typeDevice, 
            int choice,
            double sizeData)
        {
            switch (typeDevice)
            {
                case TypeDevice.Flash:
                    {
                        Flash chFlash = Flashes[choice-1];

                        int coutDevice = 3; 

                        Flash[] flashesD = new Flash[coutDevice];
                        for (int i = 0; i < coutDevice; i++)
                        {
                            flashesD[i] = chFlash;

                            if (i == coutDevice - 1)
                                flashesD[i].CopyData(sizeData);

                            flashesD[i].CopyData(flashesD[i].Memory);
                            sizeData -= flashesD[i].Memory;
                        }
                    }

                    break;
                case TypeDevice.DVD:
                    break;
                case TypeDevice.HDD:
                    break;
                default:
                    break;
            }
        }
    }
}
