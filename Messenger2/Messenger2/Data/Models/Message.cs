using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger2.Data
{
    class Message : DataNode
    {
        string Text { get; set; }
        DateTime Timestamp { get; set; }
        DateTime ReadtAt { get; set; }
        bool IsMedia { get; set; }
    }
}
