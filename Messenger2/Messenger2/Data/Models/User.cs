using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger2.Data
{
    public class User : DataNode
    {
        string Email { get; set; }
        string Username { get; set; }
        string PhoroUrl { get; set; }
        DateTime LastActive { get; set; }

        List<string> ChatIds { get; set; }
        List<string> FriendIds { get; set; }
        List<string> FriendRequests { get; set; }
    }
}
