﻿using System;
using System.Collections.Generic;

namespace Sop.Common
{

    /// <summary>
    /// 非法关键词过滤 (自动忽略汉字数字字母间的其他字符)
    /// </summary>
    public class KeyWordFilter
    {



        public KeyWordFilter(string dictionaryPath)
        {
            this.DictionaryPath = dictionaryPath;
        }

        /// <summary>
        /// 词库路径
        /// </summary>
        public string DictionaryPath { get; set; } = string.Empty;

        /// <summary>
        /// 内存词典
        /// </summary>
        private readonly WordGroup[] _memorylexicon = new WordGroup[(int)char.MaxValue];

        /// <summary>
        /// 检测源
        /// </summary>
        public string SourctText { get; set; } = string.Empty;

        /// <summary>
        /// 检测源游标
        /// </summary>
        int _cursor = 0;

        /// <summary>
        /// 匹配成功后偏移量
        /// </summary>
        int _wordlenght = 0;

        /// <summary>
        /// 检测词游标
        /// </summary>
        int _nextCursor = 0;



        private readonly List<string> illegalWords = new List<string>();

        /// <summary>
        /// 检测到的非法词集
        /// </summary>
        public List<string> IllegalWords
        {
            get { return illegalWords; }
        }

        /// <summary>
        /// 判断是否是中文
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        private bool isCHS(char character)
        {
            //  中文表意字符的范围 4E00-9FA5
            int charVal = (int)character;
            return (charVal >= 0x4e00 && charVal <= 0x9fa5);
        }

        /// <summary>
        /// 判断是否是数字
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        private bool isNum(char character)
        {
            int charVal = (int)character;
            return (charVal >= 48 && charVal <= 57);
        }

        /// <summary>
        /// 判断是否是字母
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        private bool isAlphabet(char character)
        {
            int charVal = (int)character;
            return ((charVal >= 97 && charVal <= 122) || (charVal >= 65 && charVal <= 90));
        }


        /// <summary>
        /// 转半角小写的函数(DBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>半角字符串</returns>
        ///<remarks>
        ///全角空格为12288，半角空格为32
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///</remarks>
        private string ToDBC(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c).ToLower();
        }

        /// <summary>
        /// 加载内存词库
        /// </summary>
        private void LoadDictionary()
        {
            if (DictionaryPath != string.Empty)
            {
                List<string> wordList = new List<string>();
                Array.Clear(_memorylexicon, 0, _memorylexicon.Length);
                string[] words = System.IO.File.ReadAllLines(DictionaryPath, System.Text.Encoding.Default);
                foreach (string word in words)
                {
                    string key = this.ToDBC(word);
                    wordList.Add(key);
                    wordList.Add(Microsoft.VisualBasic.Strings.StrConv(key, Microsoft.VisualBasic.VbStrConv.TraditionalChinese, 0));
                }
                Comparison<string> cmp = delegate (string key1, string key2)
                {
                    return key1.CompareTo(key2);
                };
                wordList.Sort(cmp);
                for (int i = wordList.Count - 1; i > 0; i--)
                {
                    if (wordList[i].ToString() == wordList[i - 1].ToString())
                    {
                        wordList.RemoveAt(i);
                    }
                }
                foreach (var word in wordList)
                {
                    WordGroup group = _memorylexicon[(int)word[0]];
                    if (group == null)
                    {
                        group = new WordGroup();
                        _memorylexicon[(int)word[0]] = group;

                    }
                    group.Add(word.Substring(1));
                }
            }

        }

        /// <summary>
        /// 检测
        /// </summary>
        /// <param name="blackWord"></param>
        /// <returns></returns>
        private bool Check(string blackWord)
        {
            _wordlenght = 0;
            //检测源下一位游标
            _nextCursor = _cursor + 1;
            bool found = false;
            //遍历词的每一位做匹配
            for (int i = 0; i < blackWord.Length; i++)
            {
                //特殊字符偏移游标
                int offset = 0;
                if (_nextCursor >= SourctText.Length)
                {
                    break;
                }
                else
                {
                    //检测下位字符如果不是汉字 数字 字符 偏移量加1
                    for (int y = _nextCursor; y < SourctText.Length; y++)
                    {

                        if (!isCHS(SourctText[y]) && !isNum(SourctText[y]) && !isAlphabet(SourctText[y]))
                        {
                            offset++;
                            //避让特殊字符，下位游标如果>=字符串长度 跳出
                            if (_nextCursor + offset >= SourctText.Length) break;
                            _wordlenght++;

                        }
                        else break;
                    }

                    if ((int)blackWord[i] == (int)SourctText[_nextCursor + offset])
                    {
                        found = true;
                    }
                    else
                    {
                        found = false;
                        break;
                    }


                }
                _nextCursor = _nextCursor + 1 + offset;
                _wordlenght++;


            }
            return found;
        }

        /// <summary>
        /// 查找并替换
        /// </summary>
        /// <param name="replaceChar"></param>
        public string Filter(char replaceChar)
        {
            LoadDictionary();
            if (SourctText != string.Empty)
            {
                char[] tempString = SourctText.ToCharArray(); ;
                for (int i = 0; i < SourctText.Length; i++)
                {
                    //查询以该字为首字符的词组
                    WordGroup group = _memorylexicon[(int)ToDBC(SourctText)[i]];
                    if (group != null)
                    {
                        for (int z = 0; z < group.Count(); z++)
                        {
                            string word = group.GetWord(z);
                            if (word.Length == 0 || Check(word))
                            {
                                string blackword = string.Empty;
                                for (int pos = 0; pos < _wordlenght + 1; pos++)
                                {
                                    blackword += tempString[pos + _cursor].ToString();
                                    tempString[pos + _cursor] = replaceChar;

                                }
                                illegalWords.Add(blackword);
                                _cursor = _cursor + _wordlenght;
                                i = i + _wordlenght;

                            }
                        }
                    }
                    _cursor++;
                }
                return new string(tempString);
            }
            else
            {
                return string.Empty;
            }

        }
    }
    /// <summary>
    /// 具有相同首字符的词组集合
    /// </summary>
    class WordGroup
    {
        /// <summary>
        /// 集合
        /// </summary>
        private List<string> groupList;

        public WordGroup()
        {
            groupList = new List<string>();
        }

        /// <summary>
        /// 添加词
        /// </summary>
        /// <param name="word"></param>
        public void Add(string word)
        {
            groupList.Add(word);
        }

        /// <summary>
        /// 获取总数
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return groupList.Count;
        }

        /// <summary>
        /// 根据下标获取词
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetWord(int index)
        {
            return groupList[index];
        }
    }


}
