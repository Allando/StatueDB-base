using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Windows.UI.Popups;
using StatueApp.Exeption;
using StatueApp.Interface;

namespace StatueApp.Facade
{
    public class facadeStatue
    {
        private const string ServerUrl = "http://statuedatabasewepapi.azurewebsites.net"; // HTTP URL of Server
        //private const string ServerUrl = "http://localhost:55000"; // HTTP URL of Server
        private const string ApiBaseUrl = "/api/"; // Base Directory of the Api (Remember Leading and Trailing "/")

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
                        return listOfObjects;
                    }
                    throw new ServerErrorExeption("Kunne ikke finde: " + obj.VerboseName + response.ReasonPhrase);
                }
                catch (Exception ex)
                {
                    throw new ServerErrorExeption(ex.Message);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<T> GetAsync<T>(T obj, int id) where T : IWebUri, new()
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
                        return result;
                    }
                    throw new ServerErrorExeption("Kunne ikke finde: " + obj.VerboseName + response.ReasonPhrase );
                }
                catch (Exception ex)
                {
                    throw new ServerErrorExeption(ex.Message);
                }
                
               
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="statueId"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> GetByStatueIdAsync<T>(T obj, int statueId) where T : IWebUri, IGetByStatueId, new()
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
                    var response = await client.GetAsync(ApiBaseUrl + obj.ResourceUri + "/ByStatueId/" + statueId);
                    if (response.IsSuccessStatusCode)
                    {
                        listOfObjects = response.Content.ReadAsAsync<IEnumerable<T>>().Result;
                        return listOfObjects;
                    }
                    throw new ServerErrorExeption("Kunne ikke finde: " + obj.VerboseName + response.ReasonPhrase);
                }
                catch (Exception ex)
                {
                    throw new ServerErrorExeption(ex.Message);
                }
                
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static async Task<string> PostAsync<T>(T obj) where T : IWebUri
        {
            var handler = new HttpClientHandler { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = await client.PostAsJsonAsync(ApiBaseUrl + obj.ResourceUri, obj);
                    if (response.IsSuccessStatusCode)
                    {
                        return "Success: " + obj.VerboseName + " Created";
                    }
                    throw new ServerErrorExeption("Error: Failed to create " + obj.VerboseName + " :: " + response.StatusCode);
                }
                catch (Exception ex)
                {
                    throw new ServerErrorExeption(ex.Message);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="id"></param>
        /// <returns></returns>
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
                        return "Success: " + obj.VerboseName + " Updated";
                    }
                    throw new ServerErrorExeption("Error: Failed to update " + obj.VerboseName + " :: " + response.StatusCode);
                }
                catch (Exception ex)
                {
                    throw new ServerErrorExeption(ex.Message);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="id"></param>
        /// <returns></returns>
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
                        return "Success: " + obj.VerboseName + " Deleted";
                    }
                    throw new ServerErrorExeption("Error: Failed to delete " + obj.VerboseName + " :: " + response.StatusCode);
                }
                catch (Exception ex)
                {
                    throw new ServerErrorExeption(ex.Message);
                }
            }
        }
    }
}