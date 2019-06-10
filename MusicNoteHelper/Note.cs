using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicNoteHelper
{
    /// <summary>
    /// Describes an individual sound that can be created by a music instrument. 
    /// </summary>
    public class Note : IEquatable<Note>
    {
        private Note(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public Accidental 

        public static Note For(string note)
        {
            return PossibleNotes.FirstOrDefault(n => n.Name == note) ?? Note.Rest;
        }

        public static bool operator ==(Note left, Note right)
        {
            return EqualityComparer<Note>.Default.Equals(left, right);
        }

        public static bool operator !=(Note left, Note right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Note);
        }

        public bool Equals(Note other)
        {
            return other != null &&
                   Name == other.Name;
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }

        public override string ToString()
        {
            return Name;
        }

        private static Note[] PossibleNotes = new Note[]
        {
            Note.AFlat, Note.A, Note.ASharp, Note.BFlat, Note.B, Note.C, Note.CSharp, Note.DFlat, Note.D,
            Note.DSharp, Note.EFlat, Note.E, Note.F, Note.FSharp, Note.GFlat, Note.G, Note.GSharp
        };

        public Note Sharpen()
        {
            return this;
        }

        public Note Flatten()
        {
            return this;
        }

        public static Note AFlat => new Note("Ab");
        public static Note A => new Note("A");
        public static Note ASharp => new Note("A#");
        public static Note BFlat => new Note("Bb");
        public static Note B => new Note("B");
        public static Note C => new Note("C");
        public static Note CSharp => new Note("C#");
        public static Note DFlat => new Note("Db");
        public static Note D => new Note("D");
        public static Note DSharp => new Note("D#");
        public static Note EFlat => new Note("Eb");
        public static Note E => new Note("E");
        public static Note F => new Note("F");
        public static Note FSharp => new Note("F#");
        public static Note GFlat => new Note("Gb");
        public static Note G => new Note("G");
        public static Note GSharp => new Note("G#");

        // This is the equivalent of a Null Object
        public static Note Rest => new Note(" ");

       
    }
}
