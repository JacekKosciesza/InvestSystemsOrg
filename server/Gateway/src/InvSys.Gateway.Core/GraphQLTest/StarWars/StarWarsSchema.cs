using System;
using GraphQL.Types;

namespace InvSys.Gateway.Core.GraphQLTest.StarWars
{
    public class StarWarsSchema : Schema
    {
        public StarWarsSchema(Func<Type, GraphType> resolveType)
            : base(resolveType)
        {
            Query = (ObjectGraphType)resolveType(typeof(StarWarsQuery));
        }
    }
}
