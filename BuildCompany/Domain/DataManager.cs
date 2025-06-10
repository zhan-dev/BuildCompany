using BuildCompany.Domain.Repositories.Abstract;

namespace BuildCompany.Domain
{
    public class DataManager
    {
        public IServiceCategoriesRepository ServiceCategories { get; set; }
        public IServicesRepository Services { get; set; }

        public DataManager(IServiceCategoriesRepository serviceCategoriesRepository, IServicesRepository services)
        {
            ServiceCategories = serviceCategoriesRepository;
            Services = services;
        }
    }
}
