
namespace App.Mediator.BasicFormat;

public class ConcreateMediator : Mediator
{
    private List<Colleuge> _Colleuges = new List<Colleuge>();
    public ConcreateMediator(params Colleuge[] colleuges)
    {
        foreach (var colleuge in colleuges)
        {
            this.Register(colleuge);
        }
    }

    public void Register(Colleuge colleuge)
    {
        colleuge.SetMediator(this);
        this._Colleuges.Add(colleuge);
    }

    public override void Send(Colleuge from, string message)
    {
        _Colleuges.Where(x => x != from)
            .ToList().ForEach(x => x.HandleMessage(message));
    }

    public  Colleuge CreateCollegue<T>() where T : Colleuge , new()
    {
        var c = new T();
        this.Register(c);
        return c;
    }
}
