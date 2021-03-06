﻿using System;

namespace BigFootVentures.Business.DataAccess.Utilities
{
    public static class DataUtils
    {
        #region "Public Methods"

        public static string EscapeCSV(string data)
        {
            if (data.Contains("\r"))
            {
                data = data.Replace("\r", string.Empty);
            }

            if (data.Contains("\n"))
            {
                data = data.Replace("\n", string.Empty);
            }

            if (data.Contains("\""))
            {
                data = data.Replace("\"", "\"\"");
            }

            if (data.Contains(","))
            {
                data = String.Format("\"{0}\"", data);
            }

            if (data.Contains(Environment.NewLine))
            {
                data = String.Format("\"{0}\"", data);
            }

            return data;
        }

        #endregion
    }
}
