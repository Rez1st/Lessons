using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HomeWork.TextAnalysis
{
    public class TextAnalysis
    {
        private const string SearchPattern = "*_.txt";
        private const string InputFileDefault = "text_.txt";
        private const string OutputFileDefault = "result.txt";
        private readonly Dictionary<string, int> _phraseRepeats = new();
        private int[] _wordCount;
        private string[] _wordMap;

        public TextAnalysis(string inputPathToFile = null)
        {
            ReadFromFileAndParse(inputPathToFile ?? GetSystemPath());
        }

        private static string GetSystemPath()
        {
            var inputFilePath =
                Directory.GetFiles(Directory.GetCurrentDirectory(), SearchPattern).FirstOrDefault();

            if (inputFilePath == null)
            {
                File.Create(InputFileDefault, default, FileOptions.RandomAccess);
                inputFilePath = InputFileDefault;
            }

            return inputFilePath;
        }

        public void Process()
        {
            CountWordsAndPhrase();

            CheckAndCleanResult();

            WriteToFile();
        }

        private void CountWordsAndPhrase()
        {
            for (var i = 0; i < _wordMap.Length; i++)
                for (var j = 0; j < _wordCount.Length; j++)
                    if (_wordMap[i] == _wordMap[j])
                        _wordCount[i]++;

            for (var i = 0; i < _wordCount.Length - 1;)
            {
                var toContinue = true;
                var repCount = _wordCount[i];

                if (repCount > 1)
                {
                    for (var j = i; toContinue; j++)
                        if (j + 1 < _wordCount.Length && _wordCount[j + 1] > 1)
                        {
                            if (repCount > _wordCount[j + 1]) 
                                repCount = _wordCount[j + 1];
                        }
                        else
                        {
                            var seq = i == j ? new[] { _wordMap[i] } : _wordMap[i..j];
                            _phraseRepeats.TryAdd(string.Join(' ', seq), repCount);
                            i = i == j ? i + 1 : j;
                            toContinue = false;
                        }
                }
                else
                {
                    i++;
                }
            }
        }

        private void CheckAndCleanResult()
        {
            var keysToRemove = new List<string>();

            foreach (var (key, count) in _phraseRepeats)
            {
                var words = key.SplitToWords();
                if (words.Length > 1)
                {
                    var skipFirst = 0;
                    var currentWord = words[0];
                    var seqCounter = 0;
                    var seqStable = true;

                    for (int phraseCounter = 0; phraseCounter < count; phraseCounter++)
                    {
                        skipFirst += seqCounter;

                        for (int j = 0; j < _wordMap.Length; j++)
                        {
                            if (currentWord == _wordMap[j])
                            {
                                if (skipFirst > 0)
                                {
                                    skipFirst--;
                                    continue;
                                }
                                else
                                {
                                    var croppedSeq = _wordMap[j..(j + words.Length)];

                                    for (int i = 0; i < croppedSeq.Length; i++)
                                    {
                                        if (croppedSeq[i] != words[i])
                                        {
                                            seqStable = false;
                                        }
                                    }

                                    if (seqStable)
                                    {
                                        seqCounter++;
                                    }
                                    else
                                    {
                                        skipFirst++;
                                    }

                                    break;
                                }
                            }
                        }
                    }

                    if (seqCounter != count && seqCounter < 2)
                    {
                        keysToRemove.Add(key);
                    }
                }
                else
                {
                    keysToRemove.Add(key);
                }
            }

            foreach (var key in keysToRemove)
            {
                _phraseRepeats.Remove(key);
            }


            for (int i = 0; i < _wordMap.Length; i++)
            {
                _phraseRepeats.TryAdd(_wordMap[i], _wordCount[i]);
            }
        }

        #region ReadWriteFile

        private void WriteToFile()
        {
            using var sw = new StreamWriter(OutputFileDefault);

            foreach (var (key, value)
                     in _phraseRepeats.OrderByDescending(x => x.Value))
                sw.WriteLine($"{key} : {value}");
        }

        private void ReadFromFileAndParse(string file)
        {
            using var sr = new StreamReader(file);

            _wordMap = sr
                .ReadToEnd()
                .ReplaceNewLine()
                .RemovePunctuation()
                .SplitToWords()
                .ItemsToLower()
                .RemoveWhiteSpace()
                .RemoveEmptyStrings();

            _wordCount = new int[_wordMap.Length];
        }

        #endregion
    }
}