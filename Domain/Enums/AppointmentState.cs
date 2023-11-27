using System.Text.Json.Serialization;

namespace Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AppointmentState
{
    Scheduled,
    Rescheduled,
    Canceled,
    Attended
}