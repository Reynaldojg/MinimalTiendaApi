using System;

namespace TiendaApi.Models.DTOS;

public class ProductoDTO
{
    public int Id {get; set;}
    public string Name {get; set;} = string.Empty;
    public double Price {get;set;}
}
