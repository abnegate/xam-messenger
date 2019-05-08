using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger2.Data
{
    class Channel : DataNode
    {
        public string LastMessageId { get; set; }
        public List<string> MessageIds { get; set; }
    }
}
