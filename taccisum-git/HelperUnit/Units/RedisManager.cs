using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Redis;

namespace Common.Tool.Units
{

    public static class RedisManager
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
                //todo 避免反复建立连接，应考虑做到线程内共用一个连接
                client = new RedisClient(ConfigHelper.GetAppSettings("Redis"),
                    int.Parse(ConfigHelper.GetAppSettings("RedisPort")));
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
