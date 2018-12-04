using BigFootVentures.Business.Objects.Wrapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BigFootVentures.Business.DataAccess
{
    public interface ISearchDataAccess
    {
        #region "Factory Methods"

        ICollection<SearchResultWrapper> Search(string keyword);

        #endregion
    }

    public sealed class SearchDataAccess : ISearchDataAccess, IDisposable
    {
        #region "Private Members"

        private readonly MySqlConnection _connection = null;

        #endregion

        #region "Constructors"

        public SearchDataAccess(string connectionString)
        {
            this._connection = new MySqlConnection(connectionString);
        }

        #endregion

        #region "Factory Methods"

        public ICollection<SearchResultWrapper> Search(string keyword)
        {
            try
            {
                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                var searchResultList = this.CreateSearchResultBase();

                using (var command = new MySqlCommand("Search_Object", this._connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.Add(new MySqlParameter("keyword", MySqlDbType.VarChar, 50) { Value = keyword, Direction = ParameterDirection.Input });

                    var dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        var searchResult = searchResultList.FirstOrDefault(i => string.Equals(i.Caption, dataReader["Caption"] as string, StringComparison.InvariantCultureIgnoreCase));

                        if (searchResult != null)
                        {
                            searchResult.Rows.Add(new List<string>
                            {
                                Convert.ToInt32(dataReader["ID"]).ToString(),
                                dataReader["COL1"] as string,
                                dataReader["COL2"] as string
                            });
                        }
                    }

                    dataReader.Close();
                }

                return searchResultList;
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

        #region "Private Methods"

        private ICollection<SearchResultWrapper> CreateSearchResultBase()
        {
            var searchResultList = new List<SearchResultWrapper>();

            searchResultList.Add(new SearchResultWrapper { Caption = "Agreement", Header = new List<string> { "Agreement Name", "Type" }, Rows = new List<List<string>>() });
            searchResultList.Add(new SearchResultWrapper { Caption = "Brand", Header = new List<string> { "Brand Name", "Value" }, Rows = new List<List<string>>() });
            searchResultList.Add(new SearchResultWrapper { Caption = "Cancellation", Header = new List<string> { "Reference Internal", "Reference External" }, Rows = new List<List<string>>() });
            searchResultList.Add(new SearchResultWrapper { Caption = "Company", Header = new List<string> { "Name", "Account Record Type" }, Rows = new List<List<string>>() });
            searchResultList.Add(new SearchResultWrapper { Caption = "Contact", Header = new List<string> { "Name", "Department" }, Rows = new List<List<string>>() });
            searchResultList.Add(new SearchResultWrapper { Caption = "Domain", Header = new List<string> { "Domain Name", "BigFoot Owned" }, Rows = new List<List<string>>() });
            searchResultList.Add(new SearchResultWrapper { Caption = "Enquiry", Header = new List<string> { "Old Case Number", "Reference Number" }, Rows = new List<List<string>>() });
            searchResultList.Add(new SearchResultWrapper { Caption = "Lead", Header = new List<string> { "Name", "Company" }, Rows = new List<List<string>>() });
            searchResultList.Add(new SearchResultWrapper { Caption = "LegalCase", Header = new List<string> { "Type of Case", "Trademark Number" }, Rows = new List<List<string>>() });
            searchResultList.Add(new SearchResultWrapper { Caption = "Office", Header = new List<string> { "Office Name", string.Empty }, Rows = new List<List<string>>() });
            searchResultList.Add(new SearchResultWrapper { Caption = "Register", Header = new List<string> { "Register Name", "Country" }, Rows = new List<List<string>>() });
            searchResultList.Add(new SearchResultWrapper { Caption = "Trademark", Header = new List<string> { "Trademark Name", string.Empty }, Rows = new List<List<string>>() });

            return searchResultList;
        }

        #endregion
    }
}
