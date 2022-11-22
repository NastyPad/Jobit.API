namespace Jobit.API.Jobit.Domain.Models;

public class Career
{
    public long CareerId { get; set; }
    public String? CareerName { get; set; }
    public String? Description { get; set; }
    
    //Relationships
    public IList<PostJob> Jobs { get; set; }

    public void SetCareer(Career career)
    {
        CareerName = career.CareerName;
        Description = career.Description;
    }
}
