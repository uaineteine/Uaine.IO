namespace Uaine.IO.Checksum
{
    public class checksum
    {
        private int type;
        public int Type => type;
        private byte[] hash;
        public byte[] ChecksumHash => hash;
        private string checkstring;
        public string ChecksumString => checkstring;

        public checksum(int type, byte[] hash, string checkstring)
        {
            this.type = type;
            this.hash = hash;
            this.checkstring = checkstring;
        }

        public static bool Equals(checksum lhs, checksum rhs)
        {
            if (lhs.type == rhs.type && lhs.hash == rhs.hash)
                return true;
            else
                return false;
        }
    }
}
