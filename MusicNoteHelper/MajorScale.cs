using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicNoteHelper
{
    /// <summary>
    /// Describes the Major Scale for a given key.
    /// </summary>
    public class MajorScale
    {
        public static ICollection<Note> For(Note note)
        {
            var interval = Interval.For(note);
            return new Note[]
            {
                interval.Unison,
                interval.MajorSecond,
                interval.MajorThird,
                interval.PerfectFourth,
                interval.PerfectFifth,
                interval.MajorSixth,
                interval.MajorSeventh,
            };
        }
    }
}
