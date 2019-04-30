using System;
using System.Collections.Generic;

namespace MusicPlaylistAnalyzer {
    public class Song {
        private string name;
        public string Name { get => name; }
        private string artist;
        public string Artist { get => artist; }
        private string album;
        public string Album { get => album; }
        private string genre;
        public string Genre { get => genre; }
        private int size;
        public int Size { get => size; }
        private int time;
        public int Time { get => time; }
        private int year;
        public int Year { get => year; }
        private int plays;
        public int Plays { get => plays; }

        public Song() { }

        public Song(string name, string artist, string album, string genre, int size, int time, int year, int plays) {
            this.name = name;
            this.artist = artist;
            this.album = album;
            this.genre = genre;
            this.size = size;
            this.time = time;
            this.year = year;
            this.plays = plays;
        }

        public override string ToString() {
            return string.Format("Name: {0}, Artist: {1}, Album: {2}, Genre: {3}, Size: {4}, Time: {5}, Year: {6}, Plays: {7}", name, artist, album, genre, size, time, year, plays);
        }

        public static Song Parse(Dictionary<string, string> data) {
            string[] keys = { "name", "artist", "album", "genre", "size", "time", "year", "plays" };
            foreach(string key in keys) {
                if (!data.ContainsKey(key)) {
                    throw new Exception(string.Format("\"{0}\" not found in given data", key));
                }
            }
            if(!int.TryParse(data["time"], out int time)) {
                throw new Exception("\"time\" is not an integer");
            }
            if (!int.TryParse(data["size"], out int size)) {
                throw new Exception("\"size\" is not an integer");
            }
            if (!int.TryParse(data["year"], out int year)) {
                throw new Exception("\"year\" is not an integer");
            }
            if (!int.TryParse(data["plays"], out int plays)) {
                throw new Exception("\"plays\" is not an integer");
            }
            return new Song(data["name"], data["artist"], data["album"], data["genre"], time, size, year, plays);
        }
    }
}