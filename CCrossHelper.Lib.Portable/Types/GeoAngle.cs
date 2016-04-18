/* Author : 
 * Philippe Matray
 *
 * Date :
 * 2016-01-24
 */

using System;

namespace CCrossHelper.Lib.Portable.Types
{
    /// <summary>
    ///     Represents an angle used in geolocalization
    /// </summary>
    public class GeoAngle
    {
        public bool IsNegative { get; }
        public int Degrees { get; }
        public int Minutes { get; }
        public int Seconds { get; }
        public int Milliseconds { get; }

        public GeoAngle(double angleInDegrees)
        {
            //ensure the value is in correct range [-180.0..+180.0]
            if (angleInDegrees < -180 || angleInDegrees > 180)
                throw new ArgumentOutOfRangeException(nameof(angleInDegrees));

            //switch the value to positive
            IsNegative = angleInDegrees < 0;
            angleInDegrees = Math.Abs(angleInDegrees);

            var ts = TimeSpan.FromHours(angleInDegrees);
            Degrees = Convert.ToInt32(Math.Floor(ts.TotalHours));
            Minutes = ts.Minutes;
            Seconds = ts.Seconds;
            Milliseconds = ts.Milliseconds;
        }

        public GeoAngle(int degrees, int minutes = 0, int seconds = 0, int milliseconds = 0)
        {
            if (degrees < -180 || degrees > 180)
                throw new ArgumentOutOfRangeException(nameof(degrees));
            if (minutes < 0 || minutes >= 60)
                throw new ArgumentOutOfRangeException(nameof(minutes));
            if (seconds < 0 || minutes >= 60)
                throw new ArgumentOutOfRangeException(nameof(seconds));
            if (milliseconds < 0 || milliseconds >= 1000)
                throw new ArgumentOutOfRangeException(nameof(milliseconds));

            //switch the value to positive
            IsNegative = degrees < 0;
            Degrees = degrees;
            Minutes = minutes;
            Seconds = seconds;
            Milliseconds = milliseconds;
        }

        public double ToDouble()
        {
            var timeSpan = new TimeSpan(0, Degrees, Minutes, Seconds, Milliseconds);
            return (double)Math.Round((decimal)timeSpan.TotalHours, 7);
        }

        public override string ToString()
        {
            var degrees = IsNegative
                ? -Degrees
                : Degrees;

            return $"{degrees}° {Minutes:00}' {Seconds:00}\"";
        }

        public string ToString(string format)
        {
            switch (format)
            {
                case "NS":
                    return $"{Degrees}° {Minutes:00}' {Seconds:00}\".{Milliseconds:000} {(IsNegative ? 'S' : 'N')}";
                case "WE":
                    return $"{Degrees}° {Minutes:00}' {Seconds:00}\".{Milliseconds:000} {(IsNegative ? 'W' : 'E')}";
                default:
                    throw new NotImplementedException();
            }
        }
    }
}