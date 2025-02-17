using System.Collections.Immutable;

namespace JackHouse
{
    internal class Part8
    {
        public ImmutableList<string> Poem { get; set; }

        public Part8()
        {
            Poem = ImmutableList<string>.Empty;
        }

        public ImmutableList<string> AddPart(ImmutableList<string> poem)
        {
            var text = "А это ленивый и толстый пастух," + 
                       "\nКоторый бранится с коровницей строгою," + 
                       "\nКоторая доит корову безрогую," + 
                       "\nЛягнувшую старого пса без хвоста," + 
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
