﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
  public class AuditInfo
  {
    /// <summary>
    /// Necesario para manejar entidades en E-F
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// Representa la direccion del punto de origen de la informacion de auditoria
    /// </summary>
    public string Source { get; set; }

    /// <summary>
    /// Que tipo de evento de auditoria estoy informando?
    /// </summary>
    public InfoType Type { get; set; }

    /// <summary>
    /// Fecha/hora de produccion del evento de auditoria
    /// </summary>
    public DateTime Fecha { get; set; }

    /// <summary>
    /// Contenido de la información auditada, puede ser un detalle importante o absolutamente nada
    /// </summary>
    public string Detalles { get; set; }

    public AuditInfo()
    {
      Fecha = DateTime.Now;
      Type = InfoType.Otros;
      Source = "Test Entry";
    }
  }

  /// <summary>
  /// Los tipos de eventos que se me ocurren por ahora...
  /// Similares a los que tengo en el proyecto
  /// </summary>
  public enum InfoType
  {
    /// <summary>
    /// Por ejemplo cuando tengo intentos fallidos o si algun usuario quisiera hacer cosas no permitidas
    /// </summary>
    Seguridad,

    /// <summary>
    /// Intento de leer informacion que se considera critica o confidencial (raro)
    /// </summary>
    Lectura,

    /// <summary>
    /// Intento de incorporar un nuevo registro (o mas de uno) de una entidad en el sistema
    /// </summary>
    Agregado,

    /// <summary>
    /// Intento de cambiar alguno de los datos de una entidad del sistema
    /// </summary>
    Modificacion,

    /// <summary>
    /// 
    /// </summary>
    Borrado,

    /// <summary>
    /// 
    /// </summary>
    Acceso,

    /// <summary>
    /// 
    /// </summary>
    Ingreso,

    /// <summary>
    /// 
    /// </summary>
    Otros
  }
}
