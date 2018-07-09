using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReserveCopy.LIB
{

    public class Flash : Storage
    {
        public Flash() : this(0, TypeUSB.USB3) { }
        public Flash(double Memory, TypeUSB TypeUSB)
        {
            this.Memory = Memory;
            this.TypeUSB = TypeUSB;
            FreeMemory = Memory;
        }
        public TypeUSB TypeUSB { get; set; }
        public double Memory { get; set; }

        public override double GetMemory()
        {
            return Memory;
        }
        public override bool CopyData(double memoryData)
        {
            if (GetFreeMemory() <= memoryData)
            {
                FreeMemory-= memoryData;
                Console.Write("Идет копирование ");
                for (int i = 0; i < GetTimeToCopy(memoryData).Minutes; i++)
                {
                    Thread.Sleep(GetTimeToCopy(memoryData).Milliseconds);
                    Console.Write(".");
                }
                Console.WriteLine("Завершено!");
                return true;
            }
            else
            {
                Console.WriteLine("{0} не помещается на носитель с объемом {1}",
                    memoryData, GetFreeMemory());
                return false;
            }
        }
        protected override TimeSpan GetTimeToCopy(double memoryData)
        {
            return TimeSpan.FromSeconds(memoryData / (int)TypeUSB);
        }

        public double FreeMemory { get; private set; }
        public override double GetFreeMemory()
        {
            return FreeMemory;
        }
    }
}
