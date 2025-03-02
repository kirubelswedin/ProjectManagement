using Business.Interfaces;
using Business.Services;
using Data.Interfaces;
using Data.Repositories;

namespace WebApi.Extensions;

public static class ServiceExtensions
{
  public static void RegisterRepositories(this IServiceCollection services)
  {
    services.AddScoped<IAddressRepository, AddressRepository>();
    services.AddScoped<IClientRepository, ClientRepository>();
    services.AddScoped<ICommentRepository, CommentRepository>();
    services.AddScoped<IDepartmentRepository, DepartmentRepository>();
    services.AddScoped<IDocumentRepository, DocumentRepository>();
    services.AddScoped<IEmployeeRepository, EmployeeRepository>();
    services.AddScoped<IInvoiceRepository, InvoiceRepository>();
    services.AddScoped<IProjectRepository, ProjectRepository>();
    services.AddScoped<IProjectEmployeeRepository, ProjectEmployeeRepository>();
    services.AddScoped<IStatusRepository, StatusRepository>();
    services.AddScoped<IProjectTagRepository, ProjectTagRepository>();
    services.AddScoped<IServiceTypeRepository, ServiceTypeRepository>();
    services.AddScoped<ITagRepository, TagRepository>();
    services.AddScoped<ITimeEntryRepository, TimeEntryRepository>();

    services.AddScoped<IClientService, ClientService>();
    services.AddScoped<IEmployeeService, EmployeeService>();
    services.AddScoped<IProjectService, ProjectService>();
    services.AddScoped<IServiceTypeService, ServiceTypeService>();
    services.AddScoped<IStatusService, StatusService>();
  }
}