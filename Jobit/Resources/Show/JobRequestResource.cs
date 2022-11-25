using Jobit.API.Jobit.Resources.Show;
using Jobit.API.Security.Resources;

namespace Jobit.API.Jobit.Resources;

public class JobRequestResource
{
    public long RequestId { get; set; }
    public UserResource User { get; set; }
    public PostJobResource PostJob { get; set; }
}