// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;
using System.Text;

namespace fuerzaBruta;

public class TareaFuerzaBruta
{
    public static void Main()
    {
        //Zona de la contraseña de la que tenemos el hash, convirtiéndola y obteniendo su valor
        byte[] pass = GetHash("33eric33");
        string passString = devolverHash(pass);
        //Zona de acceso y lectura del fichero
        List<String> passList = new List<string>();
        string path = "2151220-passwords.txt";
        //zona de invocación de los métodos que realizan las tareas
        rellenarLista(passList, path);
        crackearPassword(passList, passString);
    }
        //Esto devuelve el hash en bytes
    public static byte[] GetHash(string password)
    {
        using (HashAlgorithm algoritmo = SHA256.Create())
            return algoritmo.ComputeHash(Encoding.UTF8.GetBytes(password));
    }
        //Esto convierte el hash en un String exadecimal que podemos leer
    public static string devolverHash(byte[] passHash)
    {
        string resultado = "";
        foreach (var b in passHash)
        {
            resultado += $"{b:X2}";
        }
        return resultado;
    }
    //Esto revisa cada string de la lista de contraseñas para buscar la coincidencia
    public static void crackearPassword(List<String> passList, string passString)
    {
        foreach (var passtemp in passList)
        {
            if ((devolverHash(GetHash(passtemp))).Equals(passString))
            {
                Console.WriteLine("Contraseña encontrada: " + passtemp);
            }
        }
    }
    //Esto rellena la lista de ocntraseñas con las del documento
    public static void rellenarLista(List<String> passList, string pathFichero)
    {
        using (StreamReader sr =
               File.OpenText(pathFichero))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                passList.Add(line);
            }
        }
    }
}