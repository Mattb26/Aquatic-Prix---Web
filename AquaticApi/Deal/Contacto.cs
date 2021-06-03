using System;

namespace AquaticApi.Deal
{
    public class Contacto
    {
        public bool Agregar(Models.Contacto contact)
        {
            DataAccess.Contacto contacto;
            try
            {
                contacto = new DataAccess.Contacto();
                return contacto.Agregar(contact);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
