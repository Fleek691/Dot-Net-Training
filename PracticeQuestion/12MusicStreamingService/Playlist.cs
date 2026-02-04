using System.Collections.Generic;

namespace MusicStreamingService
{
    public class Playlist
    {
        public string PlaylistId { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public List<Song> Songs { get; set; }
    }
}
