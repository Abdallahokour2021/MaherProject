﻿using DataLayer.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataLayer.DbContext
{
    public class MainDbContextFactory: IEfContextFactory
    {
        private readonly IMySqlDbContextOptionsFactory _options;
        private ILoggerFactory _loggerFactory;
        private readonly ILogger<IEfContextFactory> _log;
        private readonly IConfiguration _config;

        private static bool isinited = false;
        private static object dblock = new object();

        #region Ctor 
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="loggerFactory"></param>
        /// <param name="options"></param>
        /// <param name="config"></param>
        public MainDbContextFactory(ILoggerFactory loggerFactory, IMySqlDbContextOptionsFactory options, IConfiguration config)
        {
            _loggerFactory = loggerFactory;
            _log = _loggerFactory.CreateLogger<IEfContextFactory>();
            _config = config;
            isinited = false;

            //options.OptionsBuilder.UseMySql(_config.GetConnectionString("WebTebMySqlConnection"));
            options.OptionsBuilder.UseLoggerFactory(_loggerFactory);
            options.OptionsBuilder.EnableSensitiveDataLogging();
            options.OptionsBuilder.ConfigureWarnings(t => t.Default(WarningBehavior.Log));
            _options = options;
        }
        #endregion

        public MainDbContext Create()
        {
            return new MainDbContext(_options);
        }


        public MySqlConnection CreateMySqlConnection()
        {
            var connectionString = _config.GetConnectionString("WebTebMySqlConnection");
            MySqlConnection conn;

            conn = new MySqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            return conn;
        }
    }
}
