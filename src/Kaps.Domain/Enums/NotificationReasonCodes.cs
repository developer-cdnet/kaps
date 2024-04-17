using Kaps.Domain.Enums.Core;

namespace Kaps.Domain.Enums;

public enum NotificationReasonCodes
{
    [EnumValue("H1")]
    H1,
    [EnumValue("S1")]
    S1,
    [EnumValue("S2")]
    S2,
    [EnumValue("S3")]
    S3,
    [EnumValue("00")]
    NoDetection
}