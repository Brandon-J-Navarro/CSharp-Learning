﻿using CommandLine;

namespace UsingAParsingLibary;

class MyOptions
{
    [Option('m', "message")]
    public string Message { get; set; }

    [Option('t', "times")]
    public int Times { get; set; }
}