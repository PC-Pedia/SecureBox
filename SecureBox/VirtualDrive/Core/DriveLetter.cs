﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VirtualDrive.Core
{
    internal static class DriveLetter
    {
        public static string UnusedDriveLetter()
        {
            var validLetters = Properties.Resources.ValidDriveLetters.Reverse();

            var usedDriveLetters = UsedDriveLetters();

            foreach (char letter in validLetters)
            {
                if (!usedDriveLetters.Contains(letter))
                    return letter.ToString();
            }

            throw new ArgumentException("");
        }

        private static List<char> UsedDriveLetters()
        {
            return DriveInfo.GetDrives().Select(s => s.Name[0]).ToList();
        }
    }
}