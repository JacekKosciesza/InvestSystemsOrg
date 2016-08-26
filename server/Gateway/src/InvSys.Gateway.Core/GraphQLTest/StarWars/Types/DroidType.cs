using GraphQL.Types;

namespace InvSys.Gateway.Core.GraphQLTest.StarWars.Types
{
    public class DroidType : ObjectGraphType
    {
        public DroidType()
        {
            var data = new StarWarsData();
            Name = "Droid";
            Field<NonNullGraphType<StringGraphType>>("id", "The id of the droid.");
            Field<NonNullGraphType<StringGraphType>>("name", "The name of the droid.");
            Field<ListGraphType<CharacterInterface>>(
                "friends",
                resolve: context => data.GetFriends(context.Source as StarWarsCharacter)
            );
            Interface<CharacterInterface>();
            IsTypeOf = value => value is Droid;
        }
    }
}
