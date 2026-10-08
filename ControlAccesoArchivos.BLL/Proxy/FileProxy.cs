using ControlAccesoArchivos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAccesoArchivos.BLL.Proxy
{
    public class FileProxy : IFile
    {
        private RealFile _realFile;
        private string _fileName;
        private User _user;

        // El Proxy recibe el nombre del archivo y el usuario que intenta acceder
        public FileProxy(string fileName, User user)
        {
            _fileName = fileName;
            _user = user;
            // No instanciamos _realFile aquí para ahorrar recursos (Virtual Proxy). 
            // Lo instanciamos solo cuando estemos seguros de que se necesita.
        }

        // Método privado para instanciar (o recuperar) el archivo real solo si es necesario
        private RealFile GetRealFile()
        {
            if (_realFile == null)
            {
                _realFile = new RealFile(_fileName);
            }
            return _realFile;
        }

        public void Read()
        {
            // Verificamos si tiene el permiso 'read'
            if (_user.HasPermission("read"))
            {
                GetRealFile().Read();
            }
            else
            {
                Console.WriteLine($"[Proxy] ACCESO DENEGADO. El usuario '{_user.Username}' no tiene permiso para LEER.");
            }
        }

        public void Write(string content)
        {
            // Verificamos si tiene el permiso 'write'[cite: 58]
            if (_user.HasPermission("write"))
            {
                GetRealFile().Write(content);
            }
            else
            {
                Console.WriteLine($"[Proxy] ACCESO DENEGADO. El usuario '{_user.Username}' no tiene permiso para ESCRIBIR.");
            }
        }

        public void Delete()
        {
            // Verificamos si tiene el permiso 'delete'
            if (_user.HasPermission("delete"))
            {
                GetRealFile().Delete();
            }
            else
            {
                Console.WriteLine($"[Proxy] ACCESO DENEGADO. El usuario '{_user.Username}' no tiene permiso para ELIMINAR.");
            }
        }
    }
}
