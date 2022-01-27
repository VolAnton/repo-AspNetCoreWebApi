using AutoMapper;
using MetricsAgent.Models.Dto;
using MetricsAgent.Models.Metrics;

namespace MetricsAgent.DAL.Other
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CpuMetric, CpuMetricDto>();
            CreateMap<DotNetMetric, DotNetMetricDto>();
            CreateMap<HddMetric, HddMetricDto>();
            CreateMap<NetworkMetric, NetworkMetricDto>();
            CreateMap<RamMetric, RamMetricDto>();

            CreateMap<CpuMetricDto, CpuMetric>();
            CreateMap<DotNetMetricDto, DotNetMetric>();
            CreateMap<HddMetricDto, HddMetric>();
            CreateMap<NetworkMetricDto, NetworkMetric>();
            CreateMap<RamMetricDto, RamMetric>();
        }
    }
}
