using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAccesoArchivos.Domain
{
    public class User
    {
        public string Username { get; set; }

        // Usamos un HashSet de strings para almacenar los permisos ("read", "write", etc.)[cite: 58]
        public HashSet<string> Permissions { get; set; }

        public User(string username, HashSet<string> permissions)
        {
            Username = username;
            Permissions = permissions ?? new HashSet<string>();
        }

        // Método que valida si el usuario tiene un permiso específico[cite: 58]
        public bool HasPermission(string permission)
        {
            // Convertimos a minúsculas por seguridad al comparar
            return Permissions.Contains(permission.ToLower());
        }
    }
}
