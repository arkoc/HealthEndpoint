using System.Collections.Generic;

namespace HealthEndpoint.Results
{

    public class HealthIndicatorResult
    {
        public HealthIndicatorResult()
        {
        }

        public HealthIndicatorResult(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public IEnumerable<string> Errors { get; set; } = new List<string>();
        public object Result { get; set; }
    }
}
