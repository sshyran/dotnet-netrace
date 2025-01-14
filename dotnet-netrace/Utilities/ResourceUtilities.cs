﻿using System.Diagnostics;
using System.IO;
using System.Reflection;
using Microsoft.Diagnostics.Utilities;

namespace LowLevelDesign.NTrace.Utilities
{
    internal static class ResourceUtilities
    {
        public static bool UnpackResourceAsFile(string resourceName, string targetFileName, Assembly sourceAssembly)
        {
            Stream sourceStream = sourceAssembly.GetManifestResourceStream(resourceName);
            if (sourceStream == null)
                return false;

            var dir = Path.GetDirectoryName(targetFileName);
            Debug.Assert(dir != null, nameof(dir) + " != null");
            Directory.CreateDirectory(dir);     // Create directory if needed.  
            FileUtilities.ForceDelete(targetFileName);
            FileStream targetStream = File.Open(targetFileName, FileMode.Create);
            StreamUtilities.CopyStream(sourceStream, targetStream);
            targetStream.Close();
            return true;
        }
    }
}