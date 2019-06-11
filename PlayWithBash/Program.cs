using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace PlayWithBash
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new Program().archivos("Prueba.txt");
            if (args.Any())
            {
                System.Console.WriteLine("Derechos reservados compilando: " + args[0]);
                Console.WriteLine();
                //new Program().archivos( args[0] );
                
            }
            else
            {
                Console.WriteLine("Sin parámetros");
            }            
            //Console.ReadKey();
        }

        private void Algo()
        {
            Process test = new Process();
            test.StartInfo.FileName = "ipconfig";
            test.StartInfo.UseShellExecute = false;
            test.StartInfo.Arguments = "/all";
            test.StartInfo.RedirectStandardInput = true;
            test.StartInfo.RedirectStandardOutput = true;
            test.Start();

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.UseShellExecute = false;
            psi.Arguments = "-jar -XX:+UseConcMarkSweepGC -Xmx1024M -Xms1024M START.jar";
            psi.CreateNoWindow = true;
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.FileName = "jre8\\bin\\javaw.exe";
            Process.Start(psi);

            test.StandardOutput.ReadToEnd();
            Console.WriteLine(test);

            //Set WshShell = CreateObject("WScript.Shell")
            //WshShell.Run chr(34) &"miprograma.bat" & Chr(34), 0
            //Set WshShell = Nothing

            //guardarlo como archivo.vbs
        }

        private void archivos(string name)
        {
            //StreamWriter writer = File.CreateText("Archivo.txt");
            //StreamWriter fileA = File.AppendText("Path/ArchivoA.txt");
            //fileA.WriteLine("Escrbiendo en el archivo");
            //fileA.Close();

            StreamWriter fileB = File.CreateText("Sys" + name);
            StreamReader reader = File.OpenText(name);

            string cadena = reader.ReadLine();
            
            while (cadena != null)
            {
                for (int i = 0; i < cadena.Length; i++)
                {
                    cadena = cadena.Replace(" ", string.Empty);

                    cadena = cadena.Replace("\t", string.Empty);

                    if (cadena[i] == '/' && cadena[i + 1] == '/')
                    {
                        if (i>1)
                        {
                            string temp = "";
                            for (int j = 0; j < i; j++)
                            {
                                temp += cadena[j];
                            }
                            cadena = temp;
                            break;
                        }
                        else
                        {
                            cadena = reader.ReadLine();
                        }

                        i = 0;
                        if (cadena == null)
                        {
                            break;
                        }
                    }
                }
                fileB.WriteLine(cadena);
                cadena = reader.ReadLine();
            }
            fileB.Close();
            reader.Close();
            //Justice League, Batman VS Superman, Suicide Squad
        }
    }
}
