using ECommerceAPI.Persistence;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddPersistenceServices();
//herhangibir yerden gelen isteðe izin vermek istersek;
//builder.Services.AddCors(options=>options.AddDefaultPolicy(policy=>policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.WithOrigins("buraya ui tarafýnýn adresini yazacaðým(hem http hem https olaný").AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
