namespace Api.DataContracts
{
    public record EditDescriptionDto(
        Guid Id,
        string Description
    );

    public record EditNameDto(
        Guid Id,
        string Name
    );
}