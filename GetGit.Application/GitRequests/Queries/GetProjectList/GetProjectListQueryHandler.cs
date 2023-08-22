using Newtonsoft.Json;

public class GetProjectListQueryHandler
{
    private readonly IGitRequestDbContext _dbcontext;

    public GetProjectListQueryHandler(IGitRequestDbContext dbcontext) =>
        _dbcontext = dbcontext;

    public List<Project> Handle(string request,
        CancellationToken cancellationToken)
    {
        string? gitRequest = string.Empty;

        gitRequest = _dbcontext.GitRequests.FirstOrDefault(x => x.RequestText == request)?.JsonResult;

        if (gitRequest == null)
        {
            var command = new CreateGitRequestCommandHandler(_dbcontext);
            gitRequest = command.Handle(request, cancellationToken);
        }

        return JsonConvert.DeserializeObject<List<Project>>(gitRequest);
    }
}