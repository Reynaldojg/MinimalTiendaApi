using System;

namespace TiendaApi.Models;

public class Productos
{
    public int Id {get; set;}
    public string Name {get; set;} = string.Empty;
    public double Price {get;set;}
    public DateTime DateCreate {get; set;}

}
