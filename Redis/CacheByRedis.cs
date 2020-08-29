using Redis.CacheBase;
using System;

namespace Redis
{
    public class CacheByRedis : ICache
    {
        #region Key-Value
        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        /// <returns></returns>
        public T Read<T>(string cacheKey, long dbId = 0) where T : class
        {
            return RedisCache.Get<T>(cacheKey, dbId);
        }
        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <param name="value">对象数据</param>
        /// <param name="cacheKey">键</param>
        public void Write<T>(string cacheKey, T value, long dbId = 0) where T : class
        {
            RedisCache.Set(cacheKey, value, dbId);
        }
        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <param name="value">对象数据</param>
        /// <param name="cacheKey">键</param>
        /// <param name="expireTime">到期时间</param>
        public void Write<T>(string cacheKey, T value, DateTime expireTime, long dbId = 0) where T : class
        {
            RedisCache.Set(cacheKey, value, expireTime, dbId);
        }
        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <param name="value">对象数据</param>
        /// <param name="cacheKey">键</param>
        /// <param name="TimeSpan">缓存时间</param>
        public void Write<T>(string cacheKey, T value, TimeSpan timeSpan, long dbId = 0) where T : class
        {
            RedisCache.Set(cacheKey, value, timeSpan, dbId);
        }
        /// <summary>
        /// 移除指定数据缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        public void Remove(string cacheKey, long dbId = 0)
        {
            RedisCache.Remove(cacheKey, dbId);
        }
        /// <summary>
        /// 移除全部缓存
        /// </summary>
        public void RemoveAll(long dbId = 0)
        {
            RedisCache.RemoveAll(dbId);
        }
        #endregion


        #region 
        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        /// <returns></returns>
        public T ReadHash<T>(string key, string dataKey, long dbId = 0) where T : class
        {
            return RedisCache.Hash_Get<T>(key, dataKey, dbId);
        }

        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <param name="value">对象数据</param>
        /// <param name="cacheKey">键</param>
        /// <param name="TimeSpan">缓存时间</param>
        public void WriteHash<T>(string Key, string dataKey, T value, long dbId = 0) where T : class
        {
            RedisCache.Hash_Set(Key, dataKey, value, dbId);
        }
        /// <summary>
        /// 移除指定数据缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        public void RemoveHash(string Key, string dataKey, long dbId = 0)
        {
            RedisCache.Hash_Remove(Key, dataKey, dbId);
        }
        /// <summary>
        /// 移除缓存
        /// </summary>
        public void RemoveHash(string Key, long dbId = 0)
        {
            RedisCache.Hash_Remove(Key, dbId);
        }
        #endregion 
    }
}
