using System;
using System.Text;

namespace RugerTek.AspNetCore.BancardVPOS.Helpers
{
    public static class HashHelper
    {
        public static string SingleBuy(string privateKey, string shopProcessId, decimal amount, string currency)
        {
            return CreateMd5($"{privateKey}{shopProcessId}{amount:F2}{currency}");
        }

        public static string SingleBuyConfirm(string privateKey, string shopProcessId, decimal amount, string currency)
        {
            return CreateMd5($"{privateKey}{shopProcessId}confirm{amount}{currency}");
        }

        public static string SingleBuyGetConfirmation(string privateKey, string shopProcessId)
        {
            return CreateMd5($"{privateKey}{shopProcessId}get_confirmation");
        }

        public static string SingleBuyRollback(string privateKey, string shopProcessId)
        {
            return CreateMd5($"{privateKey}{shopProcessId}rollback0.00");
        }

        public static string CardsNew(string privateKey, int cardId, int userId)
        {
            return CreateMd5($"{privateKey}{cardId}{userId}request_new_card");
        }

        public static string UsersCards(string privateKey, int userId)
        {
            return CreateMd5($"{privateKey}{userId}request_user_cards");
        }

        public static string Charge(string privateKey, string shopProcessId, decimal amount, string currency, string aliasToken)
        {
            return CreateMd5($"{privateKey}{shopProcessId}charge{amount:F2}{currency}{aliasToken}");
        }

        public static string Delete(string privateKey, int userId, string cardToken)
        {
            return CreateMd5($"{privateKey}delete_card{userId}{cardToken}");
        }
        
        private static string CreateMd5(string input)
        {
            // Use input string to calculate MD5 hash
            using var md5 = System.Security.Cryptography.MD5.Create();
            var inputBytes = Encoding.UTF8.GetBytes(input);
            var hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            // return Convert.ToBase64String(hashBytes);
            var sb = new StringBuilder();
            foreach (var t in hashBytes)
            {
                sb.Append(t.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}