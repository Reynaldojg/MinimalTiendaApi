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
        return SaveChanges();
    }

    public bool Delete(Productos dTO)
    {
        _DbContext.Productos.Remove(dTO);
        return SaveChanges();
    }

    public ICollection<Productos> GetAll()
    {
        return _DbContext.Productos.OrderBy(p => p.Name).ToList();
    }

    public Productos GetById(int Productoid)
    {
        return _DbContext.Productos.FirstOrDefault(p => p.Id == Productoid);
    }

    public bool SaveChanges()
    {
        throw new NotImplementedException();
    }

    public bool Update(Productos dTO)
    {
        throw new NotImplementedException();
    }
}
