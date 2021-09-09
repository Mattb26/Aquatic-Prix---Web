using AquaticApiContacto.IServicios;
using System.Collections.Generic;

namespace AquaticApiContacto.Deal
{
    public class Contacto : IContacto
    {
        private readonly IContactoData _contacto;

        public Contacto(IContactoData contacto)
        {
            _contacto = contacto;
        }

        public bool Agregar(Models.Contacto contacto)
        {

            try
            {
                ModelsSQL.Contacto _contact = new ModelsSQL.Contacto()
                {
                    Asunto = contacto.Asunto,
                    CorreoElectronico = contacto.CorreoElectronico,
                    Fecha = System.DateTime.Now,
                    Mensaje = contacto.Mensaje,
                    Nombre = contacto.Nombre
                };

                return _contacto.Agregar(_contact);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public List<ModelsSQL.Contacto> Listado()
        {
            try
            {
                return _contacto.Listado();
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
