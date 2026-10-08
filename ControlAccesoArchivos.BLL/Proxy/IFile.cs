using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAccesoArchivos.BLL.Proxy
{
    public interface IFile
    {
        void Read();
        void Write(string content);
        void Delete();
    }
}
