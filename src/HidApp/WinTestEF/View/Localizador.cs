﻿using System.Collections.Generic;

namespace WinTestEF.View
{
  public class Localizador : IViewLocator
  {
    private Dictionary<ViewType, object> _viewsCache;

    public Localizador()
    {
      _viewsCache = new Dictionary<ViewType, object>();

      _viewsCache.Add(ViewType.About, new AboutView());
    }

    public object GetView(ViewType viewType)
    {
      object result = null;

      if (viewType == ViewType.Ninguno)
        return null;

      if (!_viewsCache.TryGetValue(viewType, out result))
      {
        switch (viewType)
        {
          case ViewType.StartMenu:
            result = new StartView();
            break;

          case ViewType.About:
            result = new AboutView();
            break;

          case ViewType.Stock:
            //result = new StockView(this);   //  WARNING!!!
            break;

          case ViewType.StockInsumos:
            //result = new StockInsumosView();
            break;
          
          case ViewType.PacientesView:
            //result = new PacientesView();
            break;

          case ViewType.Vista_1:
            result = new Vista1View(this);
            break;
                
        }
        _viewsCache.Add(viewType, result);
      }
      return result;
    }

    //  chequear el arbol de vistas, ver si es necesario activar primero una vista parent (podria haber mas de una??)
  }
}
