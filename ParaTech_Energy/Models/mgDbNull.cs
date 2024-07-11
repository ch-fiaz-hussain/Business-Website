using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ParaTech_Energy.Models
{
    public class mgDbNull
    {
        public static bool boolIsnull(DataRow row, string Coloumn)
        {
            try
            {
                string Value = row[Coloumn].ToString();
                if (Value != null && Value != "")
                {
                    return Convert.ToBoolean(Value);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}