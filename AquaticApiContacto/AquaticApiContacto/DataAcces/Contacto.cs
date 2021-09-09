using AquaticApiContacto.IServicios;
using AquaticApiContacto.ModelsSQL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AquaticApiContacto.DataAcces
{
    public class Contacto : IContactoData
    {
        private readonly AquaticPrixContext _aquaticPrixContext;
        public Contacto(AquaticPrixContext aquaticPrixContext)
        {
            _aquaticPrixContext = aquaticPrixContext;
        }

        public bool Agregar(ModelsSQL.Contacto contacto)
        {
            Int32 idContacto = 0;

            var id = _aquaticPrixContext.Contactos.Add(contacto);
            _aquaticPrixContext.SaveChanges();

            idContacto = id.Entity.IdContacto;

            if (idContacto > 0)
            {
                return true;
            }
            else 
            {
                return false;
            }

        }

        public List<ModelsSQL.Contacto> Listado()
        {
            try
            {
                return _aquaticPrixContext.Contactos.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }
    }
}
