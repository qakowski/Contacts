//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;
//using Contacts.Models;
//using Microsoft.EntityFrameworkCore;

//namespace Contacts.Implementations
//{
//    class ContactRepository : IContactRepository
//    {
//        private readonly Context _dbContext;
//        public ContactRepository(string dbPath)
//        {
//           _dbContext = new Context(dbPath);
//        }
//        public async Task<bool> AddContact(Contact contact)
//        {
//            try
//            {
//                var tracking = await _dbContext.Contacts.AddAsync(contact);

//                await _dbContext.SaveChangesAsync();
//                var isAdded = tracking.State == EntityState.Added;
//                return isAdded;
//            }
//            catch(Exception e)
//            {
//                return false;
//            }
//        }
//        public async Task<bool> UpdateContact(Contact contact)
//        {
//            try
//            {
//                var tracking = _dbContext.Update(contact);
//                await _dbContext.SaveChangesAsync();
//                var isUpdated = tracking.State == EntityState.Modified;
//                return isUpdated;

//            }
//            catch(Exception e)
//            {
//                return false;
//            }
//        }


//            public async Task<IEnumerable<Contact>> GetContactsAsync()
//        {
//            try
//            {
//                var products = await _dbContext.Contacts.ToListAsync();
//                return products;
//            }
//            catch (Exception e)
//            {
//                return null;
//            }
//        }

//        public async Task<bool> RemoveContact(int id)
//        {
//            try
//            {
//                var contact = _dbContext.Contacts.FindAsync(id);
//                var tracking = _dbContext.Remove(contact);
//                await _dbContext.SaveChangesAsync();
//                var isDeleted = tracking.State == EntityState.Deleted;
//                return isDeleted;
//            }
//            catch(Exception e) { 
//            return false;
//            }
//        }

        
//    }
//}
