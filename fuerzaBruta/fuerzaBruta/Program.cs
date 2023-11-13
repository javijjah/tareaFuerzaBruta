// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;
using System.Text;

namespace fuerzaBruta;

public class TareaFuerzaBruta
{
    public static void Main()
    {
        //el da un archivo con contraseñas
        //el programa debe:
        //1.leer el archivo
        //2. ponemos todas las contraseñas en una lista
        //él recomienda probarlo con 20-30 y luego ya hacerlo con las 3 millones de contraseñas


        //Zona de la contraseña de la que tenemos el hash, convirtiéndola y obteniendo su valor
        byte[] pass = GetHash("asldioasdp");
        string passString = devolverHash(pass);
        //Zona de acceso y lectura del fichero
        List<String> passList = new List<string>();
        string path = "C:\\Users\\javil\\Desktop\\2DAM\\gigante de jagger\\passwordsmentira1.txt";
        rellenarLista(passList, path);
        crackearPassword(passList,passString);
    }

    public static byte[] GetHash(string password)
    {
        using (HashAlgorithm algoritmo = SHA256.Create())
            return algoritmo.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    public static string devolverHash(byte[] passHash)
    {
        string resultado = "";
        foreach (var b in passHash)
        {
            resultado += $"{b:X2}";
        }

        return resultado;
    }

    public static void crackearPassword(List<String> passList,string passString)
    {
        foreach (var passtemp in passList)
        {
            if ((devolverHash(GetHash(passtemp))).Equals(passString))
            {
                Console.WriteLine("Contraseña encontrada: " + passtemp);
            }
        }
    }

    public static void rellenarLista(List<String> passList,string pathFichero)
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