using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Newtonsoft.Json;
using StatueApp.Interface;

namespace StatueApp.SampleCode
{
    /// <summary>
    /// 
    /// WORK IN PROGRESS
    /// 
    /// </summary>

    public class Facade
    {
        private const string ServerUrl = "http://localhost:55000";  // HTTP URL of Server
        private const string ApiBaseUrl = "/api/";                  // Base Directory of the Api

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns>Enumerable List of T</returns>
        public static async Task<IEnumerable<T>> GetListAsync<T>(T obj) where T : IWebUri 
        {
            IEnumerable<T> listOfObjects = null;
            var handler = new HttpClientHandler { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = await client.GetAsync(ApiBaseUrl + obj.ResourceUri);
                    if (response.IsSuccessStatusCode)
                    {
                        listOfObjects = response.Content.ReadAsAsync<IEnumerable<T>>().Result;
                    }
                }
                catch (Exception ex)
                {
                    var msgDialog = new MessageDialog(ex.Message, "Runtime Error");
                    await msgDialog.ShowAsync();
                }
                return listOfObjects;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<T> GetAsync<T>(int id) where T : IWebUri, new()
        {
            T result = new T();
            var handler = new HttpClientHandler { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = await client.GetAsync(ApiBaseUrl + result.ResourceUri + "/" + id);
                    if (response.IsSuccessStatusCode)
                    {
                        result = response.Content.ReadAsAsync<T>().Result;
                    }
                }
                catch (Exception ex)
                {
                    var msgDialog = new MessageDialog(ex.Message, "Runtime Error");
                    await msgDialog.ShowAsync();
                }
                return result;
            }
        }

        public static async Task<string> PostAsync<T>(T obj) where T : IWebUri
        {
            T objSingle = obj;
            var handler = new HttpClientHandler { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = await client.PostAsJsonAsync(ApiBaseUrl + obj.ResourceUri, objSingle);
                    if (response.IsSuccessStatusCode)
                    {
                        return obj.ResourceUri + " Created";
                    }
                    return "Error Creating "+ obj.ResourceUri + ": " + response.StatusCode;
                }
                catch (Exception ex)
                {
                    var msgDialog = new MessageDialog(ex.Message, "Runtime Error");
                    await msgDialog.ShowAsync();
                    throw;
                }
            }
        }

        public static async Task<string> PutAsync<T>(T obj, int id) where T : IWebUri
        {
            var handler = new HttpClientHandler { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = await client.PutAsJsonAsync(ApiBaseUrl + obj.ResourceUri + "/" + id, obj);
                    if (response.IsSuccessStatusCode)
                    {
                        return obj.ResourceUri + " Updated";
                    }
                    return "Error Updating " + obj.ResourceUri + ": " + response.StatusCode;
                }
                catch (Exception ex)
                {
                    var msgDialog = new MessageDialog(ex.Message, "Runtime Error");
                    await msgDialog.ShowAsync();
                    throw;
                }
            }
        }

        public static async Task<string> DeleteAsync<T>(T obj, int id) where T : IWebUri
        {
            var handler = new HttpClientHandler { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = await client.DeleteAsync(ApiBaseUrl + obj.ResourceUri + "/" + id);
                    if (response.IsSuccessStatusCode)
                    {
                        return obj.ResourceUri + " Deleted";
                    }
                    return "Error Deleting " + obj.ResourceUri + ": " + response.StatusCode;
                }
                catch (Exception ex)
                {
                    var msgDialog = new MessageDialog(ex.Message, "Runtime Error");
                    await msgDialog.ShowAsync();
                    throw;
                }
            }
        }
    }
}