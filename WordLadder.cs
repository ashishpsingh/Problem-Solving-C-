using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication
{
    public static class WordLadder
    {
        /*
            int shotest_path = WordLadder.shortestPath("TOON", "PLEA", new HashSet<string>(){ "POON", "PLEE", "SAME", "POIE", "PLEA", "PLIE", "POIN" });
            Response.Write("=====>" + shotest_path);

            int shotest_path2 = WordLadder.shortestPath("hit", "cog", new HashSet<string>() { "hot", "dot", "dog", "lot", "log" }); // 5
            Response.Write("<br>=====>" + shotest_path2);

            int shotest_path3 = WordLadder.shortestPath("a", "c", new HashSet<string>() { "a", "b", "c" }); // 2
            Response.Write("<br>=====>" + shotest_path3);
         */

        public class Node
        {
            public string word;
            public int Path { get; set; }
        }

        //Length of shortest chain to reach a target word
        public static int shortestPath(string beginWord, string endWord, HashSet<string> wordList)
        {
            if (beginWord == "" || endWord == "" || wordList.Count == 0)
                return 0;

            Queue<Node> q = new Queue<Node>();
            HashSet<string> visited = new HashSet<string>();

            Node node = new Node() { word = beginWord, Path = 1 };
            q.Enqueue(node);
            bool pathfound = false;
            int lastPath = 1;
            while (q.Count > 0)
            {
                var qobj = q.Dequeue();
                if (compare(qobj.word, endWord))
                {
                    return qobj.Path + 1;
                }
                bool isnull = false;
                foreach (string word in wordList)
                {
                    if (word == "" || word == null)
                    {
                        isnull = true;
                    }
                    else if (compare(qobj.word, word) && !visited.Contains(word))
                    {
                        q.Enqueue(new Node() { word = word, Path = qobj.Path + 1 });
                        visited.Add(word);
                        pathfound = true;
                    }
                }

                lastPath = isnull ? lastPath : qobj.Path + 1;
            }

            return lastPath = pathfound == true ? lastPath : 0;

        }

        private static bool compare(string a, string b)
        {
            if (a.Equals(b) || a.Length != b.Length)
            {
                return false;
            }
            else
            {
                int diff = 0;
                foreach (var c in b)
                {
                    if (!a.Contains(c))
                    {
                        diff += 1;
                        if (diff > 1)
                        {
                            return false;
                        }
                    }
                }
                if (diff == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}