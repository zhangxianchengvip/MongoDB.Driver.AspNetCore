# MongoDBDriver.AspNetCore
### 简介

#### MongoDB.Driver  Asp.Net Core 服务注册

1. 安装

- [Package Manager](https://www.nuget.org/packages/MongoDB.Driver.AspNetCore)

```
Install-Package MongoDBDriver.AspNetCore
```

- [.NET CLI](https://www.nuget.org/packages/FreeRedis.AspNetCore)

```
dotnet add package MongoDBDriver.AspNetCore
```

2. 创建上下文类继承MongoDbContext

```C#
public class TestMongoDbContext : MongoDbContext
{
    //对应注册AddMongoDbContext<TestMongoDbContext>("mongodb://localhost:27017/", "Test")
    public TestMongoDbContext(string connectionString, string database) : base(connectionString, database)
    {
    }
    
	//对应注册AddMongoDbContext<TestMongoDbContext>("mongodb://localhost:27017/", "Test", options => {  })
    public TestMongoDbContext(string database, MongoClientSettings settings) : base(database, settings)
    {
    }
	//配置 MongoCollection
    public IMongoCollection<Doc> Doc => GetCollection<Doc>(nameof(Doc));
}
```

3. 注册 MongoDB.Driver.AspNetCore

```c#
builder.Services.AddMongoDbContext<TestMongoDbContext>("mongodb://localhost:27017/", "Test");
//OR
builder.Services.AddMongoDbContext<TestMongoDbContext>("mongodb://localhost:27017/", "Test", options => {  });
```

4. 注入上下文

```C#
    private readonly TestMongoDbContext _context;
    public WeatherForecastController( TestMongoDbContext context)
    {
        _context = context;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public void Get()
    {
        //添加数据
        _context.Doc.InsertOne(new Doc { Title = "Test" });
    }
```

