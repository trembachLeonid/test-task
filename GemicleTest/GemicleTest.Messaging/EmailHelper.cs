using HandlebarsDotNet;

namespace GemicleTest.Messaging
{
    public class EmailHelper : IEmailHelper
    {
        private readonly string storagePath;

        public EmailHelper(string storagePath)
        {
            this.storagePath = storagePath;
        }


        public void SendTemplateA(string message)
        {
            using var writer = new StreamWriter(storagePath + $"/{DateTime.Now.ToString("HH-mm")}-{Guid.NewGuid()}.html", new FileStreamOptions
            {
                Mode = FileMode.Create
            });
            var text = $"<div>Template A. {message}</div>";

            writer.Write(text);
        }

        public void SendTemplateB(string message)
        {
            using var writer = new StreamWriter(storagePath + $"/{DateTime.Now.ToString("HH-mm")}-{Guid.NewGuid()}.html", new FileStreamOptions
            {
                Mode = FileMode.Create,
                Access = FileAccess.Write
            });

            var text = $"<div>Template B. {message}</div>";

            writer.Write(text);
        }

        public void SendTemplateC(string message)
        {
            using var writer = new StreamWriter(storagePath + $"/{DateTime.Now.ToString("HH-mm")}-{Guid.NewGuid()}.html", new FileStreamOptions
            {
                Mode = FileMode.Create
            });

            var text = $"<div>Template C. {message}</div>";

            writer.Write(text);
        }
    }
}
