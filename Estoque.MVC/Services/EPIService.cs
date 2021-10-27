using Estoque.MVC.Data;
using Estoque.MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estoque.MVC.Services
{
    public class EPIService
    {
        private readonly EstoqueMVCContext _context;

        public EPIService(EstoqueMVCContext context)
        {
            _context = context;
        }

        public async Task<List<EPI>> BuscarTodosAsync()
        {
            return await _context.EPI.OrderBy(x => x.Nome).ToListAsync();
        }

        public async Task<EPI> BuscarPorIdAsync(int id)
        {
            return await _context.EPI.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<EPI> BuscarPorNomeAsync(string nome)
        {
            return await _context.EPI.FirstOrDefaultAsync(x => x.Nome == nome);
        }

        public async Task CriarAsync(EPI epi)
        {
            _context.Add(epi);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(EPI epi)
        {
            _context.Update(epi);
            await _context.SaveChangesAsync();
        }

        public async Task AdicionarAsync(int id, int quant, double valor)
        {
            EPI epi = await BuscarPorIdAsync(id);
            epi.Quantidade += quant;
            epi.Valor = valor;
            _context.Update(epi);
            await _context.SaveChangesAsync();
        }
    }
}
