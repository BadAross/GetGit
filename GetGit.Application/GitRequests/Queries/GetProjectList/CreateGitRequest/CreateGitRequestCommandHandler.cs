public class CreateGitRequestCommandHandler
{
    private readonly IGitRequestDbContext _dbcontext;

    public CreateGitRequestCommandHandler(IGitRequestDbContext dbcontext) =>
        _dbcontext = dbcontext;

    public string Handle(string request,
        CancellationToken cancellationToken)
    {
        var gitRequest = new GitRequest
        {
            RequestText = request,
            JsonResult = new CreateJsonString(request).ReturnJsonString()
        };

        _dbcontext.GitRequests.Add(gitRequest);
        _dbcontext.SaveChangesAsync(cancellationToken);

        return gitRequest.JsonResult;
    }
}
