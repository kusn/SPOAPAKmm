using System;

namespace WpfAppTest.SimplePackets
{
    [Serializable]
    public class ChatPacket
    {
        public string Username { get; set; }
        public string Message { get; set; }
        public string UserColor { get; set; }
    }
}
