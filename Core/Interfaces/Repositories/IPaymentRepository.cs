

using Core.DTOs.Payment;

namespace Core.Interfaces.Repositories
{
    public interface IPaymentRepository 
    {

        Task<PaymentDTO> AddByCard(int cardId, CreatePaymentDTO createPaymentDTO);


    }
}
