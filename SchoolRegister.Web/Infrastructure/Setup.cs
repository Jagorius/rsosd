namespace SchoolRegister.Web.Infrastructure
{
    #region Usings

    using System.Web.Mvc;

    using AutoMapper;

    using Microsoft.WindowsAzure;
    using Microsoft.WindowsAzure.ServiceRuntime;

    using Ninject;

    using SchoolRegister.Model.Abstract;
    using SchoolRegister.Model.Entities;
    using SchoolRegister.Model.Objects;
    using SchoolRegister.Model.Repositories;

    #endregion

    public static class Setup
    {
        public static void DependencyInjection()
        {
            IKernel kernel = new StandardKernel();

            kernel.Bind<IControllerActivator>().To<SchoolRegisterControllerActivator>();
            kernel.Bind<ICourseRealization>().To<CourseRealization>();

            kernel.Bind<IUsersRepository>().To<UsersRepository>();

            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }

        public static void ObjectMappings()
        {
            Mapper.CreateMap<PersonSchema, Person>()
                .ForMember(dest => dest.Pesel, opt => opt.MapFrom(source => source.PartitionKey));

            Mapper.CreateMap<Person, PersonSchema>()
                .ForMember(dest => dest.PartitionKey, opt => opt.MapFrom(source => source.Pesel))
                .ForMember(dest => dest.RowKey, opt => opt.UseValue(string.Empty))
                .ForMember(dest => dest.Timestamp, opt => opt.Ignore());

            Mapper.AssertConfigurationIsValid();
        }

        public static void WindowsAzure()
        {
            CloudStorageAccount.SetConfigurationSettingPublisher(
                (configName, configSetter) => configSetter(RoleEnvironment.GetConfigurationSettingValue(configName)));
        }
    }
}