﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraBars.Ribbon;

namespace WinTestEF
{
  public static class Helpers
  {
    public static frmNavegacion MainForm { get; set; }

    public static ViewType DefaultViewType
    {
      get { return ViewType.Ninguno; }
    }

    //public static void BindCommandByName()
  }

  public interface IWorkView
  {
    void BindCommands(ISupportRibbon parent);
  }

  public interface INavigableView
  {
    
  }

  /// <summary>
  /// Define cada tipo de vista dentro del sistema
  /// </summary>
  public enum ViewType
  {
    /// <summary>
    /// No hay ninguna vista activa
    /// </summary>
    Ninguno,
    /// <summary>
    /// UC integrable en el formulario principal
    /// </summary>
    About,
    /// <summary>
    /// Usado en la ventana modal de login
    /// </summary>
    Login,
    /// <summary>
    /// UC con tiles que permiten la navegación entre diferentes secciones de la aplicacion
    /// </summary>
    StartMenu,
    /// <summary>
    /// UC con Ribbon integrable, no tiene nada pero por defecto deberia ir a StockInsumos (guardar ultima seleccion)
    /// </summary>
    Stock,
    /// <summary>
    /// UC integrable, seleccionado mediante la pagina Insumos de la Ribbon de Stock
    /// </summary>
    StockInsumos,
    /// <summary>
    /// UC integrable, seleccionado mediante la pagina Alquilables de la Ribbon de Stock
    /// </summary>
    StockAlquilables,
    /// <summary>
    /// UC integrable, permite administrar la impresion de etiquetas
    /// </summary>
    ///StockEtiquetas,
    /// <summary>
    /// UC integrable, permite incorporar la impresión de reportes relacionados con el stock
    /// </summary>
    StockReportes,
    PacientesView,
    /// <summary>
    /// Vista navegable de prueba
    /// </summary>
    Vista_1,
    /// <summary>
    /// Vista de trabajo de prueba #1
    /// </summary>
    Pagina_1,
    /// <summary>
    /// Vista de trabajo de prueba #2
    /// </summary>
    Pagina_2
  }

  /// <summary>
  /// Esta interface sirve para decidir si una vista necesita o no merge y por supuesto para obtener el ribbon que posee
  /// </summary>
  public interface ISupportRibbon
  {
    RibbonControl Ribbon { get; }
    void FocusOnPage(RibbonControl ribbon);
  }

  public interface IViewLocator
  {
    object GetView(ViewType viewType);
  }

  /// <summary>
  /// Una vista que soporta esta interface guarda informacion de la vista previa que estaba activa, para que se reemplace con ésta
  /// al cerrarse
  /// </summary>
  public interface ISupportPreviousView
  {
    ViewType PreviousViewType { get; set; }
  }

  public interface ILoginService
  {
    void Show();
  }


}