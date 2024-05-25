using Dapper;
using iTEC_Hackathon.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace iTEC_Hackathon.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public CommentsController(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }
        [HttpPost]
        [Route("InsertComment")]

        public ActionResult InsertComment(CommentDTO commentDTO)
        {
            var datetime = DateTime.Now;   
            var parameters = new DynamicParameters();
            parameters.Add("@IdApplication", commentDTO.IdApplication);
            parameters.Add("@IdUser", commentDTO.IdUser);
            parameters.Add("@Comment", commentDTO.Comment);
            parameters.Add("@DateComented", datetime);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                var result = connection.Execute("AddComment", parameters, commandType: CommandType.StoredProcedure);

                    return Ok("Comment inserted successfully");
            }  
        }
        [HttpGet]
        [Route("GetComments")]
        public ActionResult GetComments(int IdApplication)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdApplication", IdApplication);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                
                var result = connection.Query("GetCommentsByApplicationId", parameters, commandType: CommandType.StoredProcedure);
                return Ok(result);
            }
        }
    }
}
