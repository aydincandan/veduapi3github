using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SehirRehberi.API.Controllers
{
    public class _ControllersHelper
    {
        public static JArray notfound(dynamic info)
        {
            JArray notfoundReturn = new JArray();
            notfoundReturn.Add(JObject.Parse("{'notfound':'" + info + "'}"));

            return notfoundReturn;
        }

        public static JArray fixarray(dynamic dataToReturn)
        {
            JArray ArraydataToReturn = new JArray();
            ArraydataToReturn.Add(JObject.FromObject(dataToReturn));

            return ArraydataToReturn;
        }


	
		static void SetPropValue(object container, string propertyName, object value)
        {
            var propertyInfo = container.GetType().GetProperty(propertyName);
            propertyInfo.SetValue(container, Convert.ChangeType(value, propertyInfo.PropertyType), null);
        }
        // https://ahmetkakici.github.io/programlama/c-sharp-reflection
        public static object GetPropValue(object container, string propertyName)
        {
            return container.GetType().GetProperty(propertyName).GetValue(container, null);
        }

		public static void PrepareUpdate(Type container, dynamic eski, dynamic yeni)
        {
            System.Reflection.PropertyInfo[] props = container.GetProperties();

            foreach (System.Reflection.PropertyInfo prop in props)
            {
                var propCustAttributes = prop.CustomAttributes;
                var KeysCount = propCustAttributes.Where(g => g.AttributeType.Name == "KeyAttribute").Count();

                if (KeysCount == 0) // [Key] atlanıyor (olmayanlar update ediliyo)
                {
                    object newVal = _ControllersHelper.GetPropValue(yeni, prop.Name);

                    if (newVal != null) // yeni değer null ise eski değere Set edilmiyor :-)
                    {
                        _ControllersHelper.SetPropValue(eski, prop.Name, newVal);
                    }
                }
            }
        }



        public static bool VerifyPasswordHash(string password, byte[] userPasswordHash, byte[] userPasswordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(userPasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != userPasswordHash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public static string GetUsernameFromEmail(string Email)
        {
            int ATpos = Email.IndexOf('@');
            if (ATpos == -1)
                return Email;
            else
                return Email.Substring(0, ATpos);
        }

		public static class MemberInfoGetting
		{
			public static string GetMemberName<T>(Expression<Func<T>> memberExpression)
			{
				MemberExpression expressionBody = (MemberExpression)memberExpression.Body;
				return expressionBody.Member.Name;
			}
		}

	}
}
