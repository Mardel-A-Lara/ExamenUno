using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ExamenUno.Models
{
    public class Class1
    {
        [PrimaryKey,AutoIncrement ]

        public int idlatitud { get; set; }
        [MaxLength(100)]

        public string latitud { get; set; }
        [MaxLength(100)]
        public string  idlongitud { get; set; }
        [MaxLength (100)]

        public string du { get; set; }
        [MaxLength(100)]

        public string descripcioncorta { get; set; }
        [MaxLength(40)]

        public string descripciona { get;set; }



    }
}
