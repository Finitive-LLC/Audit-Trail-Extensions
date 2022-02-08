using Finitive.AuditTrail.Constants;
using Finitive.AuditTrail.Controllers;
using Finitive.AuditTrail.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using OrchardCore.ContentManagement;
using OrchardCore.Contents.AuditTrail.Controllers;
using OrchardCore.Entities;
using OrchardCore.Mvc.Core.Utilities;
using static Finitive.AuditTrail.Providers.ContentAuditTrailEventProvider;

namespace Lombiq.AuditTrailExtensions.Models
{
    public class SavedEvent
    {
        public AuditTrailEventFork AuditTrailEventFork { get; }
        public ContentItem ContentItem { get; }
        public int VersionNumber { get; }

        public SavedEvent(AuditTrailEventFork auditTrailEvent, int versionNumber)
        {
            AuditTrailEventFork = auditTrailEvent;
            ContentItem = auditTrailEvent?.As<ContentItem>(Saved);
            VersionNumber = versionNumber;
        }

        /// <summary>
        /// Returns a link to <see cref="AuditTrailContentController.Display"/> with the right version number and event
        /// ID.
        /// </summary>
        public string GenerateContentDetailLink(LinkGenerator linkGenerator, HttpContext httpContext) =>
            linkGenerator.GetUriByAction(
                httpContext,
                nameof(ContentController.Detail),
                typeof(ContentController).ControllerName(),
                new
                {
                    area = FeatureIds.Area,
                    VersionNumber,
                    auditTrailEventId = AuditTrailEventFork?.Id,
                });
    }
}
