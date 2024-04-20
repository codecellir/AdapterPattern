using AdapterPatternAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISamanPayment, SamanPayment>()
    .AddScoped<IZarinpalPayment, ZarinpalPayment>()
    .AddKeyedScoped<IPaymentAdapter, ZarinpalPaymentAdapter>("ZarinPay")
    .AddKeyedScoped<IPaymentAdapter, SamanPaymentAdaptor>("SamanPay");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapPost("/api/zarin-pay", ([FromKeyedServices("ZarinPay")]IPaymentAdapter paymentAdapter) =>
{
    return Results.Ok(paymentAdapter.Pay(250_000));
});

app.MapPost("/api/saman-pay", ([FromKeyedServices("SamanPay")]IPaymentAdapter paymentAdapter) =>
{
    return Results.Ok(paymentAdapter.Pay(250_000));
});

app.Run();

