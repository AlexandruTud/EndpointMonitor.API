using iTEC_Hackathon.Infrastructure;
using iTEC_Hackathon.Interfaces;
using iTEC_Hackathon.Interfaces.Application;
using iTEC_Hackathon.Interfaces.Endpoint;
using iTEC_Hackathon.Interfaces.EndpointHistory;
using iTEC_Hackathon.Interfaces.Report;
using iTEC_Hackathon.Interfaces.User;
using iTEC_Hackathon.Repositories;
using iTEC_Hackathon.Repositories.Endpoint;
using iTEC_Hackathon.Repositories.EndpointHistory;
using iTEC_Hackathon.Repositories.Report;
using iTEC_Hackathon.Repositories.Statistics;
using iTEC_Hackathon.Repositories.User;





namespace iTEC_Hackathon
{
    public static class MyConfigServiceCollection
    {
        public static IServiceCollection AddMyDependencyGroup(
             this IServiceCollection services)
        {
            services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
            //--------------------------------------------------------------------
            //USER
            services.AddScoped<ILoginUserRepository, LoginUserRepository>();
            services.AddScoped<IRegisterUserRepository, RegisterUserRepository>();
            services.AddScoped<IGetUserApplicationsInfoRepository, GetUserApplicationsInfoRepository>();
            services.AddScoped<IGetIsUserAuthorRepository, GetIsUserAuthorRepository>();
            //--------------------------------------------------------------------
            //APPLICATION
            services.AddScoped<IAddApplicationRepository, AddApplicationRepository>();
            services.AddScoped<IDeleteApplicationRepository, DeleteApplicationRepository>();
            services.AddScoped<IGetApplicationByAuthorRepository, GetApplicationByAuthorRepository>();
            services.AddScoped<IGetApplicationByIdRepository, GetApplicationByIdRepository>();
            services.AddScoped<IUpdateApplicationRepository, UpdateApplicationRepository>();
            //--------------------------------------------------------------------
            //ENDPOINT
            services.AddScoped<IGetEndpointRepository, GetEndpointRepository>();
            services.AddScoped<IAddEndpointRepository, AddEndpointRepository>();
            services.AddScoped<IDeleteEndpointRepository, DeleteEndpointRepository>();
            //--------------------------------------------------------------------
            //ENDPOINT-HISTORY
            services.AddScoped<IAddEndpointHistoryRepository, AddEndpointHistoryRepository>();
            services.AddScoped<IGetEndpointHistoryByHoursRepository, GetEndpointHistoryByHoursRepository>();
            services.AddScoped<IGetEndpointStateByHistoryRepository, GetEndpointStateByHistoryRepository>();
            services.AddScoped<IGetHistoryByIdEndpointRepository, GetHistoryByIdEndpointRepository>();
            //--------------------------------------------------------------------
            //REPORT
            services.AddScoped<IAddReportRepository, AddReportRepository>();
            services.AddScoped<IGetReportRepository, GetReportRepository>();
            services.AddScoped<IGetReportsUnsolvedByIdUserRepository, GetReportsUnsolvedByIdUserRepository>();
            services.AddScoped<IDeleteReportRepository, DeleteReportRepository>();
            services.AddScoped<IUpdateReportRepository, UpdateReportRepository>();
            //--------------------------------------------------------------------
            //STATISTICS
            services.AddScoped<IGetTotalNumbersOfRecordsRepository, GetTotalNumbersOfRecordsRepository>();
            services.AddScoped<IGetTotalNumberOfEndpointsByStateRepository, GetTotalNumberOfEndpointsByStateRepository>();
            services.AddScoped<IGetTotalNumberOfReportsBySolvedRepository, GetTotalNumberOfReportsBySolvedRepository>();


            return services;
        }
    }
}
