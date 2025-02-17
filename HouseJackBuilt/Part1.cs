using System.Collections.Immutable;

namespace JackHouse
{
    internal class Part1
    {
        public ImmutableList<string> Poem { get; set; }

        public Part1()
        {
            Poem = ImmutableList<string>.Empty;
        }

        public ImmutableList<string> AddPart(ImmutableList<string> poem)
        {
            var text = "Вот дом,\nКоторый построил Джек.";

            Poem = text.Split('\n').ToImmutableList();
            return poem.Add(text);
        }
    }
}
