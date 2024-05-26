namespace HTML;

public class Observer
{
    private readonly Dictionary<string, List<Action>> eventListeners = new Dictionary<string, List<Action>>();

    public void AddEventListener(string eventType, Action listener)
    {
        if (!eventListeners.ContainsKey(eventType))
        {
            eventListeners[eventType] = new List<Action>();
        }
        eventListeners[eventType].Add(listener);
    }

    public void TriggerEvent(string eventType)
    {
        if (eventListeners.TryGetValue(eventType, out var eventListener))
        {
            foreach (var listener in eventListener)
            {
                listener();
            }
        }
    }
}