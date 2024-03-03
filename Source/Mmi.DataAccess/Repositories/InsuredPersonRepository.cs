using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Mmi.Core.Domain;
using Mmi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mmi.DataAccess.Repositories
{
    public class InsuredPersonRepository : IInsuredPersonRepository
    {
        private readonly MedicalInsuranceDb _db;
        private readonly DbSet<InsuredPerson> _collection;

        public InsuredPersonRepository(MedicalInsuranceDb db) 
        {
            _db = db;
            _collection = _db.InsuredPersons;
        }

        public async Task<InsuredPerson?> FinByAuthorizationDataAsync(string email, string password)
        { 
            return await _collection
                .Where(person => person.Email == email && person.Password == password)
                .FirstOrDefaultAsync();
        }

        public async Task<InsuredPerson?> FindByIdAsync(uint personId)
        {
            return await _collection
                .Where(person => person.Id == personId)
                .FirstOrDefaultAsync();
        }

        public async Task CreatePersonAsync(InsuredPerson person)
        {
            await _collection.AddAsync(person);
            await _db.SaveChangesAsync();
        }

        Task<InsuredPerson> IInsuredPersonRepository.CreatePersonAsync(InsuredPerson person)
        {
            throw new NotImplementedException();
        }
    }
}
