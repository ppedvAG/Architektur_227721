namespace HalloDecorator
{
    public interface IComponent
    {
        string Name { get; }
        decimal Preis { get; }
    }

    public class Pizza : IComponent
    {
        public string Name => "Pizza";

        public decimal Preis => 8m;
    }

    public class Brot : IComponent
    {
        public string Name => "Brot";

        public decimal Preis => 4m;
    }

    public abstract class Decorator : IComponent
    {
        protected readonly IComponent parent;

        public Decorator(IComponent parent)
        {
            this.parent = parent;
        }

        public abstract string Name { get; }
        public abstract decimal Preis { get; }
    }

    public class Käse : Decorator
    {
        public Käse(IComponent parent) : base(parent)
        { }

        public override string Name => parent.Name + " Käse";

        public override decimal Preis => parent.Preis + 2.3m;
    }

    public class Salami : Decorator
    {
        public Salami(IComponent parent) : base(parent)
        { }

        public override string Name => parent.Name + " Salami";

        public override decimal Preis => parent.Preis + 3.7m;
    }
}
