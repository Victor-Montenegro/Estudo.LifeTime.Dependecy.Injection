using Estudo.LifeTime.Dependecy.Injection.TesteReferenciaCircular;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<SingletonClass>();
builder.Services.AddScoped<ScopedClass>();
builder.Services.AddTransient<TransientClass>();

builder.Services.AddTransient<LifeTimeService>();


//Referencia Circular
builder.Services.AddTransient<ClassA>();
builder.Services.AddTransient<ClassB>();
builder.Services.AddTransient<ClassC>();


builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapGet("/api/wether", (SingletonClass singleton,
    ScopedClass scoped, 
    TransientClass transient,
    LifeTimeService service) =>
{
    return new {
        IdentificationSingletonOne = singleton.IdentificationSingleton,
        IdentificationSingletontwo = service.Singleton.IdentificationSingleton,
        IdentificationScopedOne = scoped.IdentificationScoped,
        IdentificationScopedtwo = service.ScopedClass.IdentificationScoped,
        IdentificatioTransientOne = transient.IdentificationTransient,
        IdentificatioTransienttwo = service.TransientClass.IdentificationTransient
    };
})
    .WithName("Wether")
    .WithOpenApi();

app.UseSwagger();
app.UseSwaggerUI();


app.Run();


public class SingletonClass
{
    public Guid IdentificationSingleton = Guid.NewGuid();
}

public class ScopedClass
{
    public Guid IdentificationScoped = Guid.NewGuid();
}

public class LifeTimeService
{
    public LifeTimeService(SingletonClass singleton, ScopedClass scopedClass, TransientClass transientClass)
    {
        Singleton = singleton;
        ScopedClass = scopedClass;
        TransientClass = transientClass;
    }

    public SingletonClass Singleton { get; }
    public ScopedClass ScopedClass { get; }
    public TransientClass TransientClass { get; }
}

public class TransientClass
{
    public Guid IdentificationTransient = Guid.NewGuid();
}