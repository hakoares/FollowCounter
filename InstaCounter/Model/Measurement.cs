using System;

namespace InstaCounter
{
    public class Measurement
    {
        public DateTime Timestamp { get; set; }
        public int Count { get; set; }

        public Measurement(int Followers)
        {
            this.Timestamp = DateTime.Now;
            this.Count = Followers;
        }
        
    }
}