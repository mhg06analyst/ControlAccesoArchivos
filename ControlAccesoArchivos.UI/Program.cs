using System;
using System.Collections.Generic;
using ControlAccesoArchivos.BLL.Proxy;
using ControlAccesoArchivos.Domain;

namespace ControlAccesoArchivos.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SISTEMA DE CONTROL DE ACCESO A ARCHIVOS (Patrón Proxy) ===\n");

            // 1. Configuramos los usuarios de prueba según el requerimiento
            User juan = new User("juan", new HashSet<string> { "read", "write" });
            User readonlyUser = new User("readonly_user", new HashSet<string> { "read" });

            // --- CASO DE PRUEBA 1: Usuario "juan" ---
            Console.WriteLine("--- Probando con usuario: juan ---");
            IFile archivoJuan = new FileProxy("reporte_financiero.txt", juan);

            // juan intenta escribir -> PERMITIDO[cite: 58]
            Console.WriteLine("\n[Acción] juan intenta escribir:");
            archivoJuan.Write("Nuevos datos financieros para el mes.");

            // juan intenta eliminar -> DENEGADO[cite: 58]
            Console.WriteLine("\n[Acción] juan intenta eliminar:");
            archivoJuan.Delete();


            // --- CASO DE PRUEBA 2: Usuario "readonly_user" ---
            Console.WriteLine("\n\n--- Probando con usuario: readonly_user ---");
            IFile archivoReadOnly = new FileProxy("reporte_anual.txt", readonlyUser);

            // readonly_user intenta leer -> PERMITIDO[cite: 58]
            Console.WriteLine("\n[Acción] readonly_user intenta leer:");
            archivoReadOnly.Read();

            // readonly_user intenta escribir -> DENEGADO[cite: 58]
            Console.WriteLine("\n[Acción] readonly_user intenta escribir:");
            archivoReadOnly.Write("Intentando inyectar datos falsos.");


            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}