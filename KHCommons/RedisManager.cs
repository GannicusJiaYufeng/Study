using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHCommons
{
    public class RedisManager
    {
        public static PooledRedisClientManager ClientManager { get; private set; }
        static RedisManager()
        {
            RedisClientManagerConfig redisConfig = new RedisClientManagerConfig();
            redisConfig.MaxWritePoolSize = 128;
            redisConfig.MaxReadPoolSize = 128;
            //读写分离。多台Redis组成集群
            ClientManager = new PooledRedisClientManager(new string[] { "127.0.0.1" },
                new string[] { "127.0.0.1" }, redisConfig);
        }
    }
}
