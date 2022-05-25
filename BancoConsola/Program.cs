using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoConsola
{
    public class Program
    {
        Cuentas usua = new Cuentas();  //Clase con los datos de cada usuario cedula, nombre, cuenta, contraseña de ingreso al banco, puntos y saldo

        //se crea una coleccion de datos para registrar los datos de algunos de los usuarios del banco
        public static List<Cuentas> lista = new List<Cuentas>()
        {
            new Cuentas { Cedula = "1106632348", Cuenta = "150", Nombre = "Juan David Mayorga", Passwd = "111111", Puntos = 10, Saldo = 10000000 },
            new Cuentas { Cedula = "1106632349", Cuenta = "151", Nombre = "Camilo Andres Mayorga", Passwd = "111112", Puntos = 10, Saldo = 4000000 },
            new Cuentas { Cedula = "1106632350", Cuenta = "152", Nombre = "Maria Jose Mayorga", Passwd = "111113", Puntos = 10, Saldo = 50000000 },
            new Cuentas { Cedula = "1106632351", Cuenta = "153", Nombre = "Alejandra Posse", Passwd = "111114", Puntos = 11, Saldo = 30000000 },
            new Cuentas { Cedula = "1106632352", Cuenta = "154", Nombre = "Jose Mayorga", Passwd = "111115", Puntos = 20, Saldo = 1000000 }
        };

        public static string? usuario = "";  //campo para tener en memoria el usuario que ingresó al banco
        public static string cuentau = "";  //campo para tener en memoria la cuenta del usuario que ingresó al banco
        public static decimal saldito = 0;  //campo para tener en memoria el saldo del usuario del banco
        public static int punticos = 0;  //campo para tener en memoria el saldo del usuario del banco
        static void Main(string[] args)
        {
            string nusuario = Ingresar(); //método para validar el ingreso al banco, si se encuentra el usuario lo deja ingresar al menú
            if (nusuario != "")
            {
                int opcion = 0;
                do
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine($"Usuario {nusuario}");
                        Console.WriteLine("BIENVENIDO AL BANCO VIVECOLOMBIA");
                        Console.WriteLine("\n------------MENU-------------------");
                        Console.WriteLine(" 1 - Consultar saldo");
                        Console.WriteLine(" 2 - Retirar");
                        Console.WriteLine(" 3 - Transferencias");
                        Console.WriteLine(" 4 - Consulta Puntos ViveColombia");
                        Console.WriteLine(" 5 - Canjea tus Puntos ViveColombia");
                        Console.WriteLine(" 6 - Salir");
                        Console.WriteLine("--------INGRESE LA OPCION------------");

                        opcion =  Convert.ToInt32(Console.ReadLine());
                        switch (opcion)
                        {
                            case 1: Saldousuario(); break;
                            case 2: Retirar(); break;
                            case 3: Trasferir(); break;
                            case 4: Puntos(); break;
                            case 5: CanjePuntos(); break;
                        }
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine("Digite valor valido" + error);
                    }
                } while (opcion != 6);
            }
        }


        public static void Saldousuario()
        {
            //Recorre la lista de datos para buscar el usuario por cedula y mostrar el saldo de cuenta
            foreach (Cuentas cuen in lista)
            {
                if ((usuario == cuen.Cedula))
                {
                    Console.WriteLine($"\nUsuario {cuen.Nombre}");
                    Console.WriteLine($"Cédula {cuen.Cedula}");
                    Console.WriteLine($"Cuenta {cuen.Cuenta}");
                    Console.WriteLine($"Saldo ${cuen.Saldo.ToString("0,0.00", CultureInfo.InvariantCulture)}");
                    Console.WriteLine("\nPresione enter para continuar");
                    saldito = cuen.Saldo;
                    Console.ReadKey();
                }
            }
        }
        public static void Retirar()
        {
            Console.WriteLine($"\nEl usuario tiene de saldo ${saldito.ToString("0,0.00", CultureInfo.InvariantCulture)}");
            Console.WriteLine("Digite el valor a retirar");
            decimal valorretiro = Convert.ToDecimal(Console.ReadLine());
            //se valida si el valor del retiro es hasta lo  permitido por el banco
            if (valorretiro <= 4000000)
            {
                //se valida que el valor a retirar sea menor o igual al saldo del usuario
                if (valorretiro <= saldito)
                {
                    Console.WriteLine($"\nel valor de ${valorretiro} es retirado");
                    foreach (Cuentas cuen in lista)
                    {
                        if ((usuario == cuen.Cedula))
                        {
                            cuen.Saldo = cuen.Saldo - valorretiro;
                            Console.WriteLine($"Usuario {cuen.Nombre}");
                            Console.WriteLine($"Cédula {cuen.Cedula}");
                            Console.WriteLine($"Cuenta {cuen.Cuenta}");
                            Console.WriteLine($"Tiene un nuevo saldo  de ${cuen.Saldo.ToString("0,0.00", CultureInfo.InvariantCulture)} ");
                            saldito = cuen.Saldo;
                        }
                    }
                    Console.WriteLine("Presione enter para continuar");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("No hay fondos suficientes para este retiro.  Presione enter para continuar");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Por política del banco no se puede retirar más de $4,000,000 de pesos. Presione enter para continuar");
                Console.ReadKey();
            }
        }

        public static void Trasferir()
        {
            Console.WriteLine($"\nEl usuario tiene de saldo ${saldito.ToString("0,0.00", CultureInfo.InvariantCulture)}");
            Console.WriteLine("Digite el número de cuenta a la cual se le hace la transferencia");
            string? cuentaatransferir = Console.ReadLine();
            decimal valortransferencia = 0;
            int pasar = 0;
            //se valida que no se le trasfiera a la misma cuenta del usuario logueado
            if (cuentaatransferir == cuentau)
            {
                Console.WriteLine("No se puede hacer trasferencia a la misma cuenta del usuario.  Presione enter para continuar");
                Console.ReadKey();
            }
            else
            {
                int encontrocuenta = 0;
                //buscar la cuenta a transferir
                foreach (Cuentas cuen in lista)
                {
                    //si encuentra la cuenta a transferir
                    if ((cuentaatransferir == cuen.Cuenta))
                    {
                        Console.WriteLine("Digite el valor a transferir");
                        valortransferencia = Convert.ToDecimal(Console.ReadLine());
                        //se valida que el valor a transferir no supere el saldo de la cuenta que transfiere
                        if (valortransferencia <= saldito)
                        {
                            cuen.Saldo = cuen.Saldo + valortransferencia;
                            Console.WriteLine($"\nusuario {cuen.Nombre}");
                            Console.WriteLine($"Cédula {cuen.Cedula}");
                            Console.WriteLine($"Cuenta {cuen.Cuenta}");
                            Console.WriteLine($"a quien se le transfirió ${valortransferencia.ToString("0,0.00", CultureInfo.InvariantCulture)}");
                            Console.WriteLine($"Tiene un nuevo saldo  de ${cuen.Saldo.ToString("0,0.00", CultureInfo.InvariantCulture)}");
                            Console.WriteLine("\nPresione enter para continuar ");
                            Console.ReadKey();
                            encontrocuenta = 1;
                        }
                        else
                        {
                            pasar = 1;
                            Console.WriteLine("El valor a transferir supera el saldo de la cuenta, acción denegada.  Presione enter para continuar");
                            Console.ReadKey();
                        }
                    }
                }
                if (encontrocuenta == 0)
                {
                    if (pasar == 0)
                    {
                        Console.WriteLine($"Cuenta {cuentaatransferir} no encontrada. Presione enter para continuar");
                        Console.ReadKey();
                    }
                }
                else
                {
                    //se actualiza la cuenta desde donde se hizo la transferencia
                    foreach (Cuentas cuen in lista)
                    {
                        if ((usuario == cuen.Cedula))
                        {
                            cuen.Saldo = cuen.Saldo - valortransferencia;
                            Console.WriteLine($"\nUsuario {cuen.Nombre}");
                            Console.WriteLine($"Cédula {cuen.Cedula}");
                            Console.WriteLine($"Cuenta {cuen.Cuenta}");
                            Console.WriteLine($"De donde se transfirió ${valortransferencia.ToString("0,0.00", CultureInfo.InvariantCulture)}");
                            Console.WriteLine($"Tiene un nuevo saldo  de ${cuen.Saldo.ToString("0,0.00", CultureInfo.InvariantCulture)} ");
                            saldito = cuen.Saldo;
                        }
                    }
                    Console.WriteLine("\nPresione enter para continuar");
                    Console.ReadKey();
                }

            }
        }

        public static void Puntos()
        {
            //Recorre la lista de datos para buscar consultar el número de puntos del usuario
            foreach (Cuentas cuen in lista)
            {
                if ((usuario == cuen.Cedula))
                {
                    Console.WriteLine($"\nUsuario {cuen.Nombre}");
                    Console.WriteLine($"Cédula {cuen.Cedula}");
                    Console.WriteLine($"Cuenta {cuen.Cuenta}");
                    Console.WriteLine($"Tiene {cuen.Puntos} puntos para redimir");
                    Console.WriteLine("\nPresione enter para continuar");
                    Console.ReadKey();
                }
            }
        }

        public static void CanjePuntos()
        {
            Console.WriteLine($"\nEl usuario tiene {punticos} puntos");
            Console.WriteLine("Cada punto tiene un valor de $7");
            Console.WriteLine("Digite el número de puntos a redimir");
            int punto = Convert.ToInt32(Console.ReadLine());
            if (punto <= punticos)
            {
                //Recorre la lista de datos para buscar los punto para redimir
                foreach (Cuentas cuen in lista)
                {
                    if ((usuario == cuen.Cedula))
                    {
                        Console.WriteLine($"\nUsuario {cuen.Nombre}");
                        Console.WriteLine($"Cédula {cuen.Cedula}");
                        Console.WriteLine($"Cuenta {cuen.Cuenta}");
                        cuen.Puntos = cuen.Puntos - punto;
                        Console.WriteLine($"Tiene ahora {cuen.Puntos} puntos para redimir");
                        cuen.Saldo = cuen.Saldo + punto * 7;
                        Console.WriteLine($"Tiene un nuevo saldo  de ${cuen.Saldo.ToString("0,0.00", CultureInfo.InvariantCulture)} ");
                        Console.WriteLine("\nPresione enter para continuar");
                        Console.ReadKey();
                    }
                }
            }
            else
            {
                Console.WriteLine("Tiene menos puntos de los solicitador a redimir ");
                Console.WriteLine("\nPresione enter para continuar");
                Console.ReadKey();
            }
        }



        public static string Ingresar()  //Metodo para consultar si el usuario existe, se consulta por cédula y password
        {
            string? passwd = "";
            int contador = 0;
            while (contador < 3)
            {
                Console.Clear();
                Console.WriteLine("===================");
                Console.WriteLine("Banco Vive Colombia");
                Console.WriteLine("===================");
                Console.WriteLine("Ingreso al Menú principal");
                Console.WriteLine("\n\nUsuario/Cédula");
                usuario = Console.ReadLine();
                Console.WriteLine("Clave");
                passwd = Console.ReadLine();
                foreach (Cuentas cuen in lista)
                {
                    if ((usuario == cuen.Cedula) && (passwd == cuen.Passwd))
                    {
                        contador = 10;
                        usuario = cuen.Cedula;
                        cuentau = cuen.Cuenta;
                        saldito = cuen.Saldo;
                        punticos = cuen.Puntos;
                        return cuen.Nombre;
                    }
                }
                contador++;
            }
            return "";
        }

    }
}
