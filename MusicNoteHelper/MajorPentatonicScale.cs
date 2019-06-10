using System;
using System.Collections.Generic;
using System.Text;

namespace MusicNoteHelper
{
    public class MajorPentatonicScale
    {
        public static ICollection<Note> For(Note note)
        {
            var interval = Interval.For(note);
            return new Note[]
            {
                interval.Unison,
                interval.MajorSecond,
                interval.MajorThird,
                interval.PerfectFifth,
                interval.MajorSixth,
            };
        }
    }
}
