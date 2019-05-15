using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicNoteHelper
{
    public class Interval
    {
        private Interval(Note unisonNote)
        {
            var intervalForNote = GetIntervalFor(unisonNote).ToArray();
            Unison = unisonNote;
            MinorSecond = intervalForNote[1];
            MajorSecond = intervalForNote[2];
            MinorThird = intervalForNote[3];
            MajorThird = intervalForNote[4];
            PerfectFourth = intervalForNote[5];
            AugmentedFourth = intervalForNote[6];
            DiminishedFifth = AugmentedFourth;
            PerfectFifth = intervalForNote[7];
            MinorSixth = intervalForNote[8];
            MajorSixth = intervalForNote[9];
            MinorSeventh = intervalForNote[10];
            MajorSeventh = intervalForNote[11];
            PerfectOctave = unisonNote;
        }

        private static Note[] GetIntervalFor(Note rootNote)
        {
            var notes = new Note[12];
            var noteNode = NoteNode.For(rootNote);
            for(int i = 0; i < 12; i++)
            {
                notes[i] = noteNode.Note;
                noteNode = NoteNode.For(noteNode.Next);
            }
            return notes;
        }

        public static Interval For(Note note) => new Interval(note);

        public Note Unison { get; }
        public Note MinorSecond { get; }
        public Note MajorSecond { get; }
        public Note MinorThird { get; }
        public Note MajorThird { get; }
        public Note PerfectFourth { get; }
        public Note AugmentedFourth { get; }
        public Note DiminishedFifth { get; }
        public Note PerfectFifth { get; }
        public Note MinorSixth { get; }
        public Note MajorSixth { get; }
        public Note MinorSeventh { get; }
        public Note MajorSeventh { get; }
        public Note PerfectOctave { get; }
    }
}
