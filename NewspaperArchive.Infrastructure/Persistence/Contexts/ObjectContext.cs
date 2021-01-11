using Microsoft.EntityFrameworkCore;
using NewspaperArchive.Application.Services;
using NewspaperArchive.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NewspaperArchive.Infrastructure.Persistence.Contexts
{
    public class ObjectContext : DbContext, IDbContext
    {
        private readonly string _connectionString;
        public ObjectContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetInterfaces()
             .Any(gi => gi.IsGenericType && gi.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))).ToList();

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }
        protected virtual TEntity AttachEntityToContext<TEntity>(TEntity entity) where TEntity : BaseEntity, new()
        {
            if (entity.Id > 0)
            {
                var alreadyAttached = Set<TEntity>().Local.FirstOrDefault(x => x.Id == entity.Id);
                if (alreadyAttached == null)
                {
                    //attach new entity
                    Set<TEntity>().Attach(entity);
                    return entity;
                }
                else
                {
                    //entity is already loaded.
                    return alreadyAttached;
                }
            }
            else
            {
                return entity;
            }
        }
        public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }
        public IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity : BaseEntity, new()
        {
            var connection = this.Database.GetDbConnection();

            //open the connection for use
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            //create a command object
            using (var cmd = connection.CreateCommand())
            {
                //command to execute
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 1000;

                // move parameters to command object
                if (parameters != null)
                    foreach (var p in parameters)
                    {
                        if (p != null)
                            cmd.Parameters.Add(p);
                    }

                IList<TEntity> result;
                //database call
                using (var reader = cmd.ExecuteReader())
                {
                    result = reader.Translate<TEntity>().ToList();
                    for (int i = 0; i < result.Count; i++)
                        result[i] = AttachEntityToContext(result[i]);
                }
                //close connection finally if open.(DS)
                if (connection.State == ConnectionState.Open) { connection.Close(); }
                return result;
            }
        }
        public TEntity ExecuteStoredProcedure<TEntity>(string commandText, params object[] parameters) where TEntity : BaseEntity, new()
        {
            var connection = this.Database.GetDbConnection();

            //open the connection for use
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            //create a command object
            using (var cmd = connection.CreateCommand())
            {
                //command to execute
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 1000;

                // move parameters to command object
                if (parameters != null)
                    foreach (var p in parameters)
                    {
                        if (p != null)
                            cmd.Parameters.Add(p);
                    }

                TEntity result;
                //database call
                using (var reader = cmd.ExecuteReader())
                {
                    result = reader.TranslateMulti<TEntity>();
                }
                //close connection finally if open.(DS)
                if (connection.State == ConnectionState.Open) { connection.Close(); }
                return result;
            }
        }
        /// <summary>
        /// Execute the stored procedure for non entity list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IList<T> ExecuteStoredProcedureListNonEntity<T>(string commandText, params object[] parameters) where T : class, new()
        {
            var connection = this.Database.GetDbConnection();

            //open the connection for use
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            //create a command object
            using (var cmd = connection.CreateCommand())
            {
                //command to execute
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 1000;

                // move parameters to command object
                if (parameters != null)
                    foreach (var p in parameters)
                    {
                        if (p != null)
                            cmd.Parameters.Add(p);
                    }

                IList<T> result;
                //database call
                using (var reader = cmd.ExecuteReader())
                {
                    result = reader.Translate<T>().ToList();
                }
                //close connection finally if open.(DS)
                if (connection.State == ConnectionState.Open) { connection.Close(); }
                return result;
            }
        }
        public T ExecuteStoredProcedureNonEntity<T>(string commandText, params object[] parameters) where T : class, new()
        {
            var connection = this.Database.GetDbConnection();

            //open the connection for use
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            //create a command object
            using (var cmd = connection.CreateCommand())
            {
                //command to execute
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 1000;

                // move parameters to command object
                if (parameters != null)
                    foreach (var p in parameters)
                    {
                        if (p != null)
                            cmd.Parameters.Add(p);
                    }

                T result;
                //database call
                using (var reader = cmd.ExecuteReader())
                {
                    result = reader.TranslateMulti<T>();
                }
                //close connection finally if open.(DS)
                if (connection.State == ConnectionState.Open) { connection.Close(); }
                return result;
            }
        }

        public T ExecuteStoredProcedureSingleNonEntity<T>(string commandText, params object[] parameters) where T : class, new()
        {
            var connection = this.Database.GetDbConnection();

            //open the connection for use
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            //create a command object
            using (var cmd = connection.CreateCommand())
            {
                //command to execute
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 1000;

                // move parameters to command object
                if (parameters != null)
                    foreach (var p in parameters)
                    {
                        if (p != null)
                            cmd.Parameters.Add(p);
                    }

                T result;
                //database call
                using (var reader = cmd.ExecuteReader())
                {
                    result = reader.TranslateSingle<T>();
                }
                //close connection finally if open.(DS)
                if (connection.State == ConnectionState.Open) { connection.Close(); }
                return result;
            }
        }
        public int ExecuteStoredProcedureNonQuery(string commandText, params object[] parameters)
        {
            var connection = this.Database.GetDbConnection();
            //Don't close the connection after command execution

            //open the connection for use
            if (connection.State == ConnectionState.Closed)
                connection.Open();

            //create a command object
            using (var cmd = connection.CreateCommand())
            {
                //command to execute
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                // move parameters to command object
                if (parameters != null)
                    foreach (var p in parameters)
                    {
                        if (p != null)
                            cmd.Parameters.Add(p);
                    }

                var rowseffected = cmd.ExecuteNonQuery();
                //close connection finally if open.(DS)
                if (connection.State == ConnectionState.Open) { connection.Close(); }
                return rowseffected;
            }
        }

        public IList<T> ExecuteStoredProcedureSingleList<T>(string commandText, params object[] parameters) where T : new()
        {
            IList<T> entity;
            var connection = this.Database.GetDbConnection();
            //Don't close the connection after command execution

            //open the connection for use
            if (connection.State == ConnectionState.Closed) { connection.Open(); }

            //create a command object
            using (var cmd = connection.CreateCommand())
            {
                //command to execute
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 1000;

                if (parameters != null)
                {
                    // move parameters to command object
                    foreach (var p in parameters)
                    {
                        if (p != null)
                        {
                            cmd.Parameters.Add(p);
                        }
                    }
                }
                using (var reader = cmd.ExecuteReader())
                {
                    entity = reader.Translate<T>();
                }
                //close connection finally if open.(DS)
                if (connection.State == ConnectionState.Open) { connection.Close(); }

            }
            return entity;
        }
        public TEntity ExecuteStoredProcedureMultipleList<TEntity>(string commandText, params object[] parameters) where TEntity : new()
        {
            var entity = new TEntity();
            var connection = this.Database.GetDbConnection();
            //Don't close the connection after command execution

            //open the connection for use
            if (connection.State == ConnectionState.Closed) { connection.Open(); }

            //create a command object
            using (var cmd = connection.CreateCommand())
            {
                //command to execute
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 1000;

                if (parameters != null)
                {
                    // move parameters to command object
                    foreach (var p in parameters)
                    {
                        if (p != null)
                        {
                            cmd.Parameters.Add(p);
                        }
                    }
                }
                using (var reader = cmd.ExecuteReader())
                {
                    entity = reader.TranslateMulti<TEntity>();
                }
                //close connection finally if open.(DS)
                if (connection.State == ConnectionState.Open) { connection.Close(); }

            }
            return entity;
        }
        /// <summary>
        /// Execute Stored Procedure List with Output parameters
        /// </summary>
        /// <typeparam name="TEntity">TEntity</typeparam>
        /// <param name="commandText">Command Text or store procedure name</param>
        /// <param name="totalOutputParams">Total number of Output parameters</param>
        /// <param name="outputs">out object[] outputs</param>
        /// <param name="parameters">params object[] parameters</param>
        /// <returns>IList TEntity</returns>
        public IList<T> ExecuteStoredProcedureListNonEntityWithOutput<T>(string commandText, int totalOutputParams, out object[] output, params object[] parameters) where T : class, new()
        {

            if (totalOutputParams == 0)
            {
                totalOutputParams = 1;
            }

            var connection = this.Database.GetDbConnection();
            //Don't close the connection after command execution

            //open the connection for use
            if (connection.State == ConnectionState.Closed) { connection.Open(); }

            //create a command object
            using (var cmd = connection.CreateCommand())
            {
                //command to execute
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 1000;

                bool hasOutputParameters = false;
                DbParameter[] OutputParam = new DbParameter[totalOutputParams];
                if (parameters != null)
                {
                    int i = 0;
                    // move parameters to command object
                    foreach (var p in parameters)
                    {
                        if (p != null)
                        {
                            cmd.Parameters.Add(p);
                            var outputP = p as DbParameter;
                            if (outputP == null) { continue; }

                            if (outputP.Direction == ParameterDirection.InputOutput || outputP.Direction == ParameterDirection.Output)
                            {
                                hasOutputParameters = true; OutputParam[i] = outputP;
                                i++;
                            }
                        }
                    }
                }

                IList<T> result;
                using (var reader = cmd.ExecuteReader())
                {
                    result = reader.Translate<T>().ToList();
                    reader.NextResult();
                    output = new object[totalOutputParams]; output[0] = 0;
                    if (hasOutputParameters)
                    {
                        //Access output variable
                        for (int res = 0; res < totalOutputParams; res++) { output[res] = (OutputParam[res].Value == null) ? 0 : OutputParam[res].Value; }
                    }
                }
                return result;
            }
        }
        public IList<T> ExecuteStoredProcedureListWithOutput<T>(string commandText, int totalOutputParams, out object[] output, params object[] parameters) where T : BaseEntity, new()
        {

            if (totalOutputParams == 0)
            {
                totalOutputParams = 1;
            }

            var connection = this.Database.GetDbConnection();
            //Don't close the connection after command execution

            //open the connection for use
            if (connection.State == ConnectionState.Closed) { connection.Open(); }

            //create a command object
            using (var cmd = connection.CreateCommand())
            {
                //command to execute
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 1000;

                bool hasOutputParameters = false;
                DbParameter[] OutputParam = new DbParameter[totalOutputParams];
                if (parameters != null)
                {
                    int i = 0;
                    // move parameters to command object
                    foreach (var p in parameters)
                    {
                        if (p != null)
                        {
                            cmd.Parameters.Add(p);
                            var outputP = p as DbParameter;
                            if (outputP == null) { continue; }

                            if (outputP.Direction == ParameterDirection.InputOutput || outputP.Direction == ParameterDirection.Output)
                            {
                                hasOutputParameters = true; OutputParam[i] = outputP;
                                i++;
                            }
                        }
                    }
                }

                IList<T> result;
                using (var reader = cmd.ExecuteReader())
                {
                    result = reader.Translate<T>().ToList();
                    reader.NextResult();
                    output = new object[totalOutputParams]; output[0] = 0;
                    if (hasOutputParameters)
                    {
                        //Access output variable
                        for (int res = 0; res < totalOutputParams; res++) { output[res] = (OutputParam[res].Value == null) ? 0 : OutputParam[res].Value; }
                    }
                }
                return result;
            }
        }
        /// <summary>
        /// Execute Stored Procedure Non Query with Output parameters
        /// </summary>
        /// <param name="commandText">Command Text or store procedure name</param>
        /// <param name="totalOutputParams">Total number of Output parameters</param>
        /// <param name="outputs">out object[] outputs</param>
        /// <param name="parameters">params object[] parameters</param>
        /// <returns>Integer value</returns>
        public int ExecuteStoredProcedureNonQueryWithOutput(string commandText, int totalOutputParams, out object[] outputs, params object[] parameters)
        {

            if (totalOutputParams == 0)
            {
                totalOutputParams = 1;
            }
            var connection = this.Database.GetDbConnection();
            //Don't close the connection after command execution

            //open the connection for use
            if (connection.State == ConnectionState.Closed)
                connection.Open();

            //create a command object
            using (var cmd = connection.CreateCommand())
            {
                //command to execute
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                bool hasOutputParameters = false;
                DbParameter[] OutputParam = new DbParameter[totalOutputParams];
                if (parameters != null)
                {
                    int i = 0;
                    // move parameters to command object
                    foreach (var p in parameters)
                    {
                        if (p != null)
                        {
                            cmd.Parameters.Add(p);
                            var outputP = p as DbParameter;
                            if (outputP == null) { continue; }

                            if (outputP.Direction == ParameterDirection.InputOutput || outputP.Direction == ParameterDirection.Output)
                            { hasOutputParameters = true; OutputParam[i] = outputP; i++; }
                        }
                    }
                }

                var rowseffected = cmd.ExecuteNonQuery();
                outputs = new object[totalOutputParams]; outputs[0] = 0;
                if (hasOutputParameters)
                {
                    //Access output variable
                    for (int res = 0; res < totalOutputParams; res++) { outputs[res] = (OutputParam[res].Value == null) ? 0 : OutputParam[res].Value; }
                }

                return rowseffected;
            }
        }

    }
}
