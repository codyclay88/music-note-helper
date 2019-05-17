using System;
using System.Collections.Generic;
using System.Text;

namespace MusicNoteHelper
{
    public class MinorScale
    {
        public static IEnumerable<Note> For(Note note)
        {
            var interval = Interval.For(note);
            return new Note[]
            {
                interval.Unison,
                interval.MajorSecond,
                interval.MinorThird,
                interval.PerfectFourth,
                interval.PerfectFifth,
                interval.MinorSixth,
                interval.MinorSeventh,
            };
        }
    }
}
