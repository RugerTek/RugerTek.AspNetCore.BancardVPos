using System;
using System.ComponentModel.Design;
using Microsoft.Extensions.DependencyInjection;
using RugerTek.AspNetCore.BancardVPOS.HttpClients;
using RugerTek.AspNetCore.BancardVPOS.Interfaces;
using RugerTek.AspNetCore.BancardVPOS.Services;

namespace RugerTek.AspNetCore.BancardVPOS
{
    public static class RugerTekBancardExtensions
    {
        public static IServiceCollection AddBancardSrevices(IServiceCollection serviceCollection, bool staging = false)
        {
            serviceCollection.AddTransient<IBancardVPos, BancardVPosService>();
            serviceCollection.AddHttpClient<VPosHttpClient>(httpClient =>
                {
                    httpClient.BaseAddress = !staging
                        ? new Uri("https://vpos.infonet.com.py")
                        : new Uri("https://vpos.infonet.com.py:8888");
                });
            return serviceCollection;
        }
    }
}