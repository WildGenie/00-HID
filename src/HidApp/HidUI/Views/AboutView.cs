﻿using System;
using System.Diagnostics;
using DevExpress.Mvvm.POCO;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using HidUI.Common;
using HidUI.ViewModel;

namespace HidUI.Views
{
  public partial class AboutView : XtraUserControl, ISupportRibbon, ISupportPreviousView
  {
    private readonly AboutViewModel _viewModel;
    private ViewType _previousViewType;

    private RibbonControl _ribbon;

    public AboutView()
    {
      InitializeComponent();
      //  inicializa el ViewModel (deberia hacerlo con un inyector...)
      _viewModel = ViewModelSource.Create<AboutViewModel>();

      BindCommands();
    }

    private void BindCommands()
    {
      bbiCloseAbout.BindCommand(() => _viewModel.Close(), _viewModel);
    }

    public RibbonControl Ribbon
    {
      get { return ribAbout; }
    }

    public void SetMainRibbon(RibbonControl ribbon)
    {
      _ribbon = ribbon;
    }

    public void BindEvents()
    {
    }

    public void FocusOnPage()
    {
      _ribbon.SelectedPage = ribAbout.Pages["ACERCA DE"];
    }

    /// <summary>
    /// Si la vista implementa este método, setea la pagina visible de la ribbon "principal" en una página por defecto de la ribbon 
    /// fusionada
    /// </summary>
    /// <param name="ribbon">La Ribbon owner o donde se fusiono la ribbon asociada de la vista actual</param>
    public void FocusOnPage(RibbonControl ribbon)
    {
    }

    private void AboutView_OnLoad(object sender, EventArgs e)
    {
      Debug.WriteLine("AboutView: OnLoad");
    }

    private void PageClick(object sender, RibbonPageGroupEventArgs e)
    {
      Debug.WriteLine("AboutView: Click en la cinta!!");
    }

    private void SelectedPage_Changed(object sender, EventArgs e)
    {
      Debug.WriteLine("AboutView: Cambio de Pagina!!");
    }

    ViewType ISupportPreviousView.PreviousViewType { get; set; }
  }
}
