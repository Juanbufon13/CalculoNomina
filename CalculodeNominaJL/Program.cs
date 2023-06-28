using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculodeNominaJL
{
    class Program
    {
        static void Main(string[] args)
        {
            string repetirPuesto = "";
            string actualizarPuesto = "";
            int busqueda = 0;

            List<Nomina> calculoDeNominas = new List<Nomina>();
            Nomina calculoDeNomina = new Nomina();
            do
            {
                calculoDeNominas.Add(IngresarPuestoTeclado());
               

                actualizarPuesto= LeerSiONo("Deseas actualizar algun puesto:");
                if (actualizarPuesto=="si"||actualizarPuesto=="SI"||actualizarPuesto=="s")
                {
                    //ImprimirFront("Ingresa el Id que quieres buscar:");
                    busqueda = LeerNumeros("Ingresa el Id que quieres buscar:");
                    calculoDeNomina = calculoDeNomina.BuscaPorId(calculoDeNominas, busqueda);
                }
                Console.Clear();
                repetirPuesto = LeerDatos("Deseas ingresar otro puesto:").ToUpper();
            } while (repetirPuesto == "SI" || repetirPuesto == "S");
            ImprimirCalculoNomina(calculoDeNominas);

            Console.ReadKey();


        }

        public static Nomina IngresarPuestoTeclado()
        {
            Nomina calculoDeNomina = new Nomina();
            List<Puesto> Lista = new List<Puesto>();
            Console.WriteLine("CALCULO DE NOMINA");
            Console.WriteLine("Bienvenido!!!");
            calculoDeNomina.Id = Convert.ToInt32(LeerNumeros("Ingresa un ID:"));
            calculoDeNomina.Nombre = LeerDatos("Ingresa el nombre:");
            calculoDeNomina.Apeido = LeerDatos("Ingresa el apeido:");
            calculoDeNomina.Domicilio = LeerDatos("Ingresa el domicilio:");
            calculoDeNomina.Edad = Convert.ToInt32(LeerNumeros("Ingresa tu edad:"));
            calculoDeNomina.DiasTrabajados = Convert.ToInt32(LeerNumeros("Ingresa los dias trabajados:"));
            Console.Clear();

            Lista = ObtenerListaPuestos();
            ImprimirPuesto(Lista);
            var idPuesto = Convert.ToInt32(LeerDatos("Seleciona un puesto"));
            var selecionaPuesto = ObtenerPuestoPorId(Lista, idPuesto);
            var guardarSalarioTrabajado = PagoPorDiasTrabajados(selecionaPuesto, calculoDeNomina.DiasTrabajados);
            calculoDeNomina.SueldoPorDiasTrabajados = guardarSalarioTrabajado;
            calculoDeNomina.PuestoDelEmpleado = selecionaPuesto;
            calculoDeNomina.HorasExtras = LeerNumeros("Horas extras:");
            Console.WriteLine(calculoDeNomina.PuestoDelEmpleado.nombredelPuesto + "\n" + "Pago por los dias trabajados =" + "   "
                + guardarSalarioTrabajado);

            var cantidadTotalPago = PagoTotal(calculoDeNomina.SueldoPorDiasTrabajados, calculoDeNomina.HorasExtras,
                selecionaPuesto.PagoPorHoraExtra);
            ImprimirFront("Pago total con horas extras= $" + cantidadTotalPago);
            calculoDeNomina.PagoPorHoraExtra = cantidadTotalPago;

            return calculoDeNomina;
        }


      
        public static string LeerDatos(string lista)
        {
            string datoLeidoDesdeTeclado = "";
            Console.WriteLine(lista);
            datoLeidoDesdeTeclado = Console.ReadLine();
            return datoLeidoDesdeTeclado;
        }
        public static List<Puesto> ObtenerListaPuestos()
        {
            List<Puesto> ListaPuestos = new List<Puesto>();
            ListaPuestos.Add(new Puesto() { Id = 1, nombredelPuesto = "Desarrollador", SalarioPorDia = 800, PagoPorHoraExtra = 50 });
            ListaPuestos.Add(new Puesto() { Id = 2, nombredelPuesto = "Lider them", SalarioPorDia = 900, PagoPorHoraExtra = 75 });
            ListaPuestos.Add(new Puesto() { Id = 3, nombredelPuesto = "Gerente", SalarioPorDia = 1700, PagoPorHoraExtra = 100 });
            ListaPuestos.Add(new Puesto() { Id = 4, nombredelPuesto = "Director", SalarioPorDia = 2500, PagoPorHoraExtra = 130 });
            ListaPuestos.Add(new Puesto() { Id = 5, nombredelPuesto = "Ingenieria", SalarioPorDia = 1300, PagoPorHoraExtra = 75 });
            ListaPuestos.Add(new Puesto() { Id = 6, nombredelPuesto = "Junior", SalarioPorDia = 500, PagoPorHoraExtra = 50 });
            ListaPuestos.Add(new Puesto() { Id = 7, nombredelPuesto = "Becario", SalarioPorDia = 500, PagoPorHoraExtra = 10 });

            return ListaPuestos;
        }
        public static void ImprimirCalculoNomina(List<Nomina> calculodeNominas)
        {
            foreach (var item in calculodeNominas)
            {
                string datos1 = "ID:"+" "+item.Id + "NOMBRE:" +" "+ item.Nombre + " " + item.Apeido+"  "+ "EDAD:  " + item.Edad + "  " + item.Domicilio +
                    "  " + "Dias trabajados" + "  " + item.DiasTrabajados + "   " + item.PuestoDelEmpleado.nombredelPuesto + "  "
                    + "Pago por los dias trabajados=$" + item.SueldoPorDiasTrabajados +" "+ "Pago total con horas extras= $" + item.PagoPorHoraExtra;
                Console.WriteLine(datos1);
            }
        }
        public static void ImprimirPuesto(List<Puesto> puestos)
        {
            foreach (var item   in puestos)
            {
                var datos = item.Id + "  " + item.nombredelPuesto + "  " + "$" + item.SalarioPorDia;
                Console.WriteLine(datos);

            }
        }
        public static Puesto ObtenerPuestoPorId(List<Puesto> listaPuestos, int posicionLista)
        {
            Puesto puesto = new Puesto();
            puesto = listaPuestos[posicionLista - 1];
            return puesto;

        }

        public static int PagoPorDiasTrabajados(Puesto puesto, int diasTrabajados)
        {
            int pagoPorDia = puesto.SalarioPorDia * diasTrabajados;
            return pagoPorDia;
        }

        public static int LeerNumeros(string mensaje)
        {
            int valor;
            string respuestaNumero;
            bool x;
            bool esNumero;
            do
            {
                Console.WriteLine(mensaje);
                respuestaNumero = Console.ReadLine();
                esNumero = int.TryParse(respuestaNumero, out valor);
                x = !esNumero;
            }
            while (x);
            //valor = Convert.ToInt32(x);
            return valor;
        }
        public static int PagoTotal(int SueldoPorDiasTrabajados, int horasExtra, int pagoHoraExtra)
        {
            int extras = 0;
            int totalExtras = 0;
            extras = horasExtra * pagoHoraExtra;
            totalExtras = extras + SueldoPorDiasTrabajados;
            return totalExtras;
        }
        public static void ImprimirFront(string texto)
        {

            Console.WriteLine(texto);

        }
        public static string LeerSiONo(string mensaje)
        {
            string datoLeido = "";
            do
            {
                Console.Write(mensaje);
                datoLeido = Console.ReadLine();
                if (datoLeido.ToLower() != "si" && datoLeido.ToLower() != "no")
                {
                    Console.Clear();
                    Console.WriteLine("La opcion que ingresaste no corresponde a si o no, intenta de nuevo:");
                }
            } while (datoLeido.ToLower() != "si" && datoLeido.ToLower() != "no");

            return datoLeido.ToLower();


            //public static List<Nomina> ObtenerIdNomina(List<Nomina> calculodeNominas, int Id)
            //{
               // int ingresaId = 0;
                //int dt1 = 0;
                //foreach (var item in calculodeNominas)
                //{
                    //Console.WriteLine("Ingresa Id");
                    //ingresaId =Convert.ToInt32(Console.ReadLine());

                    //if (ingresaId>=Id)
                    //{
                        //calculodeNominas.Remove(Id);
                    //}
                //}

                //return dt1 ;
        }
    }
}
