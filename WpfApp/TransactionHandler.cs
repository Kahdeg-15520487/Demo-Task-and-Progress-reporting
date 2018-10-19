using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApp
{
    class TransactionHandler
    {
        Random random;
        public TransactionHandler(int seed = 0)
        {
            random = new Random(seed);
        }
        /// <summary>
        /// wrapper call a transaction method
        /// </summary>
        /// <param name="IdThingy"></param>
        /// <returns></returns>
        public async Task<string> GetTransactionId(string IdThingy)
        {
            switch (IdThingy)
            {
                case string id when id.Contains("fail"):
                    return await FaultyTransaction();
                case string id when id.Contains("ok"):
                    return await IdealTransaction();
                default:
                    return "unknown transaction";
            }
        }

        /// <summary>
        /// a faulty transaction, will always error
        /// </summary>
        /// <returns></returns>
        async Task<string> FaultyTransaction()
        {
            await Task.Delay(random.Next(15000));
            throw new InvalidOperationException("faulty transaction");
        }

        async Task<string> IdealTransaction()
        {
            await Task.Delay(random.Next(15000));
            return "id";
        }
    }
}
