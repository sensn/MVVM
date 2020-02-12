using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Midi;

namespace MVVM
{
    public class MyLogic
    {
        public Worker playsequence;
        MainViewModel[] TheModels = new MainViewModel[10];
        public MyLogic()
        {
            Debug.WriteLine("Servas Wöd, I brauch a göd! CREATE TASK");

            playsequence = new Worker();
            Worker.LogHandler myLogger = new Worker.LogHandler(sendMidiMessage1);
            // Worker.LogHandler myLogger = new Worker.LogHandler(BlankPage1.sendMidiMessage);
            playsequence.myLogger1 = myLogger;

            Action<object> action = (object obj) =>
            {

                Console.WriteLine("Task={0}, obj={1}, Thread={2}",
                Task.CurrentId, obj,
                Thread.CurrentThread.ManagedThreadId);
                playsequence.mythread1();
            };


            Task t1 = new Task(action, "alpha");
            t1.Start();
            Console.WriteLine("t1 has been launched. (Main Thread={0})",
                              Thread.CurrentThread.ManagedThreadId);
        }
        public void setTheModels(MainViewModel themodel, int num)
        {
            TheModels[num] = themodel;

            Debug.WriteLine("THEMODELS" + TheModels[0].MyItemsbool[0]);
        }
        public void sendMidiMessage1(int i, int j, int index)
        {

            for (int x = 0; x < 15; x++)
            {
                // ALL NOTES OF
                IMidiMessage midiMessageToSend = new MidiControlChangeMessage((byte)(x), (byte)123, (byte)0);
                //midiOutPort.SendMessage(midiMessageToSend);
            }

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (TheModels[x].MyItemsbool[index+(y*16)] == true )
                    //if (room[x].thepattern.vec_bs1[y, index] == 1 && room[x].thepattern.vec_m_bs1[y] == 1)
                    {
                        byte channel = (byte)x;
                        byte note = (byte)(35 + y);
                        byte velocity = 100;

                        IMidiMessage midiMessageToSend = new MidiNoteOnMessage(channel, note, velocity);
                        //midiOutPort.SendMessage(midiMessageToSend);
                        Debug.WriteLine("TREFFER: " + x +" - " + index );
                    }
                }
            }
            //DoSomething((short)index);
        }
    }
    }

