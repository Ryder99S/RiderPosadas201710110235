using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ExamenTercerParcial.Modelos
{
    public class Pagos
    {
        [PrimaryKey, AutoIncrement]
        public int Id_pago { get; set; }

        [MaxLength(500)]
        public String Descripcion { get; set; }

        public String Fecha { get; set; }

        public double Monto { get; set; }

        public string Photo_recibo { get; set; }
    }
}
