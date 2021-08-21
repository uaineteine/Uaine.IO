using System;
using System.Collections.Generic;
using System.Text;

namespace Uaine.IO.Checksum
{
    public class checksum
    {
        private int type;
        private byte[] hash;
        private string checkstring;

        public checksum(int type, byte[] hash, string checkstring)
        {
            this.type = type;
            this.hash = hash;
            this.checkstring = checkstring;
        }
    }
}
