﻿using EasyMicroservices.Logger.Interfaces;
using System;

namespace EasyMicroservices.Logger.Options
{
    /// <summary>
    /// 
    /// </summary>
    public static class LoggerOptionBuilder
    {
        private static Func<ILoggerProviderAsync> _loggerFunc;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="func"></param>
        public static void UseLogger(Func<ILoggerProviderAsync> func)
        {
            if (_loggerFunc != null)
                throw new Exception("You set UseLogger once.");
            _loggerFunc = func;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static ILoggerProviderAsync GetLogger()
        {
            if (_loggerFunc == null)
                throw new Exception("You did not set UseLogger.");
            return _loggerFunc();
        }
    }
}