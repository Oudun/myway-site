using dotenv.net;
using static MyWay.Startup;

DotEnv.Load();
var builder = CreateWebBuilder(args);
var app = builder.Build();
app.ConfigurePipeline();
app.Run();