using Shared;

namespace Core.Spaces;

public static class SpaceErrors
{
    public static readonly Error SpaceNotUnique = Error.Conflict(
        "Space.NameNotUnique",
        "The provided name is not unique");
    
    public static readonly Error NotFound = Error.NotFound(
        "Space.NotFoundById",
        "The space with the specified id was not found");

}