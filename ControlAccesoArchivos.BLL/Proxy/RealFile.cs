using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAccesoArchivos.BLL.Proxy
{
    public class RealFile : IFile
    {
        private string _fileName;
        private string _fileContent;

        public RealFile(string fileName)
        {
            _fileName = fileName;
            _fileContent = "Contenido inicial del archivo.";
            Console.WriteLine($"[Sistema] Archivo físico '{_fileName}' instanciado en disco.");
        }

        public void Read()
        {
            Console.WriteLine($"[RealFile] Leyendo '{_fileName}': {_fileContent}");
        }

        public void Write(string content)
        {
            _fileContent = content;
            Console.WriteLine($"[RealFile] Escribiendo en '{_fileName}': {content}");
        }

        public void Delete()
        {
            _fileContent = string.Empty;
            Console.WriteLine($"[RealFile] Archivo '{_fileName}' eliminado del sistema.");
        }
    }
}
