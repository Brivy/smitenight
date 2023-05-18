﻿using Smitenight.Utilities.Mapper.Common.Contracts;

namespace Smitenight.Utilities.Mapper.Common.Services
{
    public interface IMapperService
    {
        IMapper<TSource, TDestination> GetMapper<TSource, TDestination>();

        TDestination Map<TSource, TDestination>(TSource source);
    }
}