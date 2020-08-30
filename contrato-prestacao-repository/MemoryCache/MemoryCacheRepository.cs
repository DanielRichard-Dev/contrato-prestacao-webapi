using Microsoft.Extensions.Caching.Memory;
using System;

namespace contrato_prestacao_repository.MemoryCache
{
    public class MemoryCacheRepository
    {
        public IMemoryCache cache;

        public MemoryCacheRepository(IMemoryCache cache)
        {
            this.cache = cache;
        }

        public string Get()
        {
            cache.Set("IDGKey", DateTime.Now.ToString());

            return "This is a test method...";
        }

    }
}
