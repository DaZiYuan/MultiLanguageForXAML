﻿using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace MultiLanguageForXAML
{
    public class LanService
    {
        static IDataBase _db;
        static string _currentCulture;
        static bool _canHotUpdate;
        static string _defaultLan;

        public static bool CanHotUpdate { get => _canHotUpdate; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="db">数据库</param>
        /// <param name="hotUpdate">是否支持热更新，true会有一定性能开销</param>
        public static void Init(IDataBase db, bool hotUpdate = false, string defaultLan = null)
        {
            _defaultLan = defaultLan;
            _canHotUpdate = hotUpdate;
            _db = db;
            _currentCulture = GetCultureName();
        }

        /// <summary>
        /// 修改Culture后重新调用，刷新
        /// </summary>
        public static async Task UpdateLanguage()
        {
            if (!CanHotUpdate)
                return;

            _currentCulture = GetCultureName();
            await Xaml.UpdateLanguage();
        }

        public static Task<string> Get(string key)
        {
            return Get(key, _currentCulture);
        }

        public static async Task<string> Get(string key, string cultureName)
        {
            if (_db == null)
                throw new NullReferenceException("Language database has not been initialized");
            string r = null;
            try
            {
                r = await _db.Get(key, cultureName);
                if (!string.IsNullOrEmpty(r))
                    return r;
            }
            catch (Exception)
            {
            }

            //出现异常或者没有多语言，使用默认语言
            r = await _db.Get(key, _defaultLan);
            return r;
        }

        private static string GetCultureName()
        {
            string result = null;
            result = Thread.CurrentThread.CurrentUICulture.Name;
            return result;
        }
    }
}
