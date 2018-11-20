using System.Collections.Generic;
using BigFootVentures.Business.Objects.Management;
using MySql.Data.MySqlClient;

namespace BigFootVentures.Business.DataAccess.Mapping.EmailNotification
{
    public sealed class LegalCaseMapper : IEmailNotificationMapper
    {
        #region "Factory Methods"

        public ICollection<object> ParseData(MySqlDataReader dataReader)
        {
            var entities = new List<object>();

            while (dataReader.Read())
            {
                var entity = new LegalCase
                {
                    ID = (int)dataReader["ID"],
                    
                    TrademarkNumber = dataReader["TrademarkNumber"] as string,
                    DateAssigned = dataReader["DateAssigned"] as string
                };

                if (int.TryParse((dataReader["TrademarkID"] as int?)?.ToString(), out int trademarkID))
                {
                    entity.Trademark = new Trademark
                    {
                        ID = trademarkID,
                        Name = dataReader["TrademarkName"] as string
                    };
                }

                entities.Add(entity);
            }

            return entities;
        }

        #endregion
    }
}
