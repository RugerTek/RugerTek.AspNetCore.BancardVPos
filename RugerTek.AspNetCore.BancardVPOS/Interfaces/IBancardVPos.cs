using System.Threading;
using System.Threading.Tasks;
using RugerTek.AspNetCore.BancardVPOS.Models;

namespace RugerTek.AspNetCore.BancardVPOS.Interfaces
{
    public interface IBancardVPos
    {
        // Pago ocasional
        // Inicia el proceso de pago
        Task<BancardResponse> SingleBuyAsync(BancardSingleBuyRequest request, CancellationToken cancellationToken = default);

        // Pago con Zimple
        Task<BancardResponse> ZimpleSingleBuyAsync(BancardZimpleSingleBuyRequest request, CancellationToken cancellationToken = default);

        // Pago con token
        // Inicia el proceso de catastro de una tarjeta.
        Task<BancardResponse> CardsNew(BancardCardsNewRequest request, CancellationToken cancellationToken = default);
        
        // Operación que permite listar las tarjetas catastradas por un usuario
        Task<BancardUserCardsResponse> UsersCard(int userId, CancellationToken cancellationToken = default);
        
        // Operacion que permite el pago con un token
        Task<BancardChargeResponse?> Charge(BancardChargeRequest request, CancellationToken cancellationToken = default);
        
        // Operacion que permite eliminar una tarjeta catastrada
        Task<BancardResponse> Delete(int userId, string aliasToken, CancellationToken cancellationToken = default);
        
        // Servicios que se utilizan tanto para pago ocasional como para pago con token.
        // Operación que permite cancelar el pago (anónimo o con token).
        Task<BancardResponse> SingleBuyRollback(int shopProcessId, CancellationToken cancellationToken = default);
        // Operación para consulta, si un pago (anónimo o con token) fue confirmado o no
        Task<BancardConfirmationResponse> GetSingleBuyConfirmation(int shopProcessId, CancellationToken cancellationToken = default);

        // Valida el token de la operacoin Sigle Buy Confirm invocada por Bancard
        Task<bool> ValidateSingleBuyConfirmToken(BancardSingleBuyConfirm request);
    }
}