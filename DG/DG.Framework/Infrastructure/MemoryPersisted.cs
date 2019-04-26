
using DG.Framework.Data.Contract;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DG
{
    public static class MemoryPersisted
    {
        private static Dictionary<int, Dictionary<string, object>> _memoryObjects = new Dictionary<int, Dictionary<string, object>>();

        private static int GetUserID()
        {
            int userid = 0;
            try
            {
                userid = SPContext.Current.Web.CurrentUser.ID;
            }
            catch { }
            return userid;
        }

        public static void Add(string key, object value)
        {
            Add(GetUserID(), key, value);
        }

        public static void Add(int userId, string key, object value)
        {
            InitUserData(userId);

            if (!_memoryObjects[userId].ContainsKey(key))
                _memoryObjects[userId].Add(key, value);
        }

        public static T Get<T>(string key)
        {
            return Get<T>(GetUserID(), key);
        }

        public static T Get<T>(int userId, string key)
        {
            InitUserData(userId);

            if (!_memoryObjects[userId].ContainsKey(key))
                return default(T);

            return (T)_memoryObjects[userId][key];
        }

        public static bool Contains(string key)
        {
            return Contains(GetUserID(), key);
        }

        public static bool Contains(int userId, string key)
        {
            InitUserData(userId);

            return _memoryObjects[userId].ContainsKey(key);
        }

        public static void Set(string key, object value)
        {
            Set(GetUserID(), key, value);
        }

        public static void Set(int userId, string key, object value)
        {
            InitUserData(userId);

            if (!_memoryObjects[userId].ContainsKey(key))
                Add(key, value);
            else
                _memoryObjects[userId][key] = value;
        }

        public static void Remove(string key)
        {
            Remove(GetUserID(), key);
        }

        public static void Remove(int userId, string key)
        {
            InitUserData(userId);

            _memoryObjects[userId].Remove(key);
        }

        public static Dictionary<string, object> GetAll()
        {
            return GetAll(GetUserID());
        }

        public static Dictionary<string, object> GetAll(int userId)
        {
            InitUserData(userId);

            return _memoryObjects[userId];
        }

        private static void InitUserData(int userId)
        {
            if (!_memoryObjects.ContainsKey(userId))
                _memoryObjects.Add(GetUserID(), new Dictionary<string, object>());
        }

    }
}

