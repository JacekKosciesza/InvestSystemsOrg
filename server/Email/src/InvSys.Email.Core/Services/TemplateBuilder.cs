using RazorEngine.Templating;
using RazorEngine;

namespace InvSys.Email.Core.Services
{
    public class TemplateBuilder : ITemplateBuilder
    {
        public string BuildDynamically(string template, DynamicViewBag model)
        {
            //var dict = data.ToObject<Dictionary<string, object>>();
            //var viewBag = new DynamicViewBag(dict);
            var message = Engine.Razor.RunCompile(template, "templateKey", null, model);
            return message;
        }
    }
}
