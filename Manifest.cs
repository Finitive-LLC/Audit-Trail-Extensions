using Lombiq.AuditTrailExtensions.Constants;
using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "Lombiq Audit Trail Extensions",
    Author = "Lombiq Technologies",
    Version = "2.0.0",
    Description = "Module with additional functionality to the stock Audit Trail.",
    Website = "https://github.com/Lombiq/Audit-Trail-Extensions"
)]

[assembly: Feature(
    Id = FeatureIds.Default,
    Name = "Lombiq Audit Trail Extensions",
    Category = "Content",
    Description = "Module with additional functionality to the stock Audit Trail.",
    Dependencies = new[]
    {
        "OrchardCore.Contents",
        "FinitiveAuditTrail",
    }
)]
