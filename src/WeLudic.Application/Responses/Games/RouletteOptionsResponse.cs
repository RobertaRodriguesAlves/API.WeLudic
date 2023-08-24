namespace WeLudic.Application.Responses.Games;

public sealed class RouletteOptionsResponse
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public RouletteOptionsResponse SetRouletteOptions(int id, string name)
    {
        Id = id;
        Name = name;
        return this;
    }
}
