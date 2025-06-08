using System.Security.Cryptography;
using System.Text;

namespace DistributedCacheSimulatorService.Services
{
    public class ConsistentHashRingService
    {
        private SortedDictionary<int, CacheNodeService> Ring = new SortedDictionary<int, CacheNodeService>();

        public void AddNode(CacheNodeService node)
        {
            int hash = GetHash(node.NodeId);
            Ring[hash] = node;
            Console.WriteLine($"Added Node {node.NodeId} to HashRing at {hash}");
        }

        public void RemoveNode(CacheNodeService node)
        {
            int hash = GetHash(node.NodeId);
            Ring.Remove(hash);
            Console.WriteLine($"Removed Node {node.NodeId} from HashRing at {hash}");
        }

        public CacheNodeService? GetNode(string key)
        {
            if (Ring.Count == 0) return null;

            int hash = GetHash(key);

            foreach (var kvp in Ring)
            {
                if (hash <= kvp.Key)
                    return kvp.Value;
            }
            
            return Ring.First().Value;
        }

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