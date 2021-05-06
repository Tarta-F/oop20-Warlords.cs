using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace WarlordsCS
{
	public class ControllerIO : IControllerIO
	{
        private static readonly string scoreFile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) +
            Path.DirectorySeparatorChar + "scores.json";
        private readonly JsonSerializer serializer;
        public ControllerIO()
		{
            this.serializer = new JsonSerializer();
        }

        public void ClearFile()
        {
            if (File.Exists(scoreFile))
            {
                File.Delete(scoreFile);
            }
        }

        public IList<string> ReadScore()
        {
            if (File.Exists(scoreFile))
            {
                using StreamReader reader = new StreamReader(scoreFile);
                try
                {
                    string json = reader.ReadToEnd();
                    var prevScores = JsonConvert.DeserializeObject<List<Score>>(json);
                    IList<string> oldResults = new List<string>();
                    prevScores.ForEach(r => oldResults.Add(r.ToString()));
                    return oldResults;
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.ToString());
                    return null;
                }
            }
            else
            {
                IList<string> emptyScoreList = new List<string> { "No results yet." };
                return emptyScoreList;
            }
        }

        public void WriteNewScore(Score score)
        {
            if (File.Exists(scoreFile))
            {
                this.ReadAndWriteNew(score);
            }
            else
            {
                WriteFirstScore(score);
            }
        }

        private void WriteFirstScore(Score score)
        {
            IList<Score> scoreList = new List<Score> { score };
            ///scoreList.Add(score); 
            try
            {
                using (File.Create(scoreFile)) ;
                using StreamWriter sw = new StreamWriter(scoreFile);
                using JsonWriter writer = new JsonTextWriter(sw);
                serializer.Serialize(writer, scoreList);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void ReadAndWriteNew(Score score)
        {
            try
            {
                StreamReader reader = new StreamReader(scoreFile);
                string json = reader.ReadToEnd();
                var prevScores = JsonConvert.DeserializeObject<List<Score>>(json);
                reader.Dispose();
                prevScores.Add(score);
                try
                {
                    using StreamWriter streamWriter = new StreamWriter(scoreFile);
                    using JsonWriter writer = new JsonTextWriter(streamWriter);
                    serializer.Serialize(writer, prevScores);
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
