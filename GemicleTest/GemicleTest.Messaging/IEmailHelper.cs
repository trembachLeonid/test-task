namespace GemicleTest.Messaging
{
    public interface IEmailHelper
    {
        void SendTemplateA(string message);
        void SendTemplateB(string message);
        void SendTemplateC(string message);
    }
}
