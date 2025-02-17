using System.Collections.Immutable;

namespace JackHouse
{
    internal class Part6
    {
        public ImmutableList<string> Poem { get; set; }

        public Part6()
        {
            Poem = ImmutableList<string>.Empty;
        }

        public ImmutableList<string> AddPart(ImmutableList<string> poem)
        {
            var text = "А это корова безрогая," +
                       "\nЛягнувшая старого пса без хвоста," +
                       "\nКоторый за шиворот треплет кота," +
                       "\nКоторый пугает и ловит синицу," +
                       "\nКоторая часто ворует пшеницу," +
                       "\nКоторая в темном чулане хранится" + 
                       "\nВ доме,\r\nКоторый построил Джек.";

            Poem = text.Split('\n').ToImmutableList();
            return poem.Add(text);
        }
    }
}
