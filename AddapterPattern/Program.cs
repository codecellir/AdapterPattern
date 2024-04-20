// See https://aka.ms/new-console-template for more information
using AddapterPattern;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");


var serviceProvider = new ServiceCollection()
    .AddScoped<ISamanPayment, SamanPayment>()
    .AddScoped<IZarinpalPayment, ZarinpalPayment>()
    .AddKeyedScoped<IPaymentAdapter, ZarinpalPaymentAdapter>("ZarinPay")
    .AddKeyedScoped<IPaymentAdapter, SamanPaymentAdaptor>("SamanPay")
    .BuildServiceProvider();


var zarinService = serviceProvider.GetKeyedService<IPaymentAdapter>("ZarinPay");

var samanService = serviceProvider.GetKeyedService<IPaymentAdapter>("SamanPay");


Console.WriteLine(zarinService.Pay(20_000));

Console.WriteLine(samanService.Pay(20_000));

