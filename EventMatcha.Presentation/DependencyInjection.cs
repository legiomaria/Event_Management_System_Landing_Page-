﻿using Microsoft.Extensions.DependencyInjection;


namespace EventMatcha.Presentation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            return services;
        }
    }
}