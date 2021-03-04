using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class StoreRepository 
    {
        private readonly project1Context _context;
        public StoreRepository(project1Context context)
        {
            _context = context;
        }
        public List<Library.StoreLocation> GetAllStores()
        {
            var results = _context.StoreLocations;

            List<Library.StoreLocation> storeLocations = new List<Library.StoreLocation>();

            foreach (var result in results)
            {
                storeLocations.Add(new Library.StoreLocation(result.City, result.State, result.Address, result.PhoneNumber, result.Id));
            }

            return storeLocations;
        }

        public Library.StoreLocation GetStoreById(int id)
        {
            var result = _context.StoreLocations.Where(x => x.Id == id).FirstOrDefault();

            Library.StoreLocation storeLocation = new Library.StoreLocation(result.City,result.State,result.Address,result.PhoneNumber,result.Id);

            return storeLocation;
        }


    }
}
