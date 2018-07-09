using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveCopy.LIB
{
    public enum TypeUSB { USB1=12, USB2=480,USB3=5000}
    public enum TypeDVD { SideA=5, SideB=9}
     public abstract class Storage
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public abstract double GetMemory();
        public abstract bool CopyData(double memoryData);
        public abstract double GetFreeMemory();
        public virtual void StorageInfo()
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("Наименование: \t{0}", Name);
            Console.WriteLine("Модель: \t{0}", Model);
            Console.WriteLine("-----------------------");
        }

        protected abstract TimeSpan GetTimeToCopy(double memoryData);
       

    }
    
}
