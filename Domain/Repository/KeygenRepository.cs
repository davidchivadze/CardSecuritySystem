using Domain.Interface;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class KeygenRepository : BaseRepository<Keygen>, IKeygenRepository
    {
        public KeygenRepository(Data database) : base(database)
        {
        }
        public Keygen GetActiveKeygen()
        {
           var activeKeygens=_database.Keygens.Where(m => m.IsActive).FirstOrDefault();
            if (activeKeygens!=null&&activeKeygens.DateTo < DateTime.Now)
            {
                activeKeygens.IsActive = false;
                _database.SaveChanges();
                return null;
            }
            else
            {
                return activeKeygens;
            }
            
        }

        public bool UpdateKeygen(Keygen model)
        {
            try { 
            var activeKeygens = _database.Keygens.Where(m => m.IsActive).FirstOrDefault();
                if (activeKeygens != null) { 
            activeKeygens.IsActive = false;
            _database.SaveChanges();
                }
                _database.Keygens.Add(model);
            _database.SaveChanges();
            return true;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
