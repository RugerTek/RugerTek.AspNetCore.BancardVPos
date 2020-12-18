using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using RugerTek.AspNetCore.BancardVPOS.Models.Api;

namespace RugerTek.AspNetCore.BancardVPOS.HttpClients
{
    internal interface IVPosHttpClient
    {
        Task<HttpResponseMessage> SingleBuy(RequestApiModel<SingleBuyOperationApiModel> body, CancellationToken cancellationToken = default);
        Task<HttpResponseMessage> ZimpleSingleBuy(RequestApiModel<ZimpleSingleBuyOperationApiModel> body, CancellationToken cancellationToken = default);
        Task<HttpResponseMessage> CardsNew(RequestApiModel<CardsNewOperationApiModel> body, CancellationToken cancellationToken = default);
        Task<HttpResponseMessage> UsersCards(int userId, RequestApiModel<UsersCardsOperationApiModel> body, CancellationToken cancellationToken = default);

        Task<HttpResponseMessage> Charge(RequestApiModel<ChargeOperationApiModel> body,
            CancellationToken cancellationToken = default);

        Task<HttpResponseMessage> DeleteCard(int userId, RequestApiModel<DeleteOperationApiModel> body,
            CancellationToken cancellationToken = default);

        Task<HttpResponseMessage> SingleBuyRollback(RequestApiModel<SingleBuyRollbackApiModel> body,
            CancellationToken cancellationToken = default);

        Task<HttpResponseMessage> SingleBuyConfirm(RequestApiModel<SingleBuyConfirmationApiModel> body,
            CancellationToken cancellationToken = default);
    }
}