using System;
using Microsoft.EntityFrameworkCore;
using TiendaApi.Data;
using TiendaApi.Models;
using TiendaApi.Models.DTOS;
using TiendaApi.Repository.IRepository;

namespace TiendaApi.Repository;

public class ProductoRepository : IProductoRepository
{
    private readonly AppDbContext _DbContext;
    public ProductoRepository(AppDbContext DbContext)
    {
        _DbContext = DbContext;
    }

    public bool Add(Productos dTO)
    {
        dTO.DateCreate = DateTime.Now;
        _DbContext.Productos.Add(dTO);
        return Save();
    }

    public bool Delete(Productos dTO)
    {
        _DbContext.Productos.Remove(dTO);
        return Save();
    }

    public ICollection<Productos> GetAll()
    {
        return _DbContext.Productos.OrderBy(p => p.Name).ToList();
    }

    public Productos GetById(int Productoid)
    {
        return _DbContext.Productos.FirstOrDefault(p => p.Id == Productoid);
    }

    public bool Save()
    {
        return _DbContext.SaveChanges() >= 0? true : false;
    }

    public bool Update(Productos dTO)
    {
        dTO.DateCreate = DateTime.Now;
       _DbContext.Productos.Update(dTO);
       return Save();
    }
}
