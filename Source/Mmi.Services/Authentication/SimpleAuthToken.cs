using Microsoft.AspNetCore.Authentication;
using System.Numerics;

namespace Mmi.Services.Authentication
{
    public class SimpleAuthToken
    {
        public uint UserId { get; }

        public SimpleAuthToken(uint userId)
        {
            UserId = userId;
        }

        public override string ToString()
        {
            return Convert.ToBase64String(BitConverter.GetBytes(UserId));
        }

        /// <summary>
        /// Оываыва
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static SimpleAuthToken FromString(string str)
        {
            byte[] fromBase64 = Convert.FromBase64String(str);
            return new(BitConverter.ToUInt32(fromBase64));
        }
    }
}
