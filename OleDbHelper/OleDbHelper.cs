﻿using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace Universal.Data
{
    /// <summary>
    /// Clase que permite crear conexion al motor de base de datos SQL Server
    /// </summary>
    public static class OleDbHelper
    {
        /// <summary>
        /// Obtiene un objeto DataSet cargados con datos de la Base de Datos en Uso
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandType"></param>
        /// <param name="comandoSql"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(string connectionString, CommandType commandType,
            string comandoSql, params OleDbParameter[] args)
        {
            var conexion = new UniversalSql(connectionString);
            return conexion.ExecuteDataSet(comandoSql, commandType, args);
        }

        /// <summary>
        /// Obtiene un objeto DataSet cargados con datos de la Base de Datos en Uso,
        /// recibiento el objeto de transaccion
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="commandType"></param>
        /// <param name="comandoSql"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(OleDbTransaction transaction, CommandType commandType,
            string comandoSql, params OleDbParameter[] args)
        {
            var conexion = new UniversalSql();
            return conexion.ExecuteDataSet(transaction, comandoSql, commandType, args);
        }

        /// <summary>
        /// Obtiene un objeto DataTable cargados con datos de la Base de Datos en Uso,
        /// recibiento el objeto de transaccion
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandType"></param>
        /// <param name="sqlCommand"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string connectionString, CommandType commandType,
            string sqlCommand, params OleDbParameter[] args)
        {
            var conexion = new UniversalSql(connectionString);
            return conexion.ExecuteDataSet(sqlCommand, commandType, args).Tables[0];
        }

        /// <summary>
        /// Obtiene un objeto DataTable cargados con datos de la Base de Datos en Uso,
        /// recibiento el objeto de transaccion
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="commandType"></param>
        /// <param name="sqlCommand"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(OleDbTransaction transaction, CommandType commandType,
            string sqlCommand, params OleDbParameter[] args)
        {
            var conexion = new UniversalSql();
            return conexion.ExecuteDataSet(transaction, sqlCommand, commandType, args).Tables[0];
        }

        /// <summary>
        /// Retorna un IDataReader listo para recorrerlo e implementarlo sobre cualquier proveedor,
        /// el mismo cierra y destruye la conexion una vez cerrado el DataReader
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandType"></param>
        /// <param name="sqlCommand"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static OleDbDataReader ExecuteReader(string connectionString, CommandType commandType,
            string sqlCommand, params OleDbParameter[] args)
        {
            var conexion = new UniversalSql(connectionString);
            return conexion.ExecuteReader(sqlCommand, commandType, args) as OleDbDataReader;
        }

        /// <summary>
        /// Retorna un IDataReader listo para recorrerlo e implementarlo sobre cualquier proveedor,
        /// recibiento el objeto de transaccion
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="commandType"></param>
        /// <param name="sqlCommand"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static OleDbDataReader ExecuteReader(OleDbTransaction transaction, CommandType commandType,
            string sqlCommand, params OleDbParameter[] args)
        {
            var conexion = new UniversalSql();
            return conexion.ExecuteReader(transaction, sqlCommand, commandType, args) as OleDbDataReader;
        }

        /// <summary>
        /// Retorna un valor escalar desde la base de dato, tipificado como Object
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandType"></param>
        /// <param name="sqlCommand"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static Object ExecuteScalar(string connectionString, CommandType commandType,
            string sqlCommand, params OleDbParameter[] args)
        {
            var conexion = new UniversalSql(connectionString);
            return conexion.ExecuteScalar(sqlCommand, commandType, args);
        }

        /// <summary>
        /// Retorna un valor escalar desde la base de dato, tipificado como Object,
        /// recibiento el objeto de transaccion
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="commandType"></param>
        /// <param name="sqlCommand"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static Object ExecuteScalar(OleDbTransaction transaction, CommandType commandType,
            string sqlCommand, params OleDbParameter[] args)
        {
            var conexion = new UniversalSql();
            return conexion.ExecuteScalar(transaction, sqlCommand, commandType, args);
        }

        /// <summary>
        /// Retorna un ArrayList, de una fila y con número de columnas variables desde la base de datos
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandType"></param>
        /// <param name="sqlCommand"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static ArrayList ExecuteOutputValue(string connectionString, CommandType commandType,
            string sqlCommand, params OleDbParameter[] args)
        {
            var conexion = new UniversalSql(connectionString);
            return conexion.ExecuteOutputValue(sqlCommand, commandType, args);
        }

        /// <summary>
        /// Retorna un ArrayList, de una fila y con número de columnas variables desde la base de datos,
        /// recibiento el objeto de transaccion
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="commandType"></param>
        /// <param name="sqlCommand"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static ArrayList ExecuteOutputValue(OleDbTransaction transaction, CommandType commandType,
            string sqlCommand, params OleDbParameter[] args)
        {
            var conexion = new UniversalSql();
            return conexion.ExecuteOutputValue(transaction, sqlCommand, commandType, args);
        }

        /// <summary>
        /// Ejecuta un comando SQL, devolviendo la cantidad de filas afectadas por la Query
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandType"></param>
        /// <param name="sqlCommand"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string connectionString, CommandType commandType,
            string sqlCommand, params OleDbParameter[] args)
        {
            var conexion = new UniversalSql(connectionString);
            return conexion.ExecuteNonQuery(sqlCommand, commandType, args);
        }

        /// <summary>
        /// Ejecuta un comando SQL, devolviendo la cantidad de filas afectadas por la Query,
        /// recibiento el objeto de transaccion
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="commandType"></param>
        /// <param name="sqlCommand"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(OleDbTransaction transaction, CommandType commandType,
            string sqlCommand, params OleDbParameter[] args)
        {
            var conexion = new UniversalSql();
            return conexion.ExecuteNonQuery(transaction, sqlCommand, commandType, args);
        }
    }
}
