using BancoConsola;


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

public static string usuario = "";  //campo para tener en memoria el usuario que ingresó al banco
public static string cuentau = "";  //campo para tener en memoria la cuenta del usuario que ingresó al banco
public static decimal saldito = 0;  //campo para tener en memoria el saldo del usuario del banco