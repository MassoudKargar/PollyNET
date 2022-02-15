var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient("PollyNet").AddPolicyHandler(
    policySelector: request => request.Method == HttpMethod.Get ? new ClientPulicy().ExponentialHttpRetry : new ClientPulicy().ExponentialHttpRetry
);
builder.Services.AddSingleton<ClientPulicy>(new ClientPulicy());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();