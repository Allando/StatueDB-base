using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Newtonsoft.Json;

namespace StatueApp.SampleCode
{
    /// <summary>
    /// 
    /// WORK IN PROGRESS
    /// 
    /// ////////////////
    /// 
    /// Do NOT Implement
    /// 
    /// </summary>

    internal class Facade
    {
        private const string ServerUrl = "http://localhost:55000/";
//        private static IEnumerable<object> ObjEnum { get; set; }

        public static async Task<IEnumerable<object>> GetItemsAsync(object obj)
        {
            IEnumerable<object> objEnum = null;
            var handler = new HttpClientHandler { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    string asyncString = String.Format("api/{0}", obj.GetType().ToString());
                    var response = await client.GetAsync(asyncString);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        objEnum = JsonConvert.DeserializeObject<IEnumerable<object>>(result);
                    }
                }
                catch (Exception ex)
                {
                    var msgDialog = new MessageDialog(ex.Message, "Runtime Error");
                    await msgDialog.ShowAsync();
                }
                return objEnum;
            }
        }

        public static async Task<object> GetItemAsync(object obj, int id)
        {
            object objSingle = null;
            var handler = new HttpClientHandler { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    string asyncString = String.Format("api/{0}/{1}", obj.GetType().ToString(), id.ToString());
                    var response = await client.GetAsync(asyncString);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        var listOfItems = JsonConvert.DeserializeObject<List<object>>(result);
                        foreach (var item in listOfItems)
                        {
                            objSingle = item.Id == id ? item : null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    var msgDialog = new MessageDialog(ex.Message, "Runtime Error");
                    await msgDialog.ShowAsync();
                }
                return objSingle;
            }
        }

        //public static async Task<string> PostGuestAsync(object obj)
        //{
        //    object objSinle = obj;
        //    var handler = new HttpClientHandler {UseDefaultCredentials = true};
        //    using (var client = new HttpClient(handler))
        //    {
        //        client.BaseAddress = new Uri(ServerUrl);
        //        client.DefaultRequestHeaders.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        try
        //        {
        //            string asyncString = String.Format("api/{0}/{1}", objSingle.GetType().ToString());
        //            var response = await client.PostAsJsonAsync(asyncString, objSingle);
        //            if (response.IsSuccessStatusCode)
        //            {
        //                return "Guest Created";
        //            }
        //            return "Error Creating Guest: " + response.StatusCode;
        //        }
        //        catch (Exception ex)
        //        {
        //            var msgDialog = new MessageDialog(ex.Message, "Runtime Error");
        //            await msgDialog.ShowAsync();
        //            throw;
        //        }
        //    }
        //}

        //public static async Task<string> PutGuestAsync(Guest guest, int id)
        //{
        //    Guest = guest;
        //    var handler = new HttpClientHandler {UseDefaultCredentials = true};
        //    using (var client = new HttpClient(handler))
        //    {
        //        client.BaseAddress = new Uri(ServerUrl);
        //        client.DefaultRequestHeaders.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        try
        //        {
        //            var response = await client.PutAsJsonAsync("api/guests/" + id, Guest);
        //            if (response.IsSuccessStatusCode)
        //            {
        //                return "Guest Updated";
        //            }
        //            return "Error Updating Guest: " + response.StatusCode;
        //        }
        //        catch (Exception ex)
        //        {
        //            var msgDialog = new MessageDialog(ex.Message, "Runtime Error");
        //            await msgDialog.ShowAsync();
        //            throw;
        //        }
        //    }
        //}

        //public static async Task<string> DeleteGuestAsync(Guest guest)
        //{
        //    Guest = guest;
        //    var handler = new HttpClientHandler {UseDefaultCredentials = true};
        //    using (var client = new HttpClient(handler))
        //    {
        //        client.BaseAddress = new Uri(ServerUrl);
        //        client.DefaultRequestHeaders.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        try
        //        {
        //            var response = await client.DeleteAsync("api/guests/" + Guest.Guest_No);
        //            if (response.IsSuccessStatusCode)
        //            {
        //                return "Guest Deleted";
        //            }
        //            return "Error Deleting Guest: " + response.StatusCode;
        //        }
        //        catch (Exception ex)
        //        {
        //            var msgDialog = new MessageDialog(ex.Message, "Runtime Error");
        //            await msgDialog.ShowAsync();
        //            throw;
        //        }
        //    }
        //}
    }
}