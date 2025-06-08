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
    }
}