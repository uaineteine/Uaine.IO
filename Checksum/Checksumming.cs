using System;
using System.IO;
using System.Security.Cryptography;

namespace Uaine.IO.Checksum
{
    public static class Checksumming
    {
        public static checksum checkFile(string filename, int type)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    byte[] hash = md5.ComputeHash(stream);
                    string checkstring = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                    checksum newChecksum = new checksum(type, hash, checkstring);
                    return newChecksum;
                }
            }
        }
    }
}
