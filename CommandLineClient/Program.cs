using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MusicNoteHelper;

namespace CommandLineClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var response = String.Empty;
            var strNote = String.Empty;
            var extras = String.Empty;
            while(strNote.ToLower() != "exit")
            {
                Console.Write("Enter a note: ");
                response = Console.ReadLine();
                var responseContents = response.Split(" ");
                strNote = responseContents.ElementAtOrDefault(0) ?? String.Empty;
                extras = responseContents.ElementAtOrDefault(1) ?? "M";

                var note = Note.Parse(strNote.ToUpper().FirstOrDefault().ToString());
                if (note == Note.Rest)
                {
                    Console.WriteLine("Invalid Note.");
                    continue;
                }

                //var intervals = Interval.For(note);
                //Console.WriteLine("\n=== INTERVALS ===");
                //PrintIntervals(intervals);

                if (extras == "M")
                {
                    Console.WriteLine("\n=== NOTES IN MAJOR SCALE ===");
                    var notesOfMajorScale = MajorScale.For(note);
                    Console.WriteLine(String.Join<Note>(" - ", notesOfMajorScale));

                    Console.WriteLine("\n=== NOTES IN MAJOR PENTATONIC SCALE ===");
                    var notesOfMajorPentatonicScale = MajorPentatonicScale.For(note);
                    Console.WriteLine(String.Join<Note>(" - ", notesOfMajorPentatonicScale));

                    Console.WriteLine("\n=== MAJOR PENTATONIC NOTES ON GUITAR ===");
                    PrintChordNotesOnInstrument(StringedInstrument.Guitar, notesOfMajorPentatonicScale);
                }

                if(extras == "m")
                {
                    Console.WriteLine("\n=== NOTES IN MINOR SCALE ===");
                    var notesOfMinorScale = MinorScale.For(note);
                    Console.WriteLine(String.Join<Note>(" - ", notesOfMinorScale));

                    Console.WriteLine("\n=== NOTES IN MINOR PENTATONIC SCALE ===");
                    var notesOfMinorPentatonicScale = MinorPentatonicScale.For(note);
                    Console.WriteLine(String.Join<Note>(" - ", notesOfMinorPentatonicScale));

                    Console.WriteLine("\n=== MINOR PENTATONIC NOTES ON GUITAR ===");
                    PrintChordNotesOnInstrument(StringedInstrument.Guitar, notesOfMinorPentatonicScale);
                }

                //Console.WriteLine("\n=== NOTES IN MAJOR CHORD ===");
                //var notesOfMajorChord = MajorChord.For(note);
                //Console.WriteLine(String.Join<Note>(" - ", notesOfMajorChord));

                //Console.WriteLine("\n=== MAJOR CHORD NOTES ON GUITAR ===");
                //PrintChordNotesOnInstrument(StringedInstrument.Guitar, notesOfMajorChord);

                //Console.WriteLine("\n=== NOTES IN MINOR CHORD ===");
                //var notesOfMinorChord = MinorChord.For(note);
                //Console.WriteLine(String.Join<Note>(" - ", notesOfMinorChord));

                //Console.WriteLine("\n=== MINOR CHORD NOTES ON GUITAR ===");
                //PrintChordNotesOnInstrument(StringedInstrument.Guitar, notesOfMinorChord);

                Console.WriteLine("=======================\n");
            }
        }

        static void PrintChordNotesOnInstrument(StringedInstrument instrument, ICollection<Note> notes)
        {
            var builder = new StringBuilder();
            var maxNumberFrets = instrument.Strings.Max(str => str.NumberOfFrets);
            var fretRange = Enumerable.Range(0, maxNumberFrets);

            builder.AppendLine(GetSpacedString<int>(fretRange));
            builder.AppendLine(new String('-', maxNumberFrets * 4));
            foreach(var _string in instrument.Strings)
            {
                var notesInString = _string.PossibleNotes();
                for(var noteIndex = 0; noteIndex < notesInString.Length; noteIndex++)
                {
                    if(!notes.Contains(notesInString[noteIndex]))
                    {
                        notesInString[noteIndex] = Note.Rest;
                    }
                }
                //builder.Append("|");
                //builder.Append(String.Join<Note>(" | ", notesInString));
                //builder.AppendLine("|");
                builder.AppendLine(GetSpacedString<Note>(notesInString));
            }
            Console.WriteLine(builder.ToString());
        }

        static String GetSpacedString<T>(IEnumerable<T> enumerable)
        {
            var outString = String.Empty;
            foreach(var element in enumerable)
            {
                outString += "|";
                outString += $"{element, 3}";
                //outString += "|";
            }
            return outString;
        }

        static void PrintIntervals(Interval interval)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"{interval.Unison} \t- Unison");
            builder.AppendLine($"{interval.MinorSecond} \t- Minor Second");
            builder.AppendLine($"{interval.MajorSecond} \t- Major Second");
            builder.AppendLine($"{interval.MinorThird} \t- Minor Third");
            builder.AppendLine($"{interval.MajorThird} \t- Major Third");
            builder.AppendLine($"{interval.PerfectFourth} \t- Perfect Fourth");
            builder.AppendLine($"{interval.AugmentedFourth} \t- Augmented Fourth/Diminished Fifth");
            builder.AppendLine($"{interval.PerfectFifth} \t- Perfect Fifth");
            builder.AppendLine($"{interval.MinorSixth} \t- Minor Sixth");
            builder.AppendLine($"{interval.MajorSixth} \t- Major Sixth");
            builder.AppendLine($"{interval.MinorSeventh} \t- Minor Seventh");
            builder.AppendLine($"{interval.MajorSeventh} \t- Major Seventh");
            builder.AppendLine($"{interval.PerfectOctave} \t- Perfect Octave");
            Console.Write(builder.ToString());
        }
    }
}
