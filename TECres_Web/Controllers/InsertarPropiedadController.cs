using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TECres_Web.Models;

namespace TECres_Web.Controllers
{
    public class InsertarPropiedadController : ApiController
    {
        private DB_TECres.TECresEntities db = new DB_TECres.TECresEntities();

        [HttpGet]
        [Route("api/InsertarPropiedad")]
        public IHttpActionResult InsertarPropiedad(int pPrecio,string pDireccion_Exacta,string pTitulo,bool pParqueo_Visitas,int pNiveles,bool pPiscina,bool pGimnasio,int pTamano_Terreno,int pTamano_Construccion,int pCant_Habitaciones,int pCant_Banos,int pCant_Parqueos,string pDescripcion,string pFoto_Principal,int pID_Ubicacion,string pNombre_Inmueble,int pCedula_Cliente,string pNombrePiso)
        {
            spInsertarPropiedadModelo modelo = new spInsertarPropiedadModelo();
            modelo.Insertar_Propiedad = db.SP_Insertar_Propiedad(pPrecio, pDireccion_Exacta, pTitulo, pParqueo_Visitas, pNiveles, pPiscina, pGimnasio, pTamano_Terreno, pTamano_Construccion, pCant_Habitaciones,pCant_Banos,pCant_Parqueos,pDescripcion,pFoto_Principal,pID_Ubicacion,pNombre_Inmueble,pCedula_Cliente,pNombrePiso);
            return Ok(modelo);

        }
    }
}