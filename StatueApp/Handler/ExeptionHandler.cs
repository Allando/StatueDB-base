using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using StatueApp.Exeption;
using StatueApp.Facade;
using StatueApp.Interface;
using StatueApp.Model;

namespace StatueApp.Handler
{
    public class ExeptionHandler
    {
        /// <summary>
        /// Denne metode viser en text box med en valgt fejl
        /// </summary>
        /// <param name="message"></param>
        public static async void ShowExeptonError(string message)
        {
            string msg = message;
            var messageBox = new MessageDialog(msg);
            await messageBox.ShowAsync();
        }

        /// <summary>
        /// Denne metode viser en text box med en valgt fejl + den pågældende besked
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ExeptionMessage"></param>
        public static async void ShowExeptonError(string message, string ExeptionMessage)
        {
            string msg = message + ": " + ExeptionMessage;
            var messageBox = new MessageDialog(msg);
            await messageBox.ShowAsync();
        }

        #region DeleteMethod
        /// <summary>
        /// Denne metode sletter et object ud fra et Statue Id. virker kun på model__List objecter(ex modelPlaceList)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="statueId"></param>
        /// <param name="obj"></param>
        public static async void DeleteCleanUpMethod<T>(int statueId, T obj) where T : IHasFkStatuecs, IWebUri, new()
        {
            try
            {
                IEnumerable<T> ListToDelete = facadeStatue.GetListAsync(new T()).Result;
                foreach (var item in ListToDelete)
                {
                    if (item.FK_Statue == statueId)
                    {
                        await facadeStatue.DeleteAsync(new modelCulturalValueList(), item.Id);
                    }
                }
            }
            catch (Exception)
            {
                throw new CreateStatueDeleteFailExeption("fejl i oprettelse af statue, nogle statue information ikke gemt");
            }
        }

        /// <summary>
        /// Denne metode sletter objecter ud fra statue Id. Virker kun på objecter der ikke er model__List objecter(ex modelStatue)
        /// </summary>
        /// <param name="statueId"></param>
        /// <param name="s"></param>
        public static async void DeleteNotListCleanUpMethod<T>(int statueId, T obj) where T : IWebUri, new()
        {
            try
            {
                await facadeStatue.DeleteAsync(new T(), statueId);
            }
            catch (Exception)
            {
                throw new CreateStatueDeleteFailExeption("fejl i oprettelse af statue, nogle statue information ikke gemt");
            }
        }
        #endregion

    }
}
