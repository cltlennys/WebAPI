using Core.DTOs.Charge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IChargeRepository
    {

        Task<ChargeDTO> AddByCard(int CardId, CreateChargeDTO createChargeDTO);

        /// <summary>
        /// Verifica si el monto de la transaccion es permitido. Retorna true si es permitido.
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        Task<bool> VerifyChargeAmount(int cardId, int amount);

    }
}
