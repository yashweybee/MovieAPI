
namespace MovieAPI.Services
{
    public class WriteToFileHostedService : IHostedService
    {
        private readonly IWebHostEnvironment env;
        private readonly string fileName = "File1.txt";
        private Timer timer;

        public WriteToFileHostedService(IWebHostEnvironment env)
        {
            this.env = env;
        }

        private void WriteToFile(string message)
        {
            var path = $@"{env.ContentRootPath}\wwwroot\{fileName}";
            using (StreamWriter writer = new StreamWriter(path, append: true))
            {
                writer.WriteLine(message);
            }
        }

        private void DoWork(object state)
        {
            WriteToFile("process on going:" + DateTime.Now.ToString("dd/mm/yyyy"));
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            WriteToFile("Process started");
            timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            throw new NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            WriteToFile("Process stopped");
            throw new NotImplementedException();
        }
    }
}
