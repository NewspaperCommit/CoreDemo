using Microsoft.EntityFrameworkCore;
using NewspaperArchive.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewspaperArchive.Application.Services
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;

        /// <summary>
        /// Execute procedure for the entity list.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters)
            where TEntity : BaseEntity, new();
        /// <summary>
        /// Execute procedure for the entity.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        TEntity ExecuteStoredProcedure<TEntity>(string commandText, params object[] parameters)
            where TEntity : BaseEntity, new();
        /// <summary>
        /// Execute the stored procedure with list which are not entity driven.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IList<T> ExecuteStoredProcedureListNonEntity<T>(string commandText, params object[] parameters)
           where T : class, new();
        /// <summary>
        /// Execute stored procdure without listing.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        T ExecuteStoredProcedureNonEntity<T>(string commandText, params object[] parameters)
            where T : class, new();
        /// <summary>
        /// Execute procedure for single class.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        T ExecuteStoredProcedureSingleNonEntity<T>(string commandText, params object[] parameters)
            where T : class, new();
        /// <summary>
        /// Excute procedure Non Query.
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        int ExecuteStoredProcedureNonQuery(string commandText, params object[] parameters);

        //IList<T> ExecuteStoredProcedureSingleList<T>(string commandText, params object[] parameters);
        //T ExecuteStoredProcedureMultipleList<T>(string commandText, params object[] parameters);

        /// <summary>
        /// Execute procedure non entity with output parameter.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandText"></param>
        /// <param name="totalOutputParams"></param>
        /// <param name="output"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IList<T> ExecuteStoredProcedureListNonEntityWithOutput<T>(string commandText, int totalOutputParams, out object[] output, params object[] parameters) where T : class, new();
        /// <summary>
        /// Execute procedure with entity  with output parameters.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandText"></param>
        /// <param name="totalOutputParams"></param>
        /// <param name="output"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IList<T> ExecuteStoredProcedureListWithOutput<T>(string commandText, int totalOutputParams, out object[] output, params object[] parameters) where T : BaseEntity, new();
        /// <summary>
        /// Excute the non query stored procedure  with output parameters
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="totalOutputParams"></param>
        /// <param name="outputs"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        int ExecuteStoredProcedureNonQueryWithOutput(string commandText, int totalOutputParams, out object[] outputs, params object[] parameters);
    }
}
