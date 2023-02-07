using System;
using Microsoft.Extensions.DependencyInjection;
using RugerTek.AspNetCore.BancardVPOS.Configurations;
using RugerTek.AspNetCore.BancardVPOS.HttpClients;
using RugerTek.AspNetCore.BancardVPOS.Interfaces;
using RugerTek.AspNetCore.BancardVPOS.Services;

namespace RugerTek.AspNetCore.BancardVPOS
{
    public static class RugerTekBancardExtensions
    {
        public static void AddBancardServices(this IServiceCollection serviceCollection, Action<BancardVPosConfiguration> config, bool staging = false)
        {
            serviceCollection.Configure(config);
            serviceCollection.AddTransient<IBancardVPos, BancardVPosService>();
            serviceCollection.AddHttpClient<IVPosHttpClient, VPosHttpClient>(httpClient =>
                {
                    httpClient.BaseAddress = !staging
                        ? new Uri("https://vpos.infonet.com.py")
                        : new Uri("https://vpos.infonet.com.py:8888");
                });
        }
    }
}