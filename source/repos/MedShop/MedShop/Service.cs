using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MedShop
{
    public class Service
    {
        private readonly ILogger<Service> logger;
        public Service(ILogger<Service> logger)
        {
            this.logger = logger;
        }
        
        public void SendEmailDefault(String mail, string name, string surname)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.IsBodyHtml = true;
                message.From = new MailAddress("admin@mycompany.com", "Интернет-магазин MedShopBY");
                message.To.Add(mail);
                message.Subject = "Сообщение от System.Net.Mail";
                message.Body = "<div style=\"color: black;\"><br>Здравствуйте " + name + " " + surname + "<br></br><br>Благодарим вас за заказ в нашем интернет-магазине. Будем рады видеть вас еще.<br></br> <br>Доставка товара осуществляется с 18.00-23.00 каждый день, без выходных.</br> <br> Курьер позвонит вам за 30 минут до прибытия.</br> <br></br><br>Ваш MedShopBY.</br> </div>";
                //message.Attachments.Add(new Attachment("... путь к файлу ..."));

                using (SmtpClient client = new SmtpClient("smtp.gmail.com"))
                {
                    client.Credentials = new NetworkCredential("medicineshopby@gmail.com", "26021982Luba");
                    client.Port = 587; //порт 587 либо 465
                    client.EnableSsl = true;

                    client.Send(message);
                    logger.LogInformation("Сообщение отправлено успешно!");
                }
            }
            catch (Exception e)
            {
                logger.LogError(e.GetBaseException().Message);
            }
        }
    }
}
