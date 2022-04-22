using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsoleApp.Models;

namespace TestConsoleApp.Hubs.Chat
{
    public interface IClient
    {
        void ParticipantLogin(User loggedUser);

        void ParticipantLogout(string loggedOutUserName);

        void ParticipantDisconnection(string disconnectionConnectionId);

        void ParticipantReconnection(string reconnectionConnectionId);

        void BroadcastMessage(string senderConnectionId, string message, DateTime messagePostedDateTime, TimeSpan minDisplayTime);

        void UnicastMessage(string senderConnectionId, string message, DateTime messagePostedDateTime);

        void UnicastNotification(string senderConnectionId, string message, DateTime messagePostedDateTime, TimeSpan minDisplayTime);
    }
}
