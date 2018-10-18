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
        /// <summary>
        /// wrapper call a transaction method
        /// </summary>
        /// <param name="IdThingy"></param>
        /// <returns></returns>
        public async Task<string> GetTransactionId(string IdThingy, IProgress<long> progress)
        {
            switch (IdThingy)
            {
                case string id when id.Contains("fail"):
                    return await FaultyTransaction(progress);
                case string id when id.Contains("long"):
                    return await LongTransaction(progress);
                case string id when id.Contains("ok"):
                    return await IdealTransaction(progress);
                default:
                    return "unknown transaction";
            }
        }

        /// <summary>
        /// a faulty transaction, will always error
        /// </summary>
        /// <returns></returns>
        async Task<string> FaultyTransaction(IProgress<long> progress)
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(20);
                    progress.Report(i);
                }
            });
            throw new InvalidOperationException("faulty transaction");
        }

        async Task<string> LongTransaction(IProgress<long> progress)
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(200);
                    progress.Report(i);
                }
            });
            return "id";
        }

        async Task<string> IdealTransaction(IProgress<long> progress)
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(20);
                    progress.Report(i);
                }
            });
            return "id";
        }
    }
}
