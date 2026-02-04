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
        public Song(string songId,string title, string artist,string genre,string album,TimeSpan duration)
        {
            SongId=songId;
            Title=title;
            Artist=artist;
            Genre=genre;
            Album=album;
            Duration=duration;
            PlayCount=0;
        }
    }
}
