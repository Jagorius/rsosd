namespace SchoolRegister.Model.Other
{
    using System;

    using AutoMapper;

    using SchoolRegister.Model.Abstract;
    /// <summary>
    /// Mniej kodu przy mapowaniu automapperem
    /// </summary>
    public static class ModelMappingExtensions
    {
        public static TDestination MapInto<TDestination>(this ISchema source)
            where TDestination : IModel
        {
            if (source == null)
            {
                throw new ArgumentNullException("source", "can't be null.");
            }

            return (TDestination)Mapper.Map(source, source.GetType(), typeof(TDestination));
        }


        public static TDestination MapInto<TDestination>(this IModel source)
             where TDestination : ISchema
        {
            if (source == null)
            {
                throw new ArgumentNullException("source", "can't be null.");
            }

            return (TDestination)Mapper.Map(source, source.GetType(), typeof(TDestination));
        }
        
    }
}