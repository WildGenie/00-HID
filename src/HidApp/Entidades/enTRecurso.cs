using System;
using System.ComponentModel;
using System.Collections.Generic;


namespace Entidades
{
  /// <summary>
  /// Clase que representa a un integrante de la empresa, cualquiera sea su actividad
  /// </summary>
	public class enTRecurso : INotifyPropertyChanged
	{
    private string _apellido;
    private string _nombre;
    private byte[] _foto;

    public enTRecurso()
    {
      this.TArticulo = new HashSet<enTArticulo>();
      this.TCtaCteRecurso = new HashSet<enTCtaCteRecurso>();
      this.TOrden = new HashSet<enTOrden>();
      //  this.TUsuario = new HashSet<Usuario>();
    }
    
    public int IdRecurso { get; set; }
        
    public virtual string Apellido
    {
      get { return _apellido; }
      set { _apellido = value; OnPropertyChanged("Apellido"); }
    }

    public virtual string Nombre
    {
      get { return _nombre; }
      set { _nombre = value; OnPropertyChanged("Nombre"); }
    }

    public string Matricula { get; set; }
    
    public DateTime? FechaTituloMedico { get; set; }
    
    public DateTime? FechaNacimiento { get; set; }
    
    public string Direccion { get; set; }
    
    public string Telefono { get; set; }

    /*
        /// <summary>
        /// Gets or sets the IdCategoria value.
        /// </summary>
        public virtual int IdCategoria
        {
          get { return _idCategoria; }
          set { _idCategoria = value; }
        }
    */
    
    public string Celular { get; set; }
    
    public string CUIT { get; set; }

    /*
        /// <summary>
        /// Gets or sets the IdTipoIVA value.
        /// </summary>
        public virtual int IdTipoIVA
        {
          get { return _idTipoIVA; }
          set { _idTipoIVA = value; }
        }
    */

    public string email { get; set; }
    
    public string NroSeguroMAP { get; set; }
        
    public string Sssalud { get; set; }
    
    public byte[] Adjuntos { get; set; }
    
    public virtual byte[] Foto
    {
      get { return _foto; }
      set { _foto = value; OnPropertyChanged("Foto"); }
    }

    public string Observaciones { get; set; }
    
    public string Sexo { get; set; }
    
    public virtual ICollection<enTArticulo> TArticulo { get; set; }

    /// <summary>
    /// Representa el Tipo del Recurso (Administrativo, Profesional...Kinesiologo...)
    /// </summary>
    public virtual enTCategoriaRecurso Categoria { get; set; }
    
    public virtual ICollection<enTCtaCteRecurso> TCtaCteRecurso { get; set; }
    
    public virtual ICollection<enTOrden> TOrden { get; set; }

    /// <summary>
    /// Como esta inscripto el Recurso en la AFIP
    /// </summary>
    public virtual enTTipoIVA SituacionAFIP { get; set; }
    
    //  No la vamos a hacer bidireccional...
    //  public virtual ICollection<Usuario> TUsuario { get; set; }
    
    private void OnPropertyChanged(string prop)
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }

    public event PropertyChangedEventHandler PropertyChanged;
  }
}
