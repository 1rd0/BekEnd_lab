
using Microsoft.Extensions.Caching.Memory;
using asp_empty.data;
using asp_empty.Models;
using Microsoft.IdentityModel.Tokens;

namespace asp_empty.Controllers
{
    public static class DataProxy
    {
        public static IMemoryCache cache = new MemoryCache(new MemoryCacheOptions());

        public static User? GetUserById(int id)
        {
            if(cache.TryGetValue(id, out User? user))
            {
                return user;
            }
            return null;
        }

        public static void SetUser(User user)
        {
             cache.Set(user.Username, user,new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(5)));
    }

    }


    
}
