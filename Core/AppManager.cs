using System.Linq;
using System.Collections.Generic;

using Core.Posts;

namespace Core
{
    public class AppManager
    {
        public static AppManager Instance = new AppManager();
        
        private readonly List<Question> questions;
        private readonly Dictionary<string, int> FrequentTags;

        private AppManager()
        {
            questions = new List<Question>();
            FrequentTags = new Dictionary<string, int>();
        }

        public void AddQuestion(Question question)
        {
            questions.Add(question);
        }

        public void TagAddition(string tag)
        {
            if (FrequentTags.ContainsKey(tag) == false)
            {
                FrequentTags[tag] = 0;
            }
            FrequentTags[tag] += 1;
        }

        public List<string> GetFrequentTags()
        {
            return FrequentTags
                .OrderByDescending(pair => pair.Value)
                .Take(5)
                .Select(pair => pair.Key)
                .ToList();
        }
    }
}
