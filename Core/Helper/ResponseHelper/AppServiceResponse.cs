using System.Collections.Generic;

namespace Core.Helpers
{
    public class AppServiceResponse<TResponse> : IResponse<TResponse>
    {
        public TResponse Data { get; set; }

        public IEnumerable<string> Errors { get; set; }

        public bool Ok { get; set; }
    }
}
