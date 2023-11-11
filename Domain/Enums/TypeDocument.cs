using System.Text.Json.Serialization;

namespace Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TypeDocument
{
    IdentificationCard,
    IdentityCard,
    ImmigrationCard,
    CivilRegistration,
    DniCountryOfOrigin,
    DniPassport,
    SafeConductForRefugee,
    SpecialPermanencePermission,
    PermissionForTemporaryProtection
}