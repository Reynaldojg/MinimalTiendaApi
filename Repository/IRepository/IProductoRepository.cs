using System;
using TiendaApi.Models;
using TiendaApi.Models.DTOS;

namespace TiendaApi.Repository.IRepository;

public interface IProductoRepository
{
    public ICollection<Productos> GetAll();
    Productos GetById(int id);
    bool Add(Productos dTO);
    bool Update(Productos dTO);
    bool Delete(Productos dTO);
    bool Save();
}
