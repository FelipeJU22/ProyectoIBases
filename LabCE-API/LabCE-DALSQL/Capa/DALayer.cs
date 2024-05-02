using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCE_DALSQL.Capa
{
    public static class DALayer
    {
        #region IntMethods
        public static int getSafeInt(object value)
        {
            int result = 0;
            if (value != null && value != System.DBNull.Value)
                result = Convert.ToInt32(value);

            return result;
        }

        public static int? getNullableInt(object value)
        {
            int? result = null;
            if (value != null && value != System.DBNull.Value)
                result = (int?)value;

            return result;
        }

        public static int? setNullableInt(int value)
        {
            int? result = null;
            if (value != 0)
                result = value;

            return result;
        }
        #endregion

        #region ShortMethods
        public static short getSafeShort(object value)
        {
            short result = 0;
            if (value != null && value != System.DBNull.Value)
                //result = (short)value;
                result = Convert.ToInt16(value);

            return result;
        }
        public static short? getNullableShort(object value)
        {
            short? result = null;
            if (value != null && value != System.DBNull.Value)
                result = (short?)value;
            return result;
        }
        #endregion

        #region ByteMethods
        public static byte getSafeByte(object value)
        {
            byte result = 0;
            if (value != null && value != System.DBNull.Value)
                result = Convert.ToByte(value);

            return result;
        }
        public static byte? getNullableByte(object value)
        {
            byte? result = null;
            if (value != null && value != System.DBNull.Value)
                result = (byte?)value;
            return result;
        }
        #endregion

        #region StringMethods
        public static string getSafeString(object value)
        {
            string result = string.Empty;
            if (value != null && value != System.DBNull.Value)
                result = value.ToString();
            return result;
        }

        public static string getNullableString(object value)
        {
            string result = null;
            if (value != null && value != System.DBNull.Value)
                result = (string)value;
            return result;
        }
        #endregion

        #region FloatMethods
        public static float getSafeFloat(object value)
        {
            float result = 0;
            if (value != null && value != System.DBNull.Value)
                //result = (float)value;
                result = float.Parse(value.ToString());
            return result;
        }
        public static float? getNullableFloat(object value)
        {
            float? result = null;
            if (value != null && value != System.DBNull.Value)
                result = (float?)value;
            return result;
        }
        #endregion

        #region DecimalMethods
        public static decimal getSafeDecimal(object value)
        {
            decimal result = new Decimal(0);
            if (value != null && value != System.DBNull.Value)
                result = (decimal)value;
            return result;
        }

        public static decimal? getNullableDecimal(object value)
        {
            decimal? result = null;
            if (value != null && value != System.DBNull.Value)
                result = (decimal?)value;
            return result;
        }
        #endregion

        #region LongMethods
        public static long getSafeLong(object value)
        {
            long result = 0;
            if (value != null && value != System.DBNull.Value)
                //result = (float)value;
                result = long.Parse(value.ToString());
            return result;
        }
        #endregion

        #region DateTimeMethods
        public static DateTime getSafeDateTime(object value)
        {
            DateTime result = new DateTime();
            if (value != null && value != System.DBNull.Value)
                result = (DateTime)value;
            return result;
        }
        public static DateTime? getNullableDateTime(object value)
        {
            DateTime? result = null;
            if (value != null && value != System.DBNull.Value)
                result = (DateTime?)value;
            return result;
        }

        public static DateTime getSafeTime(object value)
        {
            DateTime result = new DateTime();
            if (value != null && value != System.DBNull.Value)
                result = DateTime.Parse(value.ToString());
            return result;
        }

        public static DateTime? getNullableTime(object value)
        {
            DateTime? result = null;
            if (value != null && value != System.DBNull.Value)
            {

                result = DateTime.Parse(value.ToString());

            }
            return result;
        }
        #endregion

        #region BoolMethods
        public static bool getSafeBool(object value)
        {
            bool result = false;
            if (value != null && value != System.DBNull.Value)
                result = Convert.ToBoolean(value);
            return result;
        }
        public static bool? getNullableBool(object value)
        {
            bool? result = null;
            if (value != null && value != System.DBNull.Value)
                result = (bool?)value;
            return result;
        }
        #endregion
    }
}

