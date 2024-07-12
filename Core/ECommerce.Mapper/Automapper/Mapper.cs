using AutoMapper.Internal;
using AutoMapper;

namespace ECommerce.Mapper.Automapper
{
    public class Mapper : Application.Automapper.IMapper
    {
        public static List<TypePair> typePairs = new List<TypePair>();
        private IMapper MapperContainer;


        public TDestination Map<TDestination, TSource>(TSource source, string? ignore = null)
        {
            Config<TDestination, TSource>(5, ignore);
            return MapperContainer.Map<TSource, TDestination>(source);
        }

        public IList<TDestination> Map<TDestination, TSource>(IList<TSource> source, string? ignore = null)
        {
            Config<TDestination, TSource>(5, ignore);
            return MapperContainer.Map<IList<TSource>, IList<TDestination>>(source);
        }

        public TDestination Map<TDestination, TSource>(object source, string? ignore = null)
        {
            Config<TDestination,object>(5, ignore);
            return MapperContainer.Map<TDestination>(source);
        }

        public IList<TDestination> Map<TDestination, TSource>(IList<object> source, string? ignore = null)
        {
            Config<TDestination, IList<object>>(5, ignore);
            return MapperContainer.Map<IList<TDestination>>(source);
        }




        protected void Config<TDestination, TSource>(int depth, string? ignore = null)
        {
            var typePair = new TypePair(typeof(TDestination), typeof(TSource));

            if (typePairs.Any(x => x.SourceType == typePair.SourceType && x.DestinationType == typePair.DestinationType) && ignore == null)
            {
                return;
            }

            typePairs.Add(typePair);

            var config = new MapperConfiguration(config =>
            {
                foreach (var item in typePairs)
                {
                    if (ignore is not null)
                    {
                        config.CreateMap(item.SourceType, item.DestinationType).MaxDepth(depth).ForMember(ignore, opt => opt.Ignore()).ReverseMap();
                    }
                    else
                    {
                        config.CreateMap(item.SourceType, item.DestinationType).MaxDepth(depth).ReverseMap();
                    }
                }
            });

            MapperContainer = config.CreateMapper();
        }
    }
}
