﻿using System;
using App.Metrics;
using Microsoft.Extensions.DependencyInjection.Extensions;

// ReSharper disable CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
// ReSharper restore CheckNamespace
{
    public static class MetricsServiceCollectionExtensions
    {
        public static IMetricsBuilder AddMetrics(this IServiceCollection services)
        {
            if (services == null) 
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services.AddMetrics(null, default(IMetricsContext));
        }

        public static IMetricsBuilder AddMetrics(this IServiceCollection services,
            Action<AppMetricsOptions> setupAction, IMetricsContext metricsContext)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            var builder = services.AddMetricsCore(setupAction, metricsContext);

            if (setupAction != null)
            {
                builder.Services.Configure(setupAction);
            }

            return builder;
        }

        public static IMetricsBuilder AddMetrics(this IServiceCollection services,
            Action<AppMetricsOptions> setupAction)
        {
            return services.AddMetrics(setupAction, default(IMetricsContext));
        }
    }
}