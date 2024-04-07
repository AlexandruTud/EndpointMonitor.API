using Dapper;
using iTEC_Hackathon.DTOs.User;
using iTEC_Hackathon.Interfaces;
using iTEC_Hackathon.Interfaces.User;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace iTEC_Hackathon.Repositories
{
    public class RegisterUserRepository : IRegisterUserRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public RegisterUserRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<int> RegisterUserAsyncRepo(UserCredentialsDTO userCredentialsDTO)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Email", userCredentialsDTO.Email);

            string hashedPassword = HashPassword(userCredentialsDTO.Password);
            parameters.Add("@Password", hashedPassword);

            parameters.Add("@UserID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("RegisterUser", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("UserID");
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
