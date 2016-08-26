using GraphQL.Types;

namespace InvSys.Gateway.Core.GraphQLTest.StarWars.Types
{
    public class CharacterInterface : InterfaceGraphType
    {
        public CharacterInterface()
        {
            Name = "Character";
            Field<NonNullGraphType<StringGraphType>>("id", "The id of the character.");
            Field<NonNullGraphType<StringGraphType>>("name", "The name of the character.");
            Field<ListGraphType<CharacterInterface>>("friends");
        }
    }
}
