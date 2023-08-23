using BigoGramm.DAL.IRepositories;
using BigoGramm.DAL.Repositories;
using BigoGramm.Service.Interfaces;
using BigoGramm.Service.Mapping;
using BigoGramm.Service.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace BigoGramm.AllServices
{
    public static class ServiceController
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddAutoMapper(typeof(AutoMapping));
        }
    }
}
