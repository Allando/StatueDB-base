using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using StatueApp.Common;
using StatueApp.Exeption;
using StatueApp.Facade;
using StatueApp.Model;

namespace StatueApp.Handler
{
    public class handlerStatue
    {
        /// <summary>
        /// Finder den nyeste generede statue, ved at finde den statue med det højeste Id
        /// </summary>
        /// <returns>Højeste Statue Id (int)</returns>
        private static async Task<int> GetHighestStatueId()
        {
            try
            {
                var statueList = await facadeStatue.GetListAsync(new modelStatue());

                //int max = 0;
                //foreach (var item in statueList)
                //    max = Math.Max(max, item.Id);
                //return max;
                // Løber listen af statuer igennem og finder og retunerer det højeste Id (Sidst tilføjede statue)

                // Gør det samme som ovenstående Loop
                return statueList.Select(item => item.Id).Concat(new[] {0}).Max();
            }
            catch (ServerErrorExeption ex)
            {
                throw ex;
            }
            catch (NullReferenceException)
            {
                ExeptionHandler.ShowExeptonError("Statuen ikke gemt");
            }
            catch (Exception ex)
            {
                ExeptionHandler.ShowExeptonError("Ukendt fejl: ", ex.Message);
            }
            return -1;
        }

        /// <summary>
        /// Denne metode tager statue og de nødvendige mellem tabler og gemmer dem i databasen
        /// </summary>
        /// <returns>returnere besked fra webserice - statusMsg </returns>
        public static async Task<string> CreateStatue()
        {
            var statusMsg="";
           
            try
            {
                var NewStatue = StatueSingleton.Instance;
                NewStatue.Statue.Created = DateTime.Now;
                NewStatue.Statue.Updated = DateTime.Now;
                statusMsg = await facadeStatue.PostAsync(NewStatue.Statue);
                //Kalder denne metode for at finde Id'et på den nyeste Statue
                var statueId = await GetHighestStatueId();

                //Alle posting loops, tager Id'et fra den nyeste statue + Id'et fra de valgte properties og skriver ind i mellem tablerne
                #region Posting Loops
                try
                {
                    foreach (var culturalValue in NewStatue.CulturalValues)
                    {
                        await facadeStatue.PostAsync(new modelCulturalValueList(statueId, culturalValue.Id));
                    }
                }
                //I catach metoderne slettes alle de ting der er blevet oprettet ind til fejlen skete
                catch (Exception ex)
                {
                    ExeptionHandler.DeleteNotListCleanUpMethod(statueId, new modelStatue());
                    throw ex;
                }
                
                //Starter ny foreach loop
                try
                {
                    foreach (var material in NewStatue.Materials)
                    {
                        await facadeStatue.PostAsync(new modelMaterialList(statueId, material.Id));
                    }
                }
                catch (Exception ex)
                {
                    ExeptionHandler.DeleteNotListCleanUpMethod(statueId, new modelStatue());
                    ExeptionHandler.DeleteCleanUpMethod(statueId, new modelCulturalValueList());
                    throw ex;
                }

                //Starter ny foreach loop
                try
                {
                    foreach (var placement in NewStatue.Placements)
                    {
                        await facadeStatue.PostAsync(new modelPlacementList(statueId, placement.Id));
                    }
                }
                catch (Exception ex)
                {
                    ExeptionHandler.DeleteNotListCleanUpMethod(statueId, new modelStatue());
                    ExeptionHandler.DeleteCleanUpMethod(statueId, new modelCulturalValueList());
                    ExeptionHandler.DeleteCleanUpMethod(statueId, new modelMaterialList());
                    throw ex;
                }

                //Starter ny foreach loop
                try
                {
                    foreach (var statueType in NewStatue.StatueTypes)
                    {
                        await facadeStatue.PostAsync(new modelStatueTypeList(statueId, statueType.Id));
                    }
                }
                catch (Exception ex)
                {
                    ExeptionHandler.DeleteNotListCleanUpMethod(statueId, new modelStatue());
                    ExeptionHandler.DeleteCleanUpMethod(statueId, new modelCulturalValueList());
                    ExeptionHandler.DeleteCleanUpMethod(statueId, new modelMaterialList());
                    ExeptionHandler.DeleteCleanUpMethod(statueId, new modelPlacementList());
                    throw ex;
                }

                //Starter ny foreach loop
                try
                {
                    if (NewStatue.Description != null)
                    {
                        await facadeStatue.PostAsync(NewStatue.Description);
                    }
                }
                catch (Exception ex)
                {
                    ExeptionHandler.DeleteNotListCleanUpMethod(statueId, new modelStatue());
                    ExeptionHandler.DeleteCleanUpMethod(statueId, new modelCulturalValueList());
                    ExeptionHandler.DeleteCleanUpMethod(statueId, new modelMaterialList());
                    ExeptionHandler.DeleteCleanUpMethod(statueId, new modelPlacementList());
                    ExeptionHandler.DeleteCleanUpMethod(statueId, new modelStatueTypeList());
                    throw ex;
                }

                //
                try
                {
                    if (NewStatue.GpsLocation != null)
                    {
                        await facadeStatue.PostAsync(NewStatue.GpsLocation);
                    }
                }
                catch (Exception ex)
                {
                    ExeptionHandler.DeleteNotListCleanUpMethod(statueId, new modelStatue());
                    ExeptionHandler.DeleteCleanUpMethod(statueId, new modelCulturalValueList());
                    ExeptionHandler.DeleteCleanUpMethod(statueId, new modelMaterialList());
                    ExeptionHandler.DeleteCleanUpMethod(statueId, new modelPlacementList());
                    ExeptionHandler.DeleteCleanUpMethod(statueId, new modelStatueTypeList());
                    if (NewStatue.Description != null)
                    {
                        ExeptionHandler.DeleteNotListCleanUpMethod(statueId, new modelDescription());
                    }
                    throw ex;
                }
                //
                #endregion
            }
           
            catch (Exception ex)
            {
                throw ex;
            }
            //NewStatue.Dispose();
            return statusMsg;
        }
    }
}