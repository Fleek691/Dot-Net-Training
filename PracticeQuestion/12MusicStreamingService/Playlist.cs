using System.Collections.Generic;

namespace MusicStreamingService
{
    public class Playlist
    {
        public string PlaylistId { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public List<Song> Songs { get; set; }
        public Playlist()
        {
            
        }
        public Playlist(string playlistId,string name,string user)
        {
            PlaylistId=playlistId;
            Name=name;
            CreatedBy=user;
            Songs=new List<Song>();
        }
    }
}
