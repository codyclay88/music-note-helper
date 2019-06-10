using System;
using System.Collections.Generic;
using System.Text;

namespace MusicNoteHelper
{
    public class MinorPentatonicScale
    {
        public static ICollection<Note> For(Note note)
        {
            var interval = Interval.For(note);
            return new Note[]
            {
                interval.Unison,
                interval.MinorThird,
                interval.PerfectFourth,
                interval.PerfectFifth,
                interval.MinorSeventh,
            };
        }
    }
}
