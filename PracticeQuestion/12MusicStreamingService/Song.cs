using System;

namespace MusicStreamingService
{
    public class Song
    {
        public string SongId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public string Album { get; set; }
        public TimeSpan Duration { get; set; }
        public int PlayCount { get; set; }
    }
}
