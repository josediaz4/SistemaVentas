﻿using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Rol
    {
        private CD_Rol objcd_rol = new CD_Rol();

        public List<Rol> Listar()
        {
            return objcd_rol.Listar();
        }
    }
}
