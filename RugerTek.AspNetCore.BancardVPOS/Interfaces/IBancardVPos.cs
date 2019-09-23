using System.Threading.Tasks;

namespace RugerTek.AspNetCore.BancardVPOS.Interfaces
{
    public interface IBancardVPos
    {
        // Pago ocasional
        // Inicia el proceso de pago
        Task SingleBuy();

        // Pago con token
        // Inicia el proceso de catastro de una tarjeta.
        Task CardsNew();
        
        // Operación que permite listar las tarjetas catastradas por un usuario
        Task UsersCard();
        
        // Operacion que permite el pago con un token
        Task Charge();
        
        // Operacion que permite eliminar una tarjeta catastrada
        Task Delete();
        
        // Servicios que se utilizan tanto para pago ocasional como para pago con token.
        // Operación que permite cancelar el pago (anónimo o con token).
        Task SingleBuyRollback();
        // Operación para consulta, si un pago (anónimo o con token) fue confirmado o no
        Task GetSingleBuyConfirmation();

        // Operación que será invocada por VPOS para confirmar un pago (anónimo o con token).
        Task SingleBuyConfirm();
    }
}