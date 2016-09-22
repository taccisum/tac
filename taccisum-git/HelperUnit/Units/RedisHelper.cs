using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Common.Global;
using ServiceStack.Redis;

namespace Common.Tool.Units
{

    public static class RedisHelper
    {
        public static IRedisClient GetClient()
        {
            return new ServicesStackRedis();
        }


        private class ServicesStackRedis : IRedisClient
        {
            private RedisClient client;

            public ServicesStackRedis()
            {
                //建立线程内唯一的连接，减少不必要的资源开销
                var temp = CallContext.GetData(GlobalConfig.DataSink.REDIS_CLIENT) as RedisClient;
                if (temp == null)
                {
                    temp = new RedisClient(ConfigHelper.GetAppSettings("Redis"),int.Parse(ConfigHelper.GetAppSettings("RedisPort")));
                    CallContext.SetData(GlobalConfig.DataSink.REDIS_CLIENT, temp);
                }
                client = temp;
            }


            public int GetInt(string key)
            {
                return client.Get<int>(key);
            }

            public string GetString(string key)
            {
                return client.Get<string>(key);
            }

            public void Lpop(string key)
            {
                throw new NotImplementedException();
            }

            public void Rpop(string key)
            {
                throw new NotImplementedException();
            }

            public List<string> Lrange(string key, int start, int stop)
            {
                return client.Lists[key].GetRange(start, stop);
            }

            public void Lpush(string key, string value)
            {
                throw new NotImplementedException();
            }

            public void Rpush(string key, string value)
            {
                client.Lists[key].Push(value);
            }
        }
    }

    public interface IRedisClient
    {
        #region Get

        int GetInt(string key);
        string GetString(string key);

        void Lpop(string key);
        void Rpop(string key);
        List<string> Lrange(string key, int start, int stop);
        #endregion

        #region Set
        void Lpush(string key, string value);
        void Rpush(string key, string value);

        #endregion
    }

    


}
