using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

public class CreateJsonString
{
    private readonly string _requestText;
    public CreateJsonString(string requestText) =>
        _requestText = requestText;

    public string ReturnJsonString()
    {
        var gitHubJson = RetrievesDataFromGitHub();
        var listProjects = new List<Project>();
        for (var j = 0; j < gitHubJson.Count; j++)
        {
            var projectsData = JObject.Parse(gitHubJson[j])["items"];
            var countProjects = JObject.Parse(gitHubJson[j])["items"].Count();
            
            for (int i = 0; i < countProjects; i++)
            {
                var project = new Project()
                {
                    Name = (string)projectsData[i]["name"],
                    Login = (string)projectsData[i]["owner"]["login"],
                    StargazersCount = (uint)projectsData[i]["stargazers_count"],
                    WatchersCount = (uint)projectsData[i]["watchers_count"],
                    HtmlUrl = (string)projectsData[i]["html_url"]
                };

                listProjects.Add(project);
            }
        }
        return JsonConvert.SerializeObject(listProjects);
    }

    private List<string> RetrievesDataFromGitHub()
    {
        var str = new List<string>();
        for (var i = 0; i < 4; i++)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.github.com/search/repositories?q=" + _requestText);
            httpWebRequest.UserAgent = "BlackHole";
            httpWebRequest.UseDefaultCredentials = true;

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                str.Add(streamReader.ReadToEnd());
            }
        }
        return str;
    }
}
