﻿namespace CreateBusyIndicatorAnimation;

class ConsoleBusyIndicator
{
    int _currentBusySymbol;
    public ConsoleBusyIndicator()
    {
        BusySymbols = new[]
        {
            '|',
            '/',
            '-',
            '\\'
        };
    }
    
    public char[] BusySymbols { get; set; }

    public void UpdateProgress()
    {
        //Store the current curse position
        var originalX = Console.CursorLeft;
        var originalY = Console.CursorTop;

        //Write the next spinner animation symbol
        Console.Write(BusySymbols[_currentBusySymbol]);

        //Loop around all the animation frames
        _currentBusySymbol++;
        if(_currentBusySymbol == BusySymbols.Length)
        {
            //Restart animation
            _currentBusySymbol = 0;
        }

        //Restore cursor to origianl position
        Console.SetCursorPosition(originalX, originalY);
    }
}