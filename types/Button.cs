public struct Button
{
    public Button(string text, string eventHandler)
    {
        Text = text;
        EventHandler = eventHandler;
    }

    public string Text { get; }
    public string EventHandler { get; }

    public override string ToString() => $"({Text}, {EventHandler})";
};