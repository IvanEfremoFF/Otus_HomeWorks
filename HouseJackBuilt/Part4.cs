using System.Collections.Immutable;

namespace JackHouse
{
    internal class Part4
    {
        public ImmutableList<string> Poem { get; set; }

        public Part4()
        {
            Poem = ImmutableList<string>.Empty;
        }

        public ImmutableList<string> AddPart(ImmutableList<string> poem)
        {
            var text = "Вот кот,\nКоторый пугает и ловит синицу," + 
                       "\nКоторая часто ворует пшеницу," + 
                       "\nКоторая в темном чулане хранится" + 
                       "\nВ доме,\nКоторый построил Джек.";

            Poem = text.Split('\n').ToImmutableList();
            return poem.Add(text);
        }
    }
}
