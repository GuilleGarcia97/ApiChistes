using ApiChistes.Data;
using ApiChistes.Models;
using ApiChistes.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiChistes.Services.ChisteService
{
    public interface IChisteService
    {
        Task<List<Chiste>> GetAllChistes();
        Task<Chiste> GetChiste(int id);
        Task<Chiste> PostChiste(ChisteDto chiste,string email);
        Task<Chiste> ModifyChiste(Chiste chiste);
        Task<Chiste> DeleteChiste(int id);
    }
}
