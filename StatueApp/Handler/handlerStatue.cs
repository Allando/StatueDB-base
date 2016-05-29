using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StatueApp.Common;
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
            IEnumerable<modelStatue> statueList = null;
            try
            {
                statueList = await facadeStatue.GetListAsync(new modelStatue());
            }
            catch (Exception)
            {
                // ignored
            }

            // int max = -1;
            // foreach (var item in statueList)
            //    max = Math.Max(max, item.Id);
            // return max;
            // Løber listen af statuer igennem og finder og retunerer det højeste Id (Sidst tilføjede statue)

            // Gør det samme som ovenstående Loop
            return statueList.Select(item => item.Id).Concat(new[] { -1 }).Max();
        }

        /// <summary>
        /// Denne metode tager statue og de nødvendige mellem tabler og gemmer dem i databasen
        /// </summary>
        /// <returns>returnere besked fra webserice - statusMsg </returns>
        public static async Task<string> CreateStatue()
        {
            string statusMsg;
            int statueId;
            var NewStatue = StatueSingleton.Instance;
            NewStatue.Statue.Created = DateTime.Now;
            NewStatue.Statue.Updated = DateTime.Now;

            try
            {
                statusMsg = await facadeStatue.PostAsync(NewStatue.Statue);
                statueId = await GetHighestStatueId();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            if (!statusMsg.Contains("Success") || statueId <= 0) return statusMsg;

            #region Foreach Loops
            // Disse Foreach Loops, løber igennem de mange forskellige mellem tabler, og poster deres værdi i til databasen. 
            try
            {
                foreach (var culturalValue in NewStatue.CulturalValues)
                {
                    statusMsg = await facadeStatue.PostAsync(new modelCulturalValueList(statueId, culturalValue.Id));

                    //Hvis statusMsg ikke får beskeden Succes fra facaden, løber den ud af foreach loop'et og skriver en Exception fejl besked
                    if (!statusMsg.Contains("Success"))                    {
                        throw new Exception(statusMsg);
                    }
                }
                foreach (var material in NewStatue.Materials)
                {
                    statusMsg = await facadeStatue.PostAsync(new modelMaterialList(statueId, material.Id));
                    if (!statusMsg.Contains("Success"))
                    {
                        throw new Exception(statusMsg);
                    }
                }
                foreach (var placement in NewStatue.Placements)
                {
                    statusMsg = await facadeStatue.PostAsync(new modelPlacementList(statueId, placement.Id));
                    if (!statusMsg.Contains("Success"))
                    {
                        throw new Exception(statusMsg);
                    }
                }
                foreach (var statueType in NewStatue.StatueTypes)
                {
                    statusMsg = await facadeStatue.PostAsync(new modelStatueTypeList(statueId, statueType.Id));
                    if (!statusMsg.Contains("Success"))
                    {
                        throw new Exception(statusMsg);
                    }
                }
                if (NewStatue.Description != null)
                {
                    statusMsg = await facadeStatue.PostAsync(NewStatue.Description);
                    if (!statusMsg.Contains("Success"))
                    {
                        throw new Exception(statusMsg);
                    }
                }
                if (NewStatue.GpsLocation != null)
                {
                    statusMsg = await facadeStatue.PostAsync(NewStatue.GpsLocation);
                    if (!statusMsg.Contains("Success"))
                    {
                        throw new Exception(statusMsg);
                    }
                }
            } 
            #endregion

            // ReSharper disable once RedundantCatchClause
            catch (Exception)
            {
                throw;
            }
            //NewStatue.Dispose();
            return statusMsg;
        }
    }
}