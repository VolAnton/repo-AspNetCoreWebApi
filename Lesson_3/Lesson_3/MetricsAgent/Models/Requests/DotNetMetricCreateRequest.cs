﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Models.Requests
{
    public class DotNetMetricCreateRequest
    {
        public TimeSpan Time { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            return $"{{Value={Value}, Time={Time}}}";
        }

    }
}
