using System.Collections.Immutable;

namespace JackHouse
{
    internal class Part3
    {
        public ImmutableList<string> Poem { get; set; }

        public Part3()
        {
            Poem = ImmutableList<string>.Empty;
        }

        public ImmutableList<string> AddPart(ImmutableList<string> poem)
        {
            var text = "А это веселая птица-синица," + 
                       "\nКоторая часто ворует пшеницу," + 
                       "\nКоторая в темном чулане хранится" + 
                       "\nВ доме,\nКоторый построил Джек.";

            Poem = text.Split('\n').ToImmutableList();
            return poem.Add(text);
        }
    }
}
