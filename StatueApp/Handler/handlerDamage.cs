using System;
using System.Linq;
using System.Threading.Tasks;
using StatueApp.Common;
using StatueApp.Facade;
using StatueApp.Model;

namespace StatueApp.Handler
{
    public class handlerDamage
    {
        private static async Task<int> GetHighestDamageId()
        {
            var damageList = await facadeStatue.GetListAsync(new modelDamage());

            //int max = 0;
            //foreach (var item in statueList)
            //    max = Math.Max(max, item.Id);
            //return max;

            // Løber listen af statuer igennem og finder og retunerer det højeste Id (Sidst tilføjede statue)
            // Gør det samme som ovenstående Loop
            return damageList.Select(item => item.Id).Concat(new[] { 0 }).Max();
        }


        public static async Task<string> AddDamage(int statueId)
        {
            string statusMsg;
            var NewDamage = DamageSingleton.Instance;

            try
            {
                statusMsg = await Facade.facadeStatue.PostAsync(NewDamage.Damage);
                var damageId = await GetHighestDamageId();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return statusMsg;
        }
    }
}
