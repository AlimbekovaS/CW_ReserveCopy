using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveCopy.LIB
{
    public class DVD
    {
        public DVD():this(TypeDVD.SideA,0,0) { }
        public DVD(TypeDVD TypeDVD, double ReadSp, double WriteSp )
        {
            this.TypeDVD = TypeDVD;
            this.ReadSp = ReadSp;
            this.WriteSp = WriteSp;
        }
        public double ReadSp { get; set; }
        public double WriteSp { get; set; }
        public TypeDVD TypeDVD { get; set; }
    }
}
