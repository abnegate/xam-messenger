using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger2.Data
{
    class Chat : DataNode
    {
        public string LastMessageId { get; set; }
        public List<string> MessageIds { get; set; }
    }
}
