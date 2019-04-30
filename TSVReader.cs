using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MusicPlaylistAnalyzer {
    public class TSVReader {
        public List<Song> ReadFile(string filePath, string[] expectedHeaders) {
            List<Song> songs = new List<Song>();
            StreamReader sr = null;
            try {
                sr = new StreamReader(filePath);
                string[] headers = sr.ReadLine().Split('\t');
                if (!expectedHeaders.SequenceEqual(headers)) {
                    throw new Exception(string.Format("Headers provided in file do not match:\n{0}", expectedHeaders.ToString()));
                }
                int lineNumber = 1;
                while (!sr.EndOfStream) {
                    string[] values = sr.ReadLine().Split('\t');
                    Dictionary<string, string> data = new Dictionary<string, string>();
                    if (values.Length == headers.Length) {
                        for (int i=0; i<values.Length; i++) {
                            data.Add(headers[i].ToLower(), values[i]);
                        }
                    } else {
                        throw new Exception(string.Format("Row {0} contains {1} values. It should contain {2}.", lineNumber, values.Length, headers.Length));
                    }
                    try {
                        songs.Add(Song.Parse(data));
                    } catch (Exception error) {
                        throw new Exception(string.Format("Row {0} had an error: {1}", lineNumber, error.Message));
                    }
                    lineNumber++;
                }
            } catch (Exception error) {
                throw error;
            } finally {
                if (sr != null) {
                    sr.Close();
                }
            }
            return songs;
        }
    }
}
