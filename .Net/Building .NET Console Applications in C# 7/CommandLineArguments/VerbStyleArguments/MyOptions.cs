﻿using CommandLine;
namespace VerbStyleArguments;

class MyOptions
{
    [VerbOption("mix")]
    public MixVerbSubOptions MixVerb { get; set; }

    [VerbOption("cook")]
    public CookVerbSubOptions CookVerb { get; set; }
}
