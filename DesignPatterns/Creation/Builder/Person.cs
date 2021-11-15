namespace MessyExample.DesignPatterns.Creation.Builder
{
    public class Person
    {
        public string Name { get; set; }
        public string Position { get; set; }

        public override string ToString()
        {
            return ($"{nameof(Name)}:{Name} - {nameof(Position)}:{Position}");
        }
    }
}