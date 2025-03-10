﻿using StackExchange.Redis;

namespace MultiShop.Basket.Settings
{
    public class RedisService
    {
        private string _host;
        private int _port;

        private ConnectionMultiplexer _multiplexer;

        public RedisService(string host, int port)
        {
            _host = host;
            _port = port;
        }

        public void Connect() => _multiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");

        public IDatabase GetDb(int db = 1) => _multiplexer.GetDatabase(0); 

    }
}
