using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using StatueApp.Common;
using StatueApp.Facade;
using StatueApp.Model;

namespace StatueApp.Handler
{
    public class handlerCreateStatue
    {
        /// <summary>
        /// Runs through the listn of Statue and finds the highest
        /// </summary>
        /// <returns>Highest Statue Id (int)</returns>
        private static async Task<int> GetHighestStatueId()
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static async Task<string> CreateStatue()
        {
            var statusMsg="";
            var NewStatue = StatueSingleton.Instance;
            NewStatue.Statue.Created = DateTime.Now;
            NewStatue.Statue.Updated = DateTime.Now;
            try
            {
                statusMsg = await facadeStatue.PostAsync(NewStatue.Statue);
                var statueId = await GetHighestStatueId();

                #region Posting Loops
                foreach (var culturalValue in NewStatue.CulturalValues)
                {
                    await facadeStatue.PostAsync(new modelCulturalValueList(statueId, culturalValue.Id));
                }
                foreach (var image in NewStatue.Images)
                {
                    await facadeStatue.PostAsync(new modelImageList(statueId, image.Id));
                }
                foreach (var material in NewStatue.Materials)
                {
                    await facadeStatue.PostAsync(new modelMaterialList(statueId, material.Id));
                }
                foreach (var placement in NewStatue.Placements)
                {
                    await facadeStatue.PostAsync(new modelPlacementList(statueId, placement.Id));
                }
                foreach (var statueType in NewStatue.StatueTypes)
                {
                    await facadeStatue.PostAsync(new modelStatueTypeList(statueId, statueType.Id));
                }
                if (NewStatue.Description != null)
                {
                    await facadeStatue.PostAsync(NewStatue.Description);
                }
                if (NewStatue.GpsLocation != null)
                {
                    await facadeStatue.PostAsync(NewStatue.GpsLocation);
                }
                #endregion
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
          //  NewStatue.Dispose();
            return "Statue Created Successfully";
        }
    }
}