namespace SchoolRegister.Web.Infrastructure
{
    using System;

    using SchoolRegister.Model.Abstract;

    public static class MappingExtensions
    {
        public static TDestination MapInto<TDestination>(this IViewModel source)
            where TDestination : IModel
        {
            if (source == null)
            {
                throw new ArgumentNullException("source", "can't be null.");
            }

            return (TDestination)AutoMapper.Mapper.Map(source, source.GetType(), typeof(TDestination));
        }


        public static TDestination MapInto<TDestination>(this IModel source)
             where TDestination : IViewModel
        {
            if (source == null)
            {
                throw new ArgumentNullException("source", "can't be null.");
            }

            return (TDestination)AutoMapper.Mapper.Map(source, source.GetType(), typeof(TDestination));
        }
        
    }
}