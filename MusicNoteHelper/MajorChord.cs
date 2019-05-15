using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicNoteHelper
{
    /// <summary>
    /// Describes the notes that make up a Major Chord.
    /// </summary>
    public class MajorChord
    {
        public static ICollection<Note> For(Note note)
        {
            var interval = Interval.For(note);
            var notesInChord = new List<Note>();
            notesInChord.Add(interval.Unison);
            notesInChord.Add(interval.MajorThird);
            notesInChord.Add(interval.PerfectFifth);
            return notesInChord;
        }
    }
}
