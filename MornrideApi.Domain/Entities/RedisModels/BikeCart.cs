using MornrideApi.Domain.Entities.Model;
using Redis.OM.Modeling;
using System.Collections.ObjectModel;

namespace MornrideApi.Domain.Entities.RedisModels
{
    [Document(StorageType = StorageType.Json, Prefixes = new[] { "BikeCart" })]
    public class BikeCart
    {
        [RedisIdField]
        [Indexed]
        public int Id { get; set; }
        [Indexed]
        public string Title { get; set; } = string.Empty;
        [Indexed]
        public int Amount { get; set; }
        [Indexed]
        public float Price { get; set; }
        [Indexed]
        public string[] AvaliableColors { get; set; } = new string[] { };

    }
}
