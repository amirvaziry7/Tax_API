using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tax_Api.Bussines
{
    public  class PacketsWrapper
    {
        private Object packets;
        public PacketsWrapper()
        {
        }
        public PacketsWrapper(Object packets)
        {
            this.packets = packets;
        }
        public Object getPackets()
        {
            return packets;
        }
        public void setPackets(Object packets)
        {
            this.packets = packets;
        }
    }
}

