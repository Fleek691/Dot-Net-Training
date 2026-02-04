using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicStreamingService
{
    public class MusicManager
    {
        private Dictionary<string, Playlist> playlists = new Dictionary<string, Playlist>();
        private Dictionary<string, Song> songs = new Dictionary<string, Song>();
        private Dictionary<string, User> users = new Dictionary<string, User>();

        private int playlistId = 1;
        private int songId = 1;
        private int userId = 1;

        // -------------------- ADD SONG --------------------
        public void AddSong(string title, string artist, string genre, string album, TimeSpan duration)
        {
            string id = songId.ToString();

            if (songs.ContainsKey(id))
            {
                Console.WriteLine("Song already exists");
                return;
            }

            Song song = new Song(id, title, artist, genre, album, duration);
            songs.Add(id, song);
            songId++;
        }

        // -------------------- CREATE PLAYLIST --------------------
        public void CreatePlaylist(string userId, string playlistName)
        {
            if (!users.ContainsKey(userId))
            {
                Console.WriteLine("User does not exist");
                return;
            }

            if (users[userId].UserPlaylists.Any(p => p.Name == playlistName))
            {
                Console.WriteLine("Playlist already exists");
                return;
            }

            string id = playlistId.ToString();
            Playlist newPlaylist = new Playlist(id, playlistName, userId);

            playlists.Add(id, newPlaylist);                 // global storage
            users[userId].UserPlaylists.Add(newPlaylist);   // ownership link

            playlistId++;
        }

        // -------------------- ADD SONG TO PLAYLIST --------------------
        public bool AddSongToPlaylist(string playlistId, string songId)
        {
            if (!playlists.ContainsKey(playlistId))
                return false;

            if (!songs.ContainsKey(songId))
                return false;

            if (playlists[playlistId].Songs.Any(s => s.SongId == songId))
                return false;

            playlists[playlistId].Songs.Add(songs[songId]);
            return true;
        }

        // -------------------- GROUP SONGS BY GENRE --------------------
        public Dictionary<string, List<Song>> GroupSongsByGenre()
        {
            return songs.Values
                        .GroupBy(s => s.Genre)
                        .ToDictionary(g => g.Key, g => g.ToList());
        }

        // -------------------- GET TOP PLAYED SONGS --------------------
        public List<Song> GetTopPlayedSongs(int count)
        {
            return songs.Values
                        .OrderByDescending(s => s.PlayCount)
                        .Take(count)
                        .ToList();
        }
    }
}
