using RazorEngine.Templating;

namespace InvSys.Email.Core.Services
{
    public interface ITemplateBuilder
    {
        string BuildDynamically(string template, DynamicViewBag model);
    }
}
