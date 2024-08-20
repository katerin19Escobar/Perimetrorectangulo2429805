using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perimetrorectangulo2429805
{
    [Table("rectangulo")]
    public class Rectangulo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public double Base { get; set; }
        public double Altura { get; set; }

        [Ignore]
        public double Perimetro => 2 * (Base + Altura);

        [Ignore]
        public double Superficie => Base * Altura;
    }
}
