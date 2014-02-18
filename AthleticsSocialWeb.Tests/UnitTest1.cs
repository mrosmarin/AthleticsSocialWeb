using System;
using System.Net;
using System.Net.Mail;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AthleticsSocialWeb.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestHmailServer()
        {

            var message = new MailMessage();
            message.From = new MailAddress("social@localhost.localdomain");
            message.To.Add("mrosm20@yahoo.com");


            message.Subject = "Test Subject";
            message.Body = "Test Body";

            message.IsBodyHtml = true;

            var client = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.Network, Host = "localhost", Port = 25
            };
            //    client.Host = "127.0.0.1"; // localhost

            try
            {
                client.Send(message);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}     
