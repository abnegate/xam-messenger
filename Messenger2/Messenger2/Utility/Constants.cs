using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger2.Utility
{
    public static class Constants
    {
        public static class Firebase
        {
            public const string FIREBASE_URL = "test";

            public static Dictionary<Tables, string> TABLES = new Dictionary<Tables, string>() {
                { Tables.USERS, "users" },
                { Tables.CHATS, "chats" }
            };

            public enum Tables
            {
                USERS,
                CHATS,
                MESSAGES
            }
        }
    }
}
