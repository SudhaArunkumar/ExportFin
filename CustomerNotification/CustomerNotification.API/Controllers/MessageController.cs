using CustomerNotificaton.Services;
using Microsoft.AspNetCore.Mvc;
using SimpleJson;
using System.Threading.Tasks;

namespace CustomerNotification.API.Controllers
{
    [ApiController]
    [Route("controller")]
    public class MessageController : ControllerBase
    {

        [Route("api/message/{customerID}/{messageType}/{fileType}")]
        public Task<Task> GetcustomerMessage (string customerID,string messageType, string fileType)
        {
            var getMessageBody = GetMessageBody(messageType, fileType);

            MessagingService objmessageService = new MessagingService();

            var obj = objmessageService.SendMessageAsync(customerID, getMessageBody);

            return Task.FromResult(obj);
        }

      
        public string GetMessageBody(string messageType, string fileType)
        {
            string message = "";
            if (messageType == "NewUserRegistered")
            {
                if (fileType == "JSON")
                {
                    JsonObject json = new JsonObject();
                    json.Add("messageType:", messageType);

                    JsonObject json2 = new JsonObject();
                    json2.Add("UserID:", "9f9b1a81-2f94-44b7-994d-50cb60738f93");
                    json2.Add("Email:", "test@gmail.com");
                    json2.Add("FirstName:", "Test");
                    json2.Add("LastName:", "Test");
                    json.Add("data:", json2);

                    message = json.ToString();

                    return message;
                }

                else if (fileType == "CSV")
                {
                    message = string.Format("{0},{1},{ 2},{3},{4}", "NewUserRegistered", "9f9b1a81-2f94-44b7-994d-50cb60738f93", "test@gmail.com", "Test", "Test");

                    return message;
                }

                else
                {

                }
            }
            else if (messageType == "UserDeleted")
            {
                if (fileType == "JSON")
                {
                    JsonObject json = new JsonObject();
                    json.Add("messageType:", messageType);

                    JsonObject json2 = new JsonObject();
                    json2.Add("customerId:", "9f9b1a81-2f94-44b7-994d-50cb60738f93");
                    json.Add("data:", json2);

                    message = json.ToString();

                    return message;
                }
                else if (fileType == "CSV")
                {
                    message = string.Format("{0},{1}", "UserDeleted", "9f9b1a81-2f94-44b7-994d-50cb60738f93");

                    return message;
                }

            }
            else if (messageType == "UserBlocked")
            {
                if (fileType == "JSON")
                {
                    JsonObject json = new JsonObject();
                    json.Add("messageType:", messageType);

                    JsonObject json2 = new JsonObject();
                    json2.Add("customerId:", "9f9b1a81-2f94-44b7-994d-50cb60738f93");
                    json.Add("data:", json2);

                    message = json.ToString();

                    return message;
                }
                else if (fileType == "CSV")
                {
                    message = string.Format("{0},{1}", "UserBlocked", "9f9b1a81-2f94-44b7-994d-50cb60738f93");

                    return message;
                }

            }
            return message;
        }

    } 
}
