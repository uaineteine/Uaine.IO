using System;
using System.IO;
using Uaine.Platforms;

namespace Uaine.IO
{
    public class SettingsFile : FileData
    {
        public SettingsFile(string filename) : base(getFN(filename))
        {

        }
        public static string getFN(string file)
        {
            string output = file;

            if (platforms.isDesktop())
            {
                output = file;
            }
            else
            {
                switch (platforms.currentPlatform)
                {
                    case platforms.android:
                        output = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData), file);
                        break;

                    case platforms.ios:
                        output = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), file);
                        break;
                }
            }

            return output;
        }
    }
}
