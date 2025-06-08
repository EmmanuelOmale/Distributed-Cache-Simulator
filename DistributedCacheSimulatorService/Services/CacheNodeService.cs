namespace DistributedCacheSimulatorService.Services
{
    public class CacheNodeService
    {
        public string NodeId { get; set; }
        public Dictionary<string, string> CacheStorage { get; set; }

        public CacheNodeService(string nodeId)
        {
            NodeId = nodeId;
            CacheStorage = new Dictionary<string, string>();
        }

        public void Put(string Key, string value)
        {
            CacheStorage[Key] = value;
            Console.WriteLine($"[Node {NodeId}] Cached: {Key} -> {value}");
        }

        public string? Get(string key)
        {
            if (CacheStorage.TryGetValue(key, out var value))
            {
                Console.WriteLine($"[Node {NodeId}] Cache HIT for key: {key}");
                return value;
            }
            else
            {
                Console.WriteLine($"[Node {NodeId}] Cache MISS for key: {key}");
                return null;
            }
        }

        public void ShowContent()
        {
            Console.WriteLine($"\n[Node {NodeId}] Cached Contents:");
            foreach (var kvp in CacheStorage)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
            Console.WriteLine();
        }
    }
}