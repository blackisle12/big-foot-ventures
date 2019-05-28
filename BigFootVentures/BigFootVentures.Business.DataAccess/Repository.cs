using BigFootVentures.Business.DataAccess.Mapping;
using BigFootVentures.Business.Objects;
using BigFootVentures.Business.Objects.Management;
using BigFootVentures.Business.Objects.Wrapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BigFootVentures.Business.DataAccess
{
    public interface IRepository<TEntity> where TEntity : BusinessBase
    {
        #region "Factory Methods"

        ICollection<TEntity> Get(int startIndex, int rowCount, out int total);

        ICollection<TEntity> Get(int startIndex, int rowCount, string sortBy, string sortOrder, out int total);

        ICollection<TEntity> GetByKeyword(string keyword, int startIndex, int rowCount, out int total);

        ICollection<TEntity> GetByKeyword(string keyword, int startIndex, int rowCount, string sortBy, string sortOrder, out int total);

        ICollection<TEntity> GetByQuery(string query, string queryTotal, out int total);

        StringBuilder ExportByKeyword(string keyword);

        StringBuilder ExportByQuery(string query);

        TEntity Get(int ID);

        TEntity GetLast();

        ICollection<TEntity> GetForEmailNotification(int week);

        ICollection<AutocompleteWrapper> GetAutocomplete(string keyword);

        ICollection<TEntity> GetByEmailAddress(string emailAddress);

        ICollection<TEntity> GetByUsername(string username);

        ICollection<TEntity> GetAssigned(int assignedToID, int startIndex, int rowCount, out int total);

        ICollection<TRelatedEntity> GetRelated<TRelatedEntity>(int objectID, IMapper mapper) where TRelatedEntity : BusinessBase;

        #endregion

        #region "Persistence"

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void UpdateUserAccount(UserAccount entity);

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

        public ICollection<TEntity> Get(int startIndex, int rowCount, string sortBy, string sortOrder, out int total)
        {
            try
            {
                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                var entities = new List<TEntity>();

                using (var command = new MySqlCommand($"{this._entityName}_GetWithOrder", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new MySqlParameter("startIndex", MySqlDbType.Int32) { Value = startIndex, Direction = ParameterDirection.Input });
                    command.Parameters.Add(new MySqlParameter("rowCount", MySqlDbType.Int32) { Value = rowCount, Direction = ParameterDirection.Input });
                    command.Parameters.Add(new MySqlParameter("sortBy", MySqlDbType.VarChar, 45) { Value = sortBy, Direction = ParameterDirection.Input });
                    command.Parameters.Add(new MySqlParameter("sortOrder", MySqlDbType.VarChar, 5) { Value = sortOrder, Direction = ParameterDirection.Input });
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

        public ICollection<TEntity> GetByKeyword(string keyword, int startIndex, int rowCount, out int total)
        {
            try
            {
                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                var entities = new List<TEntity>();

                using (var command = new MySqlCommand($"{this._entityName}_GetByKeyword", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new MySqlParameter("keyword", MySqlDbType.VarChar, 50) { Value = keyword, Direction = ParameterDirection.Input });
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

        public ICollection<TEntity> GetByKeyword(string keyword, int startIndex, int rowCount, string sortBy, string sortOrder, out int total)
        {
            try
            {
                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                var entities = new List<TEntity>();

                using (var command = new MySqlCommand($"{this._entityName}_GetByKeywordWithOrder", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new MySqlParameter("keyword", MySqlDbType.VarChar, 50) { Value = keyword, Direction = ParameterDirection.Input });
                    command.Parameters.Add(new MySqlParameter("startIndex", MySqlDbType.Int32) { Value = startIndex, Direction = ParameterDirection.Input });
                    command.Parameters.Add(new MySqlParameter("rowCount", MySqlDbType.Int32) { Value = rowCount, Direction = ParameterDirection.Input });
                    command.Parameters.Add(new MySqlParameter("sortBy", MySqlDbType.VarChar, 45) { Value = sortBy, Direction = ParameterDirection.Input });
                    command.Parameters.Add(new MySqlParameter("sortOrder", MySqlDbType.VarChar, 5) { Value = sortOrder, Direction = ParameterDirection.Input });
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

        public ICollection<TEntity> GetByQuery(string query, string queryTotal, out int total)
        {
            try
            {
                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                var entities = new List<TEntity>();

                using (var command = new MySqlCommand("Object_GetByQuery", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.CommandTimeout = 180;
                    command.Parameters.Add(new MySqlParameter("query1", MySqlDbType.Text) { Value = query, Direction = ParameterDirection.Input });
                    command.Parameters.Add(new MySqlParameter("query2", MySqlDbType.Text) { Value = queryTotal, Direction = ParameterDirection.Input });
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

        public StringBuilder ExportByKeyword(string keyword)
        {
            try
            {
                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                using (var command = new MySqlCommand($"{this._entityName}_ExportByKeyword", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new MySqlParameter("keyword", MySqlDbType.VarChar, 50) { Value = keyword, Direction = ParameterDirection.Input });

                    var dataReader = command.ExecuteReader();

                    return this._mapper.ExportData(dataReader);
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

        public StringBuilder ExportByQuery(string query)
        {
            try
            {
                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                using (var command = new MySqlCommand("Object_ExportByQuery", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new MySqlParameter("query1", MySqlDbType.Text) { Value = query, Direction = ParameterDirection.Input });

                    var dataReader = command.ExecuteReader();

                    return this._mapper.ExportData(dataReader);
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
                    var obj = this._mapper.ParseData(dataReader).FirstOrDefault();

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

        public TEntity GetLast()
        {
            try
            {
                TEntity entity = null;

                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                using (var command = new MySqlCommand($"{this._entityName}_GetLast", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    var dataReader = command.ExecuteReader();
                    var obj = this._mapper.ParseDataMin(dataReader).SingleOrDefault();

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
                            Text2 = dataReader.FieldCount == 3 ? dataReader["TEXT2"] as string : string.Empty,
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

        public ICollection<TEntity> GetByEmailAddress(string emailAddress)
        {
            try
            {
                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                var entities = new List<TEntity>();

                using (var command = new MySqlCommand($"{this._entityName}_GetByEmailAddress", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new MySqlParameter("pEmailAddress", MySqlDbType.VarChar, 100) { Value = emailAddress, Direction = ParameterDirection.Input });

                    var dataReader = command.ExecuteReader();

                    foreach (var entity in this._mapper.ParseData(dataReader))
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

        public ICollection<TEntity> GetByUsername(string username)
        {
            try
            {
                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                var entities = new List<TEntity>();

                using (var command = new MySqlCommand($"{this._entityName}_GetByUsername", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new MySqlParameter("pUsername", MySqlDbType.VarChar, 100) { Value = username, Direction = ParameterDirection.Input });

                    var dataReader = command.ExecuteReader();

                    foreach (var entity in this._mapper.ParseData(dataReader))
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

        public ICollection<TEntity> GetAssigned(int assignedToID, int startIndex, int rowCount, out int total)
        {
            try
            {
                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                var entities = new List<TEntity>();

                using (var command = new MySqlCommand($"{this._entityName}_GetAssigned", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new MySqlParameter("pAssignedToID", MySqlDbType.Int32) { Value = assignedToID, Direction = ParameterDirection.Input });
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

        public ICollection<TRelatedEntity> GetRelated<TRelatedEntity>(int objectID, IMapper mapper) where TRelatedEntity : BusinessBase 
        {
            try
            {
                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                var entities = new List<TRelatedEntity>();

                using (var command = new MySqlCommand($"{this._entityName}_GetRelated{typeof(TRelatedEntity).Name}", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new MySqlParameter("objectID", MySqlDbType.Int32) { Value = objectID, Direction = ParameterDirection.Input });

                    var dataReader = command.ExecuteReader();

                    foreach (var entity in mapper.ParseDataMin(dataReader))
                    {
                        entities.Add((TRelatedEntity)entity);
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

        public void UpdateUserAccount(UserAccount entity)
        {
            try
            {
                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                using (var command = new MySqlCommand("UserAccount_UpdateStatusAndPassword", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new MySqlParameter("pID", MySqlDbType.Int32) { Value = entity.ID, Direction = ParameterDirection.Input });
                    command.Parameters.Add(new MySqlParameter("pPassword", MySqlDbType.VarChar, 100) { Value = entity.Password, Direction = ParameterDirection.Input });
                    command.Parameters.Add(new MySqlParameter("pIsActive", entity.IsActive ? 1 : 0) { Direction = ParameterDirection.Input });

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
