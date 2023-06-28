using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculodeNominaJL
{
    public class Nomina    
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apeido { get; set; }
        public string Domicilio { get; set; }
        public int Edad { get; set; }
        public int DiasTrabajados { get; set; }
        public Puesto PuestoDelEmpleado { get; set; }

        public int SueldoPorDiasTrabajados { get; set; }
        public int HorasExtras { get; set; }
        public int PagoPorHoraExtra { get; set; }

        public Nomina BuscaPorId(List<Nomina> calculoDeNominas,int busqueda)
        {
            Nomina calculo = new Nomina();
            foreach (var cadaIdLista in calculoDeNominas)
            {
                if (cadaIdLista.Id==busqueda)
                {
                    calculo = cadaIdLista;
                }

            }
            return calculo;
        }

    }
   
}
