using System.Collections.Generic;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Permiso
    {
        private CD_Permiso objcd_permiso = new CD_Permiso();

        public List<Permiso> Listar(int idusuario)
        {
            return objcd_permiso.Listar(idusuario);
        }
    }
}
