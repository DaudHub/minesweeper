using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Minesweeper
{
    internal class Time
    {

        CancellationTokenSource source = new CancellationTokenSource();
        CancellationToken cancelToken;

        int hours;
        int minutes;
        int seconds;

        public String Hours
        {
            get
            {
                if (hours < 10)
                    return $"0{hours}";
                else
                    return $"{hours}";
            }
            set
            {
                hours = int.Parse(value);
            }
        }

        public String Minutes
        {
            get
            {
                if (minutes < 10)
                    return $"0{minutes}";
                else
                    return $"{minutes}";
            }
            set
            {
                minutes = int.Parse(value);
                if (minutes > 59)
                {
                    minutes = 0;
                    hours++;
                }
            }
        }

        public String Seconds
        {
            get
            {
                if (seconds < 10)
                    return $"0{seconds}";
                else
                    return $"{seconds}";
            }
            set
            {
                seconds = int.Parse(value);
                if (seconds > 59)
                {
                    seconds = 0;
                    minutes++;
                }
            }
        }  

        public Time(int hours, int minutes, int seconds)
        {
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
            cancelToken = source.Token;
        }

        public async void StartCounting()
        {
            Task count = Task.Run(() =>
            {
                while (true)
                {
                    cancelToken.ThrowIfCancellationRequested();
                    Thread.Sleep(1000);
                    seconds++;
                }
            }, cancelToken);

            try
            {
                await count;
            }
            catch (Exception)
            {
                return;
            }
        }

        public void StopCounting()
        {
            source.Cancel();
        }

        public void ResetCount()
        {
            hours = 0;
            minutes = 0;
            seconds = 0;
        }

        public void AddOneSecond()
        {
            Seconds = (seconds + 1).ToString();
        }

        public override string ToString()
        {
            return hours < 1 ? $"{Minutes}:{Seconds}" : $"{Hours}:{Minutes}{Seconds}";
        }
    }
}
