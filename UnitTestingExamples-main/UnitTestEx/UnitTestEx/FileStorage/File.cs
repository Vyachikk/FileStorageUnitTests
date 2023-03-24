﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestEx
{
    public class File
    {
        private string extension;
        private string filename;
        private string content;
        private double size;

        /**
         * Construct object with passed filename and content, set extension based
         * on filename and calculate size as half content length.
         * @param filename File name (mandatory) with extension (optional), without directory tree (path separators:
         *                 https://en.wikipedia.org/wiki/Path_(computing)#Representations_of_paths_by_operating_system_and_shell)
         * @param content File content (could be empty, but must be set)
         */
        public File(string filename, string content)
        {
            this.filename = filename;
            this.content = content;
            this.size = content.Length / 2.0;
            if (filename.Contains("."))
            {
                this.extension = filename.Split('.').Last();
            }
        }

        /**
         * Get exactly file size
         * @return File size
         */
        public double GetSize()
        {
            return size;
        }

        /**
         * Get File filename
         * @return File filename
         */
        public string GetFilename()
        {
            return filename;
        }
    }
}
