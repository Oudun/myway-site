using dotenv.net;
using MyWay;

DotEnv.Load();
var builder = Startup.CreateWebBuilder(args);
var app = builder.Build();
app.ConfigurePipeline();
app.Run();