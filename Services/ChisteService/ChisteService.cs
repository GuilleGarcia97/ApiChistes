using ApiChistes.Data;
using ApiChistes.Models;
using ApiChistes.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ApiChistes.Services.ChisteService
{
    public class ChisteService : IChisteService
    {
        public readonly DataBaseContext _context;

        public ChisteService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<List<Chiste>> GetAllChistes()
        {
            return  await _context.Chistes.ToListAsync();
        }

        public async Task<Chiste> GetChiste(int id)
        {
            // Si devuelve null se gestiona en el controller con un NotFound
            return await _context.Chistes.FindAsync(id);
        }
        public async Task<Chiste> PostChiste(ChisteDto chiste, string email)
        {

            Chiste auxChiste = new Chiste(chiste.texto, email);
            _context.Chistes.Add(auxChiste);
            await _context.SaveChangesAsync();

            return await GetChiste(auxChiste.Id);
        }
        public async Task<Chiste> ModifyChiste(Chiste chiste)
        {
            var auxChiste = await _context.Chistes.FindAsync(chiste.Id);
            if (auxChiste != null) 
            {
                auxChiste.Texto = chiste.Texto;
                await _context.SaveChangesAsync();
            }
            // Si devuelve null se gestiona en el controller con un NotFound
            return auxChiste;
        }

        public async Task<Chiste> DeleteChiste(int id)
        {
            var auxChiste = await _context.Chistes.FindAsync(id);
            if (auxChiste != null)
            {
                _context.Chistes.Remove(auxChiste);
                await _context.SaveChangesAsync();
            }

            return auxChiste;
        }
        

    }
}
