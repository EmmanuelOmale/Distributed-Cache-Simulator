using System.Security.Cryptography;
using System.Text;

namespace DistributedCacheSimulatorService.Services
{
    public class ConsistentHashRingService
    {
        private SortedDictionary<int, CacheNodeService> Ring = new SortedDictionary<int, CacheNodeService>();

        

        private int GetHash(string input)
        {
            using (var md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToInt32(hash, 0);
            }
        }
    }
}