using System;
using System.Collections.Generic;

namespace MusicStreamingService
{
    public class MusicManager
    {
        public void AddSong(string title, string artist, string genre, string album, TimeSpan duration)
        {
        }

        public void CreatePlaylist(string userId, string playlistName)
        {
        }

        public bool AddSongToPlaylist(string playlistId, string songId)
        {
            return false;
        }

        public Dictionary<string, List<Song>> GroupSongsByGenre()
        {
            return null;
        }

        public List<Song> GetTopPlayedSongs(int count)
        {
            return null;
        }
    }
}
