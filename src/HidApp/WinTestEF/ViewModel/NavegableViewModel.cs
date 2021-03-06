﻿using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Data.Async;
using DevExpress.Mvvm;

namespace WinTestEF.ViewModel
{
  //
  //  Este es un VM que pertenece a una NavigableView, no deberia tener algo que lo distinga?
  //  Si lo pensamos es similar o tiene bastantes similitudes con MainViewModel....
  public class NavegableViewModel : ViewModelBase
  {
    private ViewType _selectedViewType;
    private object _selectedView;
    private readonly IViewLocator _locator;

    public NavegableViewModel(IViewLocator locator)
    {
      //  ojo el IViewLocator deberia ser unico para toda la app!!!
    }

    public void SetDefaultView()
    {
      Helpers.MainForm.MainViewModel.NavigateTo(ViewType.StockInsumos);
    }
  }
}
