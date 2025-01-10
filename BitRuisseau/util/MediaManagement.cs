﻿using BitRuisseau.Classes;
using BitRuisseau.Classes.envelops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BitRuisseau.util
{
    public class MediaManagement
    {
        string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\medias\\";

        /// <summary>
        /// Converts the files that people send in a real file
        /// </summary>
        /// <param name="filesender"></param>
        public void ConvertBase64ToMedia(FileSender filesender)
        {
            Media media = filesender.metaData;
            byte[] file = Convert.FromBase64String(filesender.Content);
            string filePath = path + media.Title + media.Type;
            File.WriteAllBytes(filePath, file);
            MessageBox.Show("Successfull download", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /// <summary>
        /// Converts the file to a base64 to send it to others
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string ConvertMediaToBase64(string fileName)
        {
            string filePath = Path.Combine(path, fileName);
            return Convert.ToBase64String(File.ReadAllBytes(path));
        }
    }
}