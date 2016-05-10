using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StatueApp.Common;
using StatueApp.Facade;
using StatueApp.Model;

namespace StatueApp.Handler
{
    public class handlerCreateStatue
    {
        private static int GetHighestStatueId()
        {
            var statue = new modelStatue();
            var statueList = facadeStatue.GetListAsync(statue);

            //foreach (var item in statueList.Result)
            //{
            //    if (item.Id > statueId)
            //    {
            //        statueId = item.Id;
            //    }
            //}
            //return statueId;

            // Løber listen af statuer igennem og finder og retunerer det højeste Id (Sidst tilføjede statue)
            // Gør det samme som ovenstående Loop
            return statueList.Result.Select(item => item.Id).Concat(new[] { 0 }).Max();
        }

        public static async Task<string> CreateStatue()
        {
            var Singleton = StatueSingleton.Instance;
            try
            {
                await facadeStatue.PostAsync(Singleton.Statue);
                var statueId = GetHighestStatueId();

                #region Posting Loops
                // her skal du sette alle statueiderne på listerne
                foreach (var culturalValue in Singleton.CulturalValues)
                {
                    await facadeStatue.PostAsync(new modelCulturalValueList(statueId, culturalValue.Id));
                    //culturalValueLists.Add(culturalValueList);
                }
                foreach (var image in Singleton.Images)
                {
                    await facadeStatue.PostAsync(new modelImageList(statueId, image.Id));
                    //imageLists.Add(imageList);
                }
                foreach (var material in Singleton.Materials)
                {
                    await facadeStatue.PostAsync(new modelMaterialList(statueId, material.Id));
                    //materialLists.Add(materialList);
                }
                foreach (var placement in Singleton.Placements)
                {
                    await facadeStatue.PostAsync(new modelPlacementList(statueId, placement.Id));
                    //placementLists.Add(placementList);
                }
                foreach (var statueType in Singleton.StatueTypes)
                {
                    await facadeStatue.PostAsync(new modelStatueTypeList(statueId,statueType.Id));
                    //statueTypeLists.Add(statueTypeList);
                }
                if (Singleton.Description != null)
                {
                    await facadeStatue.PostAsync(Singleton.Description);
                }
                if (Singleton.GpsLocation != null)
                {
                    await facadeStatue.PostAsync(Singleton.GpsLocation);
                }

                #endregion
                //    try
                //    {
                //        foreach (var item in culturalValueLists)
                //        {
                //            await facadeStatue.PostAsync(item);
                //        }
                //        foreach (var item in imageLists)
                //        {
                //            await facadeStatue.PostAsync(item);
                //        }
                //        foreach (var materialList in materialLists)
                //        {
                //            await facadeStatue.PostAsync(materialList);
                //        }
                //        foreach (var placementList in placementLists)
                //        {
                //            await facadeStatue.PostAsync(placementList);
                //        }
                //        foreach (var statueTypeList in statueTypeLists)
                //        {
                //            await facadeStatue.PostAsync(statueTypeList);
                //        }
                //        if (Singleton.Description != null)
                //        {
                //            await facadeStatue.PostAsync(Singleton.Description);
                //        }
                //        if (Singleton.GpsLocation != null)
                //        {
                //            await facadeStatue.PostAsync(Singleton.GpsLocation);
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        throw new Exception(ex.Message);
                //    }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return "Statue Created Successfully";
        }
    }
}
