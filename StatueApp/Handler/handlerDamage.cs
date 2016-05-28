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
        /// <summary>
        /// Finder den nyeste generede damage, ved at finde den damage med det højeste Id
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Denne metode tager den damage der er blevet lavet viewet og gemmer den i databasen
        /// </summary>
        /// <param name="statueId"></param>
        /// <returns></returns>
        public static async Task<string> AddDamage(int statueId)
        {
            string statusMsg;
            var NewDamage = DamageSingleton.Instance;

            try
            {
                statusMsg = await facadeStatue.PostAsync(NewDamage.Damage);
                // ReSharper disable once UnusedVariable
                var damageId = await GetHighestDamageId();
            }

            // ReSharper disable once RedundantCatchClause
            catch (Exception)
            {
                throw;
            }
            return statusMsg;
        }
    }
}
