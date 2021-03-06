﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Infraestructura
{
  public enum ErrorType
  {
    Validation,
    Exception,
    BusinessLogic,
    Otros
  }

  /// <summary>
  /// Las instancias de esta clase contienen descripciones de errores que han ocurrido a distintos niveles de la aplicacion
  /// Permite conversion desde excepciones, errores de EF, etc...
  /// Normalmente usados desde la UI para mostrar informacion relevante al usuario
  /// TODO incorporar logging??
  /// </summary>
  public class HidErrorInfo
  {
    public ErrorType Tipo { get; set; }

    public string Descripcion { get; set; }

    public static HidErrorInfo FromEFError(DbValidationError error)
    {
      return new HidErrorInfo()
      {
        Descripcion = string.Format("{1} --> {0}", error.ErrorMessage, error.PropertyName),
        Tipo = ErrorType.Validation
      };
    }

    public static IList<HidErrorInfo> FromEFCollectionError(ICollection<DbValidationError> collection)
    {
      return collection.Select(HidErrorInfo.FromEFError).ToList();
    }

    public static HidErrorInfo FromException(System.Exception exception)
    {
      //  TODO Considerar InnerException si existe!!
      return new HidErrorInfo()
      {
        Descripcion = string.Format("{1} --> {0}", exception.Message, exception.GetType().FullName), 
        Tipo = ErrorType.Exception
      };
    }
  }
}
