using Dapper;
using iTEC_Hackathon.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace iTEC_Hackathon.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public NotificationController(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }
        [HttpPost]
        [Route("InsertNotification")]

        public ActionResult InsertNotification(NotificationDTO notificationDTO)
        {           
            var datetime = DateTime.Now;   
            var parameters = new DynamicParameters();
            parameters.Add("@IdReceiver", notificationDTO.IdReceiver);
            parameters.Add("@IdSender", notificationDTO.IdSender);
            parameters.Add("@Text", notificationDTO.Text);
            parameters.Add("@DateCreated", datetime);
            parameters.Add("@IdApplication", notificationDTO.IdApplication);
            parameters.Add("@IdEndpoint", notificationDTO.IdEndpoint);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                var result = connection.Execute("InsertNotification", parameters, commandType: CommandType.StoredProcedure);
                if(result > 0)
                {
                    return Ok("Notification inserted successfully");
                }
                else
                {
                    return BadRequest("Notification failed to insert");
                }
            }  
        }
        [HttpGet]
        [Route("GetNotifications")]
        public ActionResult GetNotifications(int idReceiver)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdReceiver", idReceiver);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                
                var result = connection.Query("GetNotificationsByReceiver", parameters, commandType: CommandType.StoredProcedure);
                return Ok(result);
            }
        }
        [HttpDelete]
        [Route("DeleteNotification")]
        public ActionResult DeleteNotification(int idNotification)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdNotification", idNotification);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                var result = connection.Execute("DeleteNotificationById", parameters, commandType: CommandType.StoredProcedure);
                if(result > 0)
                {
                    return Ok("Notification deleted successfully");
                }
                else
                {
                    return BadRequest("Notification failed to delete");
                }
            }
        }

    }
}
