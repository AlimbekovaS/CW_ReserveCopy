using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReserveCopy.LIB;

namespace ReserveCopy
{
    public class Program
    {
        static void Main(string[] args)
        {
            Flash f1 = new Flash(2000, TypeUSB.USB1);
            f1.Name = "Kingston";
            f1.Model = "KB12";
            ServiceStorage.AddFlash(f1);

            ServiceStorage.AddFlash(new Flash(4000, TypeUSB.USB2)
            {Name="Transend", Model="B12" });

            ServiceStorage.AddFlash(new Flash(8000, TypeUSB.USB2)
            {Name="Sumsung", Model="D125" });

            Console.Write("Введите объем информации: ");
            double t = double.Parse(Console.ReadLine());
            ServiceStorage.GetCountDevice(TypeDevice.Flash, t);


            

        }
    }
}
