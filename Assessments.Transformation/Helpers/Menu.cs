using System;
using System.Collections.Generic;

namespace Assessments.Transformation.Helpers
{
    public static class Menu
    {
        private static int _menuIndex;

        public static string Setup(IReadOnlyList<string> items)
        {
            for (var i = 0; i < items.Count; i++)
            {
                if (i == _menuIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(items[i]);
                }
                else
                {
                    Console.WriteLine(items[i]);
                }

                Console.ResetColor();
            }

            var keyInfo = Console.ReadKey();

            switch (keyInfo)
            {
                case { Key: ConsoleKey.DownArrow } when _menuIndex == items.Count - 1:
                    break;
                case { Key: ConsoleKey.DownArrow }:
                    _menuIndex++;
                    break;
                case { Key: ConsoleKey.UpArrow } when _menuIndex <= 0:
                    break;
                case { Key: ConsoleKey.UpArrow }:
                    _menuIndex--;
                    break;
                case { Key: ConsoleKey.LeftArrow }:
                case { Key: ConsoleKey.RightArrow }:
                    Console.Clear();
                    break;
                case { Key: ConsoleKey.Enter }:
                    return items[_menuIndex];
                case { Key: ConsoleKey.Escape }:
                    Environment.Exit(0);
                    break;
                default:
                    return string.Empty;
            }

            Console.Clear();
            return string.Empty;
        }
    }
}