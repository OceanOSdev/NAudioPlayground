﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Midi;
using System.Threading;
using NAudio.Utils;
namespace NAudioTestingApp
{
    public class Music
    {
        MidiOut midOut = new MidiOut(0);
        int patch = 0;
        const int TOP_VOLUME = 65535;
        private static readonly string[] patchNames = new string[]
        {
            "Acoustic Grand","Bright Acoustic","Electric Grand","Honky-Tonk","Electric Piano 1","Electric Piano 2","Harpsichord","Clav",
            "Celesta","Glockenspiel","Music Box","Vibraphone","Marimba","Xylophone","Tubular Bells","Dulcimer",
            "Drawbar Organ","Percussive Organ","Rock Organ","Church Organ","Reed Organ","Accoridan","Harmonica","Tango Accordian",
            "Acoustic Guitar(nylon)","Acoustic Guitar(steel)","Electric Guitar(jazz)","Electric Guitar(clean)","Electric Guitar(muted)","Overdriven Guitar","Distortion Guitar","Guitar Harmonics",
            "Acoustic Bass","Electric Bass(finger)","Electric Bass(pick)","Fretless Bass","Slap Bass 1","Slap Bass 2","Synth Bass 1","Synth Bass 2",
            "Violin","Viola","Cello","Contrabass","Tremolo Strings","Pizzicato Strings","Orchestral Strings","Timpani",
            "String Ensemble 1","String Ensemble 2","SynthStrings 1","SynthStrings 2","Choir Aahs","Voice Oohs","Synth Voice","Orchestra Hit",
            "Trumpet","Trombone","Tuba","Muted Trumpet","French Horn","Brass Section","SynthBrass 1","SynthBrass 2",
            "Soprano Sax","Alto Sax","Tenor Sax","Baritone Sax","Oboe","English Horn","Bassoon","Clarinet",
            "Piccolo","Flute","Recorder","Pan Flute","Blown Bottle","Skakuhachi","Whistle","Ocarina",
            "Lead 1 (square)","Lead 2 (sawtooth)","Lead 3 (calliope)","Lead 4 (chiff)","Lead 5 (charang)","Lead 6 (voice)","Lead 7 (fifths)","Lead 8 (bass+lead)",
            "Pad 1 (new age)","Pad 2 (warm)","Pad 3 (polysynth)","Pad 4 (choir)","Pad 5 (bowed)","Pad 6 (metallic)","Pad 7 (halo)","Pad 8 (sweep)",
            "FX 1 (rain)","FX 2 (soundtrack)","FX 3 (crystal)","FX 4 (atmosphere)","FX 5 (brightness)","FX 6 (goblins)","FX 7 (echoes)","FX 8 (sci-fi)",
            "Sitar","Banjo","Shamisen","Koto","Kalimba","Bagpipe","Fiddle","Shanai",
            "Tinkle Bell","Agogo","Steel Drums","Woodblock","Taiko Drum","Melodic Tom","Synth Drum","Reverse Cymbal",
            "Guitar Fret Noise","Breath Noise","Seashore","Bird Tweet","Telephone Ring","Helicopter","Applause","Gunshot"
        };

        public Music()
        {
            patch = 84;
            midOut.Volume = 0;
            midOut.Send(MidiMessage.ChangePatch(patch, 1).RawData);
            midOut.Send(MidiMessage.StartNote(60, 127, 1).RawData);

        }

        public void PlayNotes()
        {
            while (!GlobVars.playSound)
            {
                midOut.Send(MidiMessage.StartNote(45, 127, 1).RawData);
                //System.Windows.Forms.MessageBox.Show("Sent");
                Thread.Sleep(1000);
                midOut.Send(MidiMessage.StopNote(65, 0, 1).RawData);
                Thread.Sleep(100);

            }
        }

        public void Play()
        {
            while (true)
            {
                if (GlobVars.isPressed)
                {


                    //midOut.Send(MidiMessage.StartNote(60, 127, 1).RawData);
                    //System.Windows.Forms.MessageBox.Show("Sent");
                    midOut.Volume = TOP_VOLUME;
                    Thread.Sleep(500);
                    //midOut.Send(MidiMessage.StopNote(60, 0, 1).RawData);
                    midOut.Volume = 0;
                    Thread.Sleep(10);
                    GlobVars.isPressed = false;

                }
            }
        }
    }
}
