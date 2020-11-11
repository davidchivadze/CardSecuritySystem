using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Helpers
{
    public interface IResponse<TResponse>
    {
        [Required]
        bool Ok { get; set; }

        IEnumerable<string> Errors { get; set; }

        TResponse Data { get; set; }
    }
}
