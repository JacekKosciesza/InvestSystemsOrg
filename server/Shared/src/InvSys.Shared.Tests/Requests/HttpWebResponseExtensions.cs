using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace InvSys.Shared.Tests.Requests
{
    public static class HttpWebResponseExtensions
    {
        public static async Task<string> GetStreamContent(this HttpWebResponse httpWebResponse)
        {
            using (var stream = httpWebResponse.GetResponseStream())
            {
                if (stream == null)
                {
                    throw new ArgumentNullException(nameof(stream));
                }

                using (var reader = new StreamReader(stream))
                {
                    return await reader.ReadToEndAsync();
                }
            }
        }
    }
}
