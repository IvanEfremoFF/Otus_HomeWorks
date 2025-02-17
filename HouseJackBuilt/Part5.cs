using System.Collections.Immutable;

namespace JackHouse
{
    internal class Part5
    {
        public ImmutableList<string> Poem { get; set; }

        public Part5()
        {
            Poem = ImmutableList<string>.Empty;
        }

        public ImmutableList<string> AddPart(ImmutableList<string> poem)
        {
            var text = "Вот пес без хвоста," +
                       "\nКоторый за шиворот треплет кота," +
                       "\nКоторый пугает и ловит синицу," +
                       "\nКоторая часто ворует пшеницу," +
                       "\nКоторая в темном чулане хранится" +
                       "\nВ доме,\nКоторый построил Джек.";

            Poem = text.Split('\n').ToImmutableList();
            return poem.Add(text);
        }
    }
}
