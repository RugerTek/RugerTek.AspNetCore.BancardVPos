using System.Threading.Tasks;
using RugerTek.AspNetCore.BancardVPOS.Interfaces;

namespace RugerTek.AspNetCore.BancardVPOS.Services
{
    public class BancardVPosService : IBancardVPos
    {
        public BancardVPosService()
        {
            
        }
        
        public Task SingleBuy()
        {
            throw new System.NotImplementedException();
        }

        public Task CardsNew()
        {
            throw new System.NotImplementedException();
        }

        public Task UsersCard()
        {
            throw new System.NotImplementedException();
        }

        public Task Charge()
        {
            throw new System.NotImplementedException();
        }

        public Task Delete()
        {
            throw new System.NotImplementedException();
        }

        public Task SingleBuyRollback()
        {
            throw new System.NotImplementedException();
        }

        public Task GetSingleBuyConfirmation()
        {
            throw new System.NotImplementedException();
        }

        public Task SingleBuyConfirm()
        {
            throw new System.NotImplementedException();
        }
    }
}