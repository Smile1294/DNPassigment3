using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DNPAssigment1.Models;
using DNPAssigment2.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using Models;

namespace DNPAssigment1.Persistance 
{
    public class AdultServices : IAdultServices
    {
        public async Task<Adult> getAdult(int id)
        {
            using (Context dbContext = new Context())
            {
                return dbContext.Adults.Include(a => a.JobTitle).FirstOrDefault(t => t.Id == id);
            }
        }

        public async Task UpdateAdults(Adult adultd)
        {
            using (Context dbContext = new Context())
            {
                Adult adult = dbContext.Adults.FirstOrDefault(t => t.Id == adultd.Id);
                dbContext.Adults.Remove(adult); 
                await dbContext.Adults.AddAsync(adultd);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<Adult> AddAdult(Adult adult)
        {
            var rand = new Random();
            await using Context dbContext = new Context();
            adult.Id = rand.Next();
            await dbContext.Adults.AddAsync(adult);
            await dbContext.SaveChangesAsync();
            return adult;
        }

       
        public async Task<List<Adult>> LoadAdultsAsync()
        {
            await using Context dbContext = new Context();
            return dbContext.Adults.Include(a => a.JobTitle).ToList();
        }

        public async Task RemoveAdult(int ID)
        {
            await using Context dbContext = new Context();
            Adult adult = dbContext.Adults.FirstOrDefault(d => d.Id == ID);
            dbContext.Adults.Remove(adult);
            await dbContext.SaveChangesAsync();

        }

        public List<T> ReadData<T>(string s)
        {
            using (var jsonReader = File.OpenText(s))
            {
                return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
            }
        }



    }
}