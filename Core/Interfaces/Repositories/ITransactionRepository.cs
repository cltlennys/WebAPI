

using Core.DTOs.Transaction;

namespace Core.Interfaces.Repositories
{
    public interface ITransactionRepository
    {

        Task<List<TransactionDTO>> GetTransaction(int cardId, DateTime startDate, DateTime endDate);


    }
}
