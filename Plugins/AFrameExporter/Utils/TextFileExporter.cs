using System.Collections;
using System.Collections.Generic;

using System;
using System.IO;

public class TextFileExporter
{
    
    public static void SaveTextFile(string path,string fileName, string content)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        File.WriteAllText(path + "/" + fileName + ".html",content);
    }

}
