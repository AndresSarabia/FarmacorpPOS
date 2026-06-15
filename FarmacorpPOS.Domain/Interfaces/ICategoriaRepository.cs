using System;
using System.Collections.Generic;
using System.Text;
using FarmacorpPOS.Domain.Entities;

namespace FarmacorpPOS.Domain.Interfaces;

public interface ICategoriaRepository
{
    Task<Categoria?> GetByIdAsync(int id);

    Task AddAsync(Categoria categoria);

    Task<List<Categoria>> GetAllAsync();
}
