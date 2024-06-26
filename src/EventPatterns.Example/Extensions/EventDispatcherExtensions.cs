using EventPatterns.Example.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace EventPatterns.Example.Extensions;

public static class EventDispatcherExtensions
{
    public static void RegisterEventHandlers<TEvent>(
        this IEventDispatcher dispatcher, IServiceProvider serviceProvider)
        where TEvent : IDomainEvent
    {
        var handlers = serviceProvider.GetServices<IEventHandler<TEvent>>();

        foreach (var handler in handlers)
        {
            dispatcher.Register<TEvent>(handler.HandleAsync);
        }
    }
}
