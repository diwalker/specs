using System;
using System.IO;

namespace specs
{
    public class MainClass
    {
        private static void WriteInfo(string info)
        {
            string timenow = DateTime.Now.ToString("dd-MM-yyyy - HH-mm-ss");
            string filename = $"PCSpecs - Result [{timenow}].txt";

            using (StreamWriter wf = File.CreateText(filename))
            {
                wf.WriteLine(info);
            }

            Console.WriteLine($"Arquivo escrito em: {Path.Combine(Environment.CurrentDirectory, filename)}");
        }

        public static void ShowInfo(bool write)
        {
            string is64Bit = Environment.Is64BitOperatingSystem ? "Sim" : "Não";

            string result = $@"Informações do PC:
==================

Sistema:
--------
Nome da máquina: {Environment.MachineName}
Versão do sistema: {Environment.OSVersion}
64-bit: {is64Bit}
Processadores: {Environment.ProcessorCount}
Versão CLR: {Environment.Version}

Local:
------
Usuário atual: {Environment.UserName}
Diretório atual: {Environment.CurrentDirectory}
Comando de execução: {Environment.CommandLine}";

            Console.WriteLine(result);
            if (write)
            {
                WriteInfo(result);
            }
        }

        public static void Main(string[] args)
        {
            var createFile = false;

            if (args.Length == 1 && (args[0].Equals("-f") || args[0].Equals("--file")))
            {
                createFile = true;
            }

            ShowInfo(createFile);
        }
    }
}
