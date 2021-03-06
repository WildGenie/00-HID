
using System;
using System.Collections.Generic;

namespace Entidades
{
	public class enTArticulo
	{
    public enTArticulo()
    {
      this.TDetalleOrden = new HashSet<enTDetalleOrden>();
      this.TOrden = new HashSet<enTOrden>();
      this.TRent = new HashSet<enTRent>();
    }
    
    public int IdArticulo { get; set; }

    public string CodeBar { get; set; }
    
    public int? IdRecurso { get; set; }
    
    public int? IdTipoArticulo { get; set; }
    
    public string DetalleArticulo { get; set; }
    
    public string AvisoStockMinimo { get; set; }
    
    public decimal? PrecioCompra { get; set; }
    
    public decimal? PrecioVenta { get; set; }
    
    public decimal? PrecioAlquiler { get; set; }
    
    public int? Stock { get; set; }
    
    public int? Stockminimo { get; set; }
    
    public byte[] Imagen { get; set; }
    
    public virtual enTRecurso TRecurso { get; set; }
    
    public virtual enTTipoArticulo TTipoArticulos { get; set; }
    
    public virtual ICollection<enTDetalleOrden> TDetalleOrden { get; set; }
    
    public virtual ICollection<enTOrden> TOrden { get; set; }
    
    public virtual ICollection<enTRent> TRent { get; set; }

	}
}
