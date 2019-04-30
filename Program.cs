using System;
using System.IO;

namespace MusicPlaylistAnalyzer{
    class Program {
        static readonly string[] FileHeaders = { "Name", "Artist", "Album", "Genre", "Size", "Time", "Year", "Plays" };

        static void Main(string[] args) {
            if(args.Length == 2 && AreAllFilePaths(args)) {
                try {
                    TSVReader tsvReader = new TSVReader();
                    MusicPlaylist playlist = new MusicPlaylist(tsvReader.ReadFile(args[0], FileHeaders));
                    playlist.GenerateReport(args[1]);
                } catch (Exception error) {
                    Console.WriteLine(error.Message);
                }
            } else {
                Console.WriteLine("MusicPlaylistAnalyzer <music_playlist_file_path> <report_file_path>");
            }
            Console.WriteLine("Successfully created Music Analysis Report: {0}", args[1]);
            Console.ReadLine();
        }

        static bool AreAllFilePaths(string[] paths) {
            foreach (string path in paths) {
                if (!Path.HasExtension(path)) {
                    Console.WriteLine("\"{0}\" is not a correct file path", path);
                    return false;
                }
            }
            return true;
        }
    }
}
