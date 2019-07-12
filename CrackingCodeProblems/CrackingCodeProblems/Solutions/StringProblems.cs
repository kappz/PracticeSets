﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingCodeProblems.Class_Solutions
{
    class StringProblems
    {
        public bool ContainsOnlyUniqueCharacters(string text)
        {
            bool[] arr = new bool[256];

            if (text == "")
            {
                return false;
            }
            else
            {
                for (int i = 0; i < text.Length; i++)
                {
                    if (arr[text[i]])
                    {
                        return false;
                    }
                    else
                    {
                        arr[text[i]] = true;
                    }
                }
            }
            return true;
        }

        public string Reverse(string text)
        {
            StringBuilder reversed = new StringBuilder();
            if (text.Length == 0)
            {
                return "";
            }
            else if (text.Length == 1)
            {
                return text;
            }
            else
            {
                for (int i = text.Length -1; i >= 0; i--)
                {
                    reversed.Append(text[i]);
                }
            }
            text = reversed.ToString();
            return text;
        }

        public bool IsPermutation(string textA, string textB)
        {
            bool result = true;
            Dictionary<char, int> textACharacterOccurances = new Dictionary<char, int>();
            Dictionary<char, int> textBCharacterOccurances = new Dictionary<char, int>();

            if (textA.Length != textB.Length || textA == textB)
            {
                result = false;
            }
            else
            {
                foreach (char character in textA)
                {
                    if (!textACharacterOccurances.ContainsKey(character))
                    {
                        textACharacterOccurances.Add(character, 1);
                    }
                    else
                    {
                        textACharacterOccurances[character] = textACharacterOccurances[character] + 1;
                    }
                }

                foreach (char character in textB)
                {
                    if (!textBCharacterOccurances.ContainsKey(character))
                    {
                        textBCharacterOccurances.Add(character, 1);
                    }
                    else
                    {
                        textBCharacterOccurances[character] = textBCharacterOccurances[character] + 1;
                    }
                }

                if (textACharacterOccurances.Count == textBCharacterOccurances.Count)
                {
                    foreach (var entry in textACharacterOccurances)
                    {
                        if (!textBCharacterOccurances.Contains(entry))
                        {
                            result = false;
                        }
                    }
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }

        public string ReplaceSpaces(string text)
        {
            string result;
            StringBuilder replacementString = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != ' ')
                {
                    replacementString.Append(text[i]);
                }
                else
                {
                    replacementString.Append("%20");
                }
            }
            result = replacementString.ToString();

            return result;
        }

        public string Compress(string text)
        {
            int iterator = 0;
            int frequency = 0;
            char character;
            char currentCharacter;
            StringBuilder textCompressed = new StringBuilder(text.Length * 2);
            Dictionary<char, int> characterOccurance = new Dictionary<char, int>();
   
            if (text == "")
            {
                return text;
            }
            currentCharacter = text[0];
            characterOccurance.Add(currentCharacter, 1);
            for (int i = 1; i < text.Length; i++)
            {
                character = text[i];
                if (currentCharacter == character)
                {
                    characterOccurance[character] = characterOccurance[character] + 1;
                }
                else
                {
                    textCompressed.Append(currentCharacter);
                    textCompressed.Append(characterOccurance[currentCharacter]);
                    characterOccurance.Remove(currentCharacter);
                    currentCharacter = text[i];
                    characterOccurance.Add(currentCharacter, 1);
                }
            }
            textCompressed.Append(currentCharacter);
            textCompressed.Append(characterOccurance[currentCharacter]);
            if (textCompressed.Length > text.Length)
            {
                return text;
            }
            else
            {
                return textCompressed.ToString();
            }
        }

        public void RotateMatrix(ref char[,] matrix, int size)
        {
            char top;
            int first, last, offset;

            for (int i = 0; i < size / 2; ++i)
            {
                first = i;
                last = (size - 1) - i;
                for (int j = i; j < last; ++j)
                {
                    offset = j - first;
                    top = matrix[first, j];
                    matrix[first, j] = matrix[last - offset, first];
                    matrix[last - offset, first] = matrix[last, last - offset];
                    matrix[last, last - offset] = matrix[j, last];
                    matrix[j, last] = top;
                }
            }
        }
    }
}
