﻿using System.Data;
using System.Data.SQLite;

namespace Universal.Data
{
    /// <summary>
    /// Clase especializada en obtención y manipulación de datos de SQL Server
    /// </summary>
    internal class UniversalSql : DbDataAccess
    {
        /// <summary>
        /// Carga dinamicamente los parametros al objeto comando que se utilizará para ejecutar
        /// </summary>
        /// <param name="command"></param>
        /// <param name="args"></param>
        protected override void CargarParametros(IDbCommand command, params IDbDataParameter[] args)
        {
            command.Parameters.Clear();
            foreach (SQLiteParameter param in args)
                command.Parameters.Add(param);
        }

        /// <summary>
        /// Prepara el Objeto Command especializa para la Base de Datos
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        protected override IDbCommand Comando(string sqlCommand, CommandType commandType)
        {
            return new SQLiteCommand(sqlCommand)
            {
                CommandType = commandType,
                Connection = (SQLiteConnection)Conexion
            };
        }

        /// <summary>
        /// Prepara el Objeto Command especializa para la Base de Datos, recibiendo el objeto de transaccion.
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="sqlCommand"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        protected override IDbCommand Comando(IDbTransaction transaction, string sqlCommand, CommandType commandType)
        {
            return new SQLiteCommand(sqlCommand)
            {
                CommandType = commandType,
                Connection = (SQLiteConnection)transaction.Connection,
                Transaction = (SQLiteTransaction) transaction
            };
        }

        /// <summary>
        /// Se devuelve una nueva instancia del 
        /// objeto Conexión de SqlClient, utilizando la cadena de conexión del objeto.
        /// </summary>
        /// <param name="connectionString">Cadena de Conexión para conectarse a la base de datos</param>
        /// <returns></returns>
        protected override IDbConnection CrearConexion(string connectionString)
        { return new SQLiteConnection(connectionString); }

        /// <summary>
        /// Aprovecha el método Comando para crear el comando necesario.
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="commandType"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        protected override IDataAdapter CrearDataAdapter(string sqlCommand,
            CommandType commandType, params IDbDataParameter[] args)
        {
            var da = new SQLiteDataAdapter((SQLiteCommand)Comando(sqlCommand, commandType));
            if (args.Length != 0)
                CargarParametros(da.SelectCommand, args);
            return da;
        }

        /// <summary>
        /// Aprovecha el método Comando para crear el comando necesario, recibiendo el objeto de transaccion
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="sqlCommand"></param>
        /// <param name="commandType"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        protected override IDataAdapter CrearDataAdapter(IDbTransaction transaction, string sqlCommand,
            CommandType commandType, params IDbDataParameter[] args)
        {
            var da = new SQLiteDataAdapter(((SQLiteCommand)Comando(transaction, sqlCommand, commandType)));
            if (args.Length != 0)
                CargarParametros(da.SelectCommand, args);
            return da;
        }

        /// <summary>
        /// Constructor que recibe los datos de conexion separados
        /// </summary>
        /// <param name="connectionString">Cadena de Conexión para conectarse a la base de datos</param>
        public UniversalSql(string connectionString)
        { CadenaConexion = connectionString; }

        /// <summary>
        /// Constructor vacío
        /// </summary>
        public UniversalSql()
        {
            Conexion = null;
        }
    }
}
