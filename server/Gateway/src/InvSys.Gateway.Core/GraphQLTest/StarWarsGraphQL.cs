using System.Threading;
using GraphQL;
using GraphQL.Execution;
using GraphQL.Http;
using GraphQL.Types;
using GraphQL.Validation;
using InvSys.Gateway.Core.GraphQLTest.StarWars;
using InvSys.Gateway.Core.GraphQLTest.StarWars.IoC;
using InvSys.Gateway.Core.GraphQLTest.StarWars.Types;

namespace InvSys.Gateway.Core.GraphQLTest
{
    public class StarWarsGraphQL : IStarWarsGraphQL
    {
        private ISimpleContainer Services { get; set; }

        public StarWarsGraphQL()
        {
            Services = new SimpleContainer();

            Services.Singleton(new StarWarsData());
            Services.Register<StarWarsQuery>();
            Services.Register<HumanType>();
            Services.Register<DroidType>();
            Services.Register<CharacterInterface>();

            //Services.Singleton(() => new StarWarsSchema(type => (GraphType)Services.Get(type)));
        }

        public string Execute(string query)
        {
            var schema = new StarWarsSchema(type => (GraphType)Services.Get(type));

            IDocumentExecuter documentExecutor = new DocumentExecuter(new AntlrDocumentBuilder(), new DocumentValidator());
            IDocumentWriter writer = new DocumentWriter(indent: true);

            var runResult = documentExecutor.ExecuteAsync(schema, null, query, null);
            var writtenResult = writer.Write(runResult);

            return writtenResult;
        }
    }
}
