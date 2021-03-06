﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Data;
using Entidades;
using Infraestructura;
using System.Security.Cryptography;

/*
- Metodo para autenticar con manejo de errores (cuidar el texto del error)
  -- recordar que puede ocurrir que el usuario tenga un cambio de password pendiente
  --  la contraseña expiró
  -- la contraseña esta a punto de expirar (no es error sino warning)
- Metodo de cambio de password (por expiración, no por elección del usuario)
 * 
 */
namespace Servicios
{
  public class SecurityServices
  {
    /// <summary>
    /// Verifica que el usuario exista y que el password sea el correcto
    /// De ser asi, crea una instancia de Sesion
    /// </summary>
    /// <param name="user"></param>
    /// <param name="pass">Password en texto plano</param>
    /// <returns></returns>
    public Sesion LoginUser(string user, string pass)
    {
      Sesion ses = null;

      HIDContext ctx = DB.Context;

      //  TODO incorporar usuario habilitado y no bloqueado!!
      Usuario usr = ctx.Usuarios.FirstOrDefault(x => x.Login == user);

      if (usr != null)
      {
        //  seguimos intentando con la pass (primero la convertimos)

        int result =
          ctx.Database.SqlQuery<int>("SEGU.ValidarUsuarioPassword @p0, @p1", user, GetCyphredPass(pass))
            .FirstOrDefault();

        if (result == 1)
        {
          //  all right!!
          ses = new Sesion {Usuario = usr};

          usr.LastLogin = DateTime.Now;
          ctx.SaveChanges();

          //  Auditar ingreso exitoso
          Audit(InfoType.Ingreso, "UserLogin", string.Format("{0} --> ingreso correcto al sistema", user));
        }
        else
        {
          //  Auditar pass incorrecta
          Audit(InfoType.Acceso, "UserLogin", string.Format("{0} --> intento de acceso denegado por contraseña incorrecta", user));
          throw new HidAuthException("Las credenciales proporcionadas no son válidas. Intente nuevamente");
        }
      }
      else
      {
        //  Auditar? info nombre user
        Audit(InfoType.Acceso, "UserLogin", string.Format("{0} --> intento de acceso denegado por usuario inexistente", user));
        throw new HidAuthException("Las credenciales proporcionadas no son válidas. Intente nuevamente");   
      }
      return ses;
    }

    /// <summary>
    /// Realiza el logout del usuario actual (obtenido desde la Sesion)
    /// Elimina la sesion y audita
    /// Podria ajustar la hora de logout en la DB...por ahora no
    /// </summary>
    public void LogoutUser()
    {
      Usuario current = Contexto.Current.Sesion.Usuario;

      Audit(InfoType.Ingreso, "UserLogout", string.Format("{0} --> usuario desconectado. Conectado desde {1}", current.Login, current.LastLogin));
      Contexto.Current.InvalidateSesion();
    }

    /// <summary>
    /// Retorna la password cifrada con el algoritmo elegido (por ahora SHA-256)
    /// </summary>
    /// <param name="original"></param>
    /// <returns></returns>
    private string GetCyphredPass(string original)
    {
      string result = null;

      //  asegurarse que no es null...aunque la pass nunca puede venir asi!!
      //
      using (SHA256CryptoServiceProvider sha = new SHA256CryptoServiceProvider())
      {
        byte[] origBytes = Encoding.UTF8.GetBytes(original);
        byte[] crypBytes = sha.ComputeHash(origBytes);

        result = Convert.ToBase64String(crypBytes);
      }
      return result;
    }

    private void Audit(InfoType tipo, string subPath, string detalle)
    {
      //  TODO eliminar la dependencia implementando un servicio de registro singleton o una inversion de dependencia con interface
      AuditServices audit = new AuditServices();
      AuditInfo ai = new AuditInfo() {Detalles = detalle, Type = tipo};

      ai.Source = string.Format("SecurityServices\\{0}", subPath); 
      audit.SaveAuditInfo(ai);
    }
  }
}
