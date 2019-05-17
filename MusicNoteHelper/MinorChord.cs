using System;
using System.Collections.Generic;
using System.Text;

namespace MusicNoteHelper
{
    public class MinorChord
    {
        public static ICollection<Note> For(Note note)
        {
            var interval = Interval.For(note);
            var notesInChord = new List<Note>();
            notesInChord.Add(interval.Unison);
            notesInChord.Add(interval.MinorThird);
            notesInChord.Add(interval.PerfectFifth);
            return notesInChord;
        }
    }
}
