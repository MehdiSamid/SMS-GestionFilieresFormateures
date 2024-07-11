﻿using SMS.Domain.Entities;
using SMS.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Repositories
{
    public class SecteurRepository : ISecteurRepository
    {
        private readonly List<Secteur> _secteurs; // Replace with actual data storage (e.g., database context)

        public SecteurRepository()
        {
            _secteurs = new List<Secteur>();
            // Initialize with some sample data if needed
            
        }

        public async Task<Secteur> AddAsync(Secteur secteur)
        {
            
            _secteurs.Add(secteur);
            return await Task.FromResult(secteur);
        }

        //public async Task<Secteur> GetByIdAsync(int id)
        //{
        //    return await Task.FromResult(_secteurs.FirstOrDefault(s => s.Id =));
        //}

        public async Task<IEnumerable<Secteur>> GetAllAsync()
        {
            return await Task.FromResult(_secteurs);
        }

        public async Task UpdateAsync(Secteur secteur)
        {
            var existingSecteur = _secteurs.FirstOrDefault(s => s.Id == secteur.Id);
            if (existingSecteur != null)
            {
                existingSecteur.Name = secteur.Name;
                // You can add more properties to update as needed
            }
            await Task.CompletedTask; // Or you can use Task.FromResult if returning a value
        }

        public async Task DeleteAsync(int id)
        {
            //var secteurToDelete = _secteurs.FirstOrDefault(s => s.Id == id);
            //if (secteurToDelete != null)
            //{
            //    _secteurs.Remove(secteurToDelete);
            //}
            //await Task.CompletedTask; // Or you can use Task.FromResult if returning a value
        }

        public Task<Secteur> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        // Implement other methods as needed (specific queries, etc.)
    }
}
