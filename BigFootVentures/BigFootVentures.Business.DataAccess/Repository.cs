﻿using BigFootVentures.Business.DataAccess.Mapping;
using BigFootVentures.Business.Objects;
using BigFootVentures.Business.Objects.Wrapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BigFootVentures.Business.DataAccess
{
    public interface IRepository<TEntity> where TEntity : BusinessBase
    {
        #region "Factory Methods"

        ICollection<TEntity> Get(int startIndex, int rowCount, out int total);       

        TEntity Get(int ID);

        ICollection<TEntity> GetForEmailNotification(int week);

        ICollection<AutocompleteWrapper> GetAutocomplete(string keyword);

        #endregion

        #region "Persistence"

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(int ID);

        #endregion
    }

    public sealed class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : BusinessBase
    {
        #region "Private Members"

        private readonly MySqlConnection _connection = null;
        private readonly IMapper _mapper = null;
        private readonly IEmailNotificationMapper _mapperEmailNotification = null;
        private readonly string _entityName = null;

        #endregion

        #region "Constructors"

        public Repository(string connectionString, IMapper mapper)
        {
            this._connection = new MySqlConnection(connectionString);
            this._mapper = mapper;            
            this._entityName = typeof(TEntity).Name;
        }

        public Repository(string connectionString, IEmailNotificationMapper mapperEmailNotification)
        {
            this._connection = new MySqlConnection(connectionString);
            this._mapperEmailNotification = mapperEmailNotification;
            this._entityName = typeof(TEntity).Name;
        }

        #endregion

        #region "Factory Methods"

        public ICollection<TEntity> Get(int startIndex, int rowCount, out int total)
        {
            try
            {
                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                var entities = new List<TEntity>();

                using (var command = new MySqlCommand($"{this._entityName}_Get", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new MySqlParameter("startIndex", MySqlDbType.Int32) { Value = startIndex, Direction = ParameterDirection.Input });
                    command.Parameters.Add(new MySqlParameter("rowCount", MySqlDbType.Int32) { Value = rowCount, Direction = ParameterDirection.Input });
                    command.Parameters.Add(new MySqlParameter("total", MySqlDbType.Int32) { Direction = ParameterDirection.Output });

                    var dataReader = command.ExecuteReader();

                    foreach (var entity in this._mapper.ParseDataMin(dataReader))
                    {
                        entities.Add((TEntity)entity);
                    }

                    dataReader.Close();

                    total = (int)command.Parameters["total"].Value;
                }

                return entities;
            }
            catch
            {
                throw;
            }
            finally
            {
                this._connection.Close();
            }
        }

        public TEntity Get(int ID)
        {
            try
            {
                TEntity entity = null;

                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                using (var command = new MySqlCommand($"{this._entityName}_GetByID", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new MySqlParameter("ID", MySqlDbType.Int32) { Value = ID, Direction = ParameterDirection.Input });

                    var dataReader = command.ExecuteReader();
                    var obj = this._mapper.ParseData(dataReader).SingleOrDefault();

                    if (obj != null)
                        entity = (TEntity)obj;

                    dataReader.Close();
                }

                return entity;
            }
            catch
            {
                throw;
            }
            finally
            {
                this._connection.Close();
            }
        }

        public ICollection<TEntity> GetForEmailNotification(int week)
        {
            try
            {
                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                var entities = new List<TEntity>();

                using (var command = new MySqlCommand($"{this._entityName}_GetForEmailNotification", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new MySqlParameter("week", MySqlDbType.Int32) { Value = week, Direction = ParameterDirection.Input });

                    var dataReader = command.ExecuteReader();

                    foreach (var entity in this._mapperEmailNotification.ParseData(dataReader))
                    {
                        entities.Add((TEntity)entity);
                    }

                    dataReader.Close();
                }

                return entities;
            }
            catch
            {
                throw;
            }
            finally
            {
                this._connection.Close();
            }
        }

        public ICollection<AutocompleteWrapper> GetAutocomplete(string keyword)
        {
            try
            {
                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                var entities = new List<AutocompleteWrapper>();

                using (var command = new MySqlCommand($"{this._entityName}_GetAutocomplete", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new MySqlParameter("keyword", MySqlDbType.VarChar, 100) { Value = keyword, Direction = ParameterDirection.Input });

                    var dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        entities.Add(new AutocompleteWrapper
                        {
                            Text = dataReader["TEXT"] as string,
                            Value = Convert.ToInt32(dataReader["VALUE"])
                        });
                    }

                    dataReader.Close();
                }

                return entities;
            }
            catch
            {
                throw;
            }
            finally
            {
                this._connection.Close();
            }
        }

        #endregion

        #region "Persistence"

        public void Insert(TEntity entity)
        {
            try
            {
                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                using (var command = new MySqlCommand($"{this._entityName}_Insert", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.AddRange(this._mapper.CreateParameters(entity));

                    entity.ID = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                this._connection.Close();
            }
        }

        public void Update(TEntity entity)
        {
            try
            {
                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                using (var command = new MySqlCommand($"{this._entityName}_Update", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new MySqlParameter("pID", MySqlDbType.Int32) { Value = entity.ID, Direction = ParameterDirection.Input });
                    command.Parameters.AddRange(this._mapper.CreateParameters(entity));

                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                this._connection.Close();
            }
        }

        public void Delete(int ID)
        {
            try
            {
                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                using (var command = new MySqlCommand($"{this._entityName}_Delete", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new MySqlParameter("pID", MySqlDbType.Int32) { Value = ID, Direction = ParameterDirection.Input });

                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                this._connection.Close();
            }
        }

        #endregion

        #region "Public Methods"

        public void Dispose()
        {
            this._connection.Dispose();
        }

        #endregion
    }
}
