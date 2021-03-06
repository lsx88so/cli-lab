﻿using System;

namespace Microsoft.DotNet.Tools.Uninstall.Shared.Exceptions
{
    internal static class ExceptionHandler
    {
        public static Action HandleException(Action action)
        {
            return () =>
            {
                try
                {
                    action.Invoke();
                }
                catch (DotNetUninstallException e)
                {
                    PrintExceptionMessage(e.Message);
                    Environment.Exit(1);
                }
            };
        }

        public static void PrintExceptionMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
