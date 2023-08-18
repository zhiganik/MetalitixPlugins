using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Metalitix.Core.Tools;
using Newtonsoft.Json;

namespace Metalitix.Core.Web
{
    public static class WebRequestHelper
    {
        private const string AuthorizationHeader = "Authorization";
        private const string OriginHeader = "Origin";
        private const string LocalHost = "http://localhost";
        private const string JsonMediaType = "application/json";

        /// <summary>
        /// Get request without token to get data
        /// </summary>
        /// <param name="path"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> GetData<T>(string path, CancellationToken cancellationToken)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add(OriginHeader, LocalHost);
            var response = await client.GetAsync(path, cancellationToken);

            try
            {
                var data = await TryParseData<T>(response);
                return data;
            }
            catch (Exception e)
            {
                MetalitixDebug.Log(client, e.Message, true);
                throw;
            }
            finally
            {
                client.Dispose();
            }
        }

        /// <summary>
        /// Get request with token to get data
        /// </summary>
        /// <param name="path"></param>
        /// <param name="token"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> GetDataWithToken<T>(string path, string token, CancellationToken cancellationToken)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add(AuthorizationHeader, token);
            client.DefaultRequestHeaders.Add(OriginHeader, LocalHost);

            try
            {
                var response = await client.GetAsync(path, cancellationToken);
                var data = await TryParseData<T>(response);
                return data;
            }
            catch (Exception e)
            {
                MetalitixDebug.Log(client, e.Message, true);
                throw;
            }
            finally
            {
                client.Dispose();
            }
        }

        /// <summary>
        /// Patch data with token and string data. With output value
        /// </summary>
        /// <param name="path"></param>
        /// <param name="token"></param>
        /// <param name="jsonString"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> PatchData<T>(string path, string token, string jsonString, CancellationToken cancellationToken)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add(AuthorizationHeader, token);
            client.DefaultRequestHeaders.Add(OriginHeader, LocalHost);
            var content = new StringContent(jsonString, Encoding.UTF8, JsonMediaType);
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), path) { Content = content };

            try
            {
                var response = await client.SendAsync(request, cancellationToken);
                response.EnsureSuccessStatusCode();
                var data = await TryParseData<T>(response);
                return data;
            }
            catch (Exception e)
            {
                MetalitixDebug.Log(client, e.Message, true);
                throw;
            }
            finally
            {
                client.Dispose();
            }
        }

        /// <summary>
        /// Post string data async to http client. Without output value
        /// </summary>
        /// <param name="path"></param>
        /// <param name="jsonString"></param>
        /// <param name="cancellationToken"></param>
        public static async Task PostDataWithPlayLoad(string path, string jsonString, CancellationToken cancellationToken)
        {
            using var client = new HttpClient();
            var data = new StringContent(jsonString, Encoding.UTF8, JsonMediaType);
            client.DefaultRequestHeaders.Add(OriginHeader, LocalHost);

            try
            {
                var response = await client.PostAsync(path, data, cancellationToken);
                var result = await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                MetalitixDebug.Log(client, e.Message, true);
                throw;
            }
            finally
            {
                client.Dispose();
            }
        }

        /// <summary>
        /// Post string data async to http client. With output value
        /// </summary>
        /// <param name="path"></param>
        /// <param name="jsonString"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> PostDataWithPlayLoad<T>(string path, string jsonString, CancellationToken cancellationToken)
        {
            using var client = new HttpClient();
            var data = new StringContent(jsonString, Encoding.UTF8, JsonMediaType);
            client.DefaultRequestHeaders.Add(OriginHeader, LocalHost);

            try
            {
                var response = await client.PostAsync(path, data, cancellationToken);
                var resultData = await TryParseData<T>(response);
                return resultData;
            }
            catch (Exception e)
            {
                MetalitixDebug.Log(client, e.Message, true);
                throw;
            }
            finally
            {
                client.Dispose();
            }
        }

        private static async Task<T> TryParseData<T>(HttpResponseMessage response)
        {
            var result = await response.Content.ReadAsStringAsync();
            var value = JsonHelper.FromJson<T>(result, NullValueHandling.Ignore);

            if (value == null)
            {
                throw new HttpRequestException(result);
            }

            return value;
        }
    }
}