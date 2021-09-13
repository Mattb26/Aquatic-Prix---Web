using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquaticAPIUsuario.IServicios
{
    public interface IMailDato
    {
        bool Existe(string correo);
    }
    public interface IMail
    {
        bool Existe(string correo);
    }
}
