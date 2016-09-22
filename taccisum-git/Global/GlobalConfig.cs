namespace Common.Global
{
    public static class GlobalConfig
    {
        public const string AUTOLOGIN = "AUTOLOGIN";

        public const string CURRENT_USER = "CURRENT_USER";


        /// <summary>
        /// 数据槽对象key，可使用以下常量通过CallContext.GetData(key)获取当前线程内唯一的对象实例
        /// </summary>
        public static class DataSink
        {
            public const string EF_DB_CONTEXT = "EF_DB_CONTEXT";
            public const string REDIS_CLIENT = "REDIS_CLIENT";
        }

    }
}