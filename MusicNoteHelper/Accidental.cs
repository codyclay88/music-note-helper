using System;
using System.Collections.Generic;
using System.Text;

namespace MusicNoteHelper
{
    public class Accidental : IEquatable<Accidental>
    {
        private Accidental(string notation)
        {
            Notation = notation;
        }

        public string Notation { get; }


        public static Accidental None => new Accidental(String.Empty);
        public static Accidental Sharp => new Accidental("#");
        public static Accidental Flat => new Accidental("b");

        public override bool Equals(object obj)
        {
            return Equals(obj as Accidental);
        }

        public bool Equals(Accidental other)
        {
            return other != null &&
                   Notation == other.Notation;
        }

        public override int GetHashCode()
        {
            return 1484178259 + EqualityComparer<string>.Default.GetHashCode(Notation);
        }

        public override string ToString()
        {
            return this.Notation;
        }

        public static bool operator ==(Accidental left, Accidental right)
        {
            return EqualityComparer<Accidental>.Default.Equals(left, right);
        }

        public static bool operator !=(Accidental left, Accidental right)
        {
            return !(left == right);
        }
    }
}
