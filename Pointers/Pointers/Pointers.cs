using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pointers
{
    public class Pointers
    {
        public byte start { get; set; }
        public byte[] bytes { get; set; }

        public Pointers(byte start, byte[] bytes)
        {
            this.start = start;
            this.bytes = bytes;
        }

        public List<byte> insert(List<byte> sources)
        {
            byte index = 0x00000000;
            List<byte> result = new List<byte>();
      
            foreach (byte source in sources)
            {
                if (index == start)
                {
                    foreach (byte b in bytes)
                    {
                        result.Add(b);
                    }
                }
                result.Add(source);
                index++;
            }

            return (result);
        }

        public List<byte> replace(List<byte> sources)
        {
            byte index = 0x00000000;
            bool injected = false;
            List<byte> result = new List<byte>();

            foreach (byte source in sources)
            {
                if (index == start)
                {
                    foreach (byte b in bytes)
                    {
                        result.Add(b);
                    }
                    injected = true;
                    return (result);
                }
                if (injected == false)
                {
                    result.Add(source);
                    index++;
                }
            }

            return (result);
        }
    }
}
