﻿using System;
using System.Text.RegularExpressions;

namespace NotableParser
{
    public class DefnItem
    {
        public string Defintion { get; private set; }
        public string FileCode { get; }
        public string Word { get; private set; }

        public DefnItem(string str, string fileCode) : this(str)
        {
            this.FileCode = fileCode;
            this.Defintion = " - " + str.Trim().Substring(10).Trim();
        }

        public DefnItem(string str)
        {
            this.Defintion = " " + str.Trim();
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(FileCode)) return this.Defintion;
            return $"{this.Defintion} *({this.FileCode})*";
        }
    }
}