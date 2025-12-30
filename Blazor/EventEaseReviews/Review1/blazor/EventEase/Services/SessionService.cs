namespace EventEase.Services;

public class SessionService
{
    private readonly Dictionary<string, object> _sessionData = new();
    
    public void SetValue<T>(string key, T value)
    {
        _sessionData[key] = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    public T? GetValue<T>(string key)
    {
        if (_sessionData.TryGetValue(key, out var value) && value is T typedValue)
        {
            return typedValue;
        }
        return default;
    }
    
    public bool HasValue(string key)
    {
        return _sessionData.ContainsKey(key);
    }
    
    public void RemoveValue(string key)
    {
        _sessionData.Remove(key);
    }
    
    public void ClearSession()
    {
        _sessionData.Clear();
    }
}