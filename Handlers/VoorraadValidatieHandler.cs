using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Extensions;

namespace ProductCatalogus.Handlers;

public class VoorraadValidatieHandler : INotificationHandler<ContentSavingNotification>
{
    public void Handle(ContentSavingNotification notification)
    {
        foreach (var content in notification.SavedEntities)
        {
            if (content.ContentType.Alias != "product") continue;

            var voorraad = content.GetValue<int>("voorraad");
            if (voorraad < 0)
            {
                notification.CancelOperation(new EventMessage(
                    "Ongeldige voorraad",
                    $"{content.Name}: voorraad kan niet negatief zijn.",
                    EventMessageType.Error));
            }
        }
    }
}

public class WebshopComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
        => builder.AddNotificationHandler<ContentSavingNotification, VoorraadValidatieHandler>();
}
