using MediatR;

public class CreateGitRequestCommand : IRequest<Guid>
{
    public string RequestText { get; set; }
}
