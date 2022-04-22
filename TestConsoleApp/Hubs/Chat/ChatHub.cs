using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestConsoleApp.Models;

namespace TestConsoleApp.Hubs.Chat
{
    public class ChatHub : Hub<IClient>
    {
        private static readonly ConcurrentDictionary<string, User> _Connections =
            new ConcurrentDictionary<string, User>();

        public bool Login(string loginUserName)
        {
            if (!ConnectionsDictionaryIsContainUser(loginUserName))
            {
                User loginUser = new User
                {
                    ConnectionId = Context.ConnectionId,
                    UserName = loginUserName,
                };

                if (_Connections.Values.FirstOrDefault(x => x.UserName == loginUserName) != null)
                    return false;
                if (!_Connections.TryAdd(loginUser.ConnectionId, loginUser))
                    return false;

                Console.WriteLine($"+++++{loginUser.UserName} залогинился на сервере!");

                Clients.CallerState.UserName = loginUser.UserName;
                Clients.Others.ParticipantLogin(loginUser);

                return true;
            }

            Console.WriteLine($"+++++ {loginUserName} уже существует в пользовательском словаре! Вызываемый метод: {nameof(Login)}");

            return false;
        }

        public List<User> GetLoggedUsers()
        {
            return new List<User>(_Connections.Values);
        }

        public void Logout()
        {
            string loggedOutUserName = Clients.CallerState.UserName;

            if (!string.IsNullOrEmpty(loggedOutUserName))
            {
                _Connections.TryRemove(Context.ConnectionId, out _);
                Clients.Others.ParticipantLogout(loggedOutUserName);
                Console.WriteLine($"----- {loggedOutUserName} отключился от сервера!");
            }
            else
            {
                Console.WriteLine(
                    $"----- Имя пользователя вызывающего абонента не может быть указано в {nameof(Logout)} методе! Вызываемый метод: {nameof(Logout)}");
            }
        }

        public void BroadcastChat(string message, DateTime messagePostedDateTime, TimeSpan minDisplayTime)
        {
            if (!string.IsNullOrEmpty(message))
            {
                Clients.Others.BroadcastMessage(Context.ConnectionId, message, messagePostedDateTime, minDisplayTime);
            }
            else
            {
                Console.WriteLine($"----- Имя пользователя вызывающего абонента не может быть указано или сообщенеие пустое в {nameof(BroadcastChat)} методе! Вызываемый метод: {nameof(BroadcastChat)}");
            }
        }

        public void UnicastNotification(string recipientId, string message, DateTime messagePostedDateTime, TimeSpan minDisplayTime)
        {
            if (!string.IsNullOrEmpty(message) &&
                recipientId != Clients.CallerState.UserName &&
                ConnectionsDictionaryIsContainUser(recipientId))
            {
                _Connections.TryGetValue(recipientId, out User recipientUser);

                if (recipientUser != null)
                {
                    Clients.Client(recipientUser.ConnectionId).UnicastNotification(Context.ConnectionId, message, messagePostedDateTime, minDisplayTime);
                }
                else
                {
                    Console.WriteLine($"----- Recipient user cannot be specified in {nameof(UnicastNotification)} method!" +
                                      $" Caller Method: {nameof(UnicastNotification)}");
                }
            }
            else
            {
                Console.WriteLine("----- Caller state username cannot be specified or message is empty or recipient not found" +
                                  $" in {nameof(UnicastNotification)} method! Caller Method: {nameof(UnicastNotification)}");
            }
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            KeyValuePair<string, User> connection = GetCallerConnectionFromConnections();

            if (!connection.Equals(default(KeyValuePair<string, User>)))
            {
                Clients.Others.ParticipantDisconnection(connection.Key);

                Console.WriteLine($"<> {connection.Value.UserName} disconnected from the server! ConnectionId: {connection.Key}");
            }
            else
            {
                Console.WriteLine("----- Caller state user not found in the users list" +
                                  $" in {nameof(OnDisconnected)} method! Caller Method: {nameof(OnDisconnected)}");
            }

            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            KeyValuePair<string, User> connection = GetCallerConnectionFromConnections();

            if (!connection.Equals(default(KeyValuePair<string, User>)))
            {
                Clients.Others.ParticipantReconnection(connection.Key);

                Console.WriteLine($"== {connection.Value.UserName} reconnected to server! ConnectionId: {connection.Key}");
            }
            else
            {
                Console.WriteLine("----- Caller state user not found in the users list" +
                                  $" in {nameof(OnReconnected)} method! Caller Method: {nameof(OnReconnected)}");
            }

            return base.OnReconnected();
        }

        #region PRIVATE Helper Methods

        private bool ConnectionsDictionaryIsContainUser(string userName) =>
            _Connections.ContainsKey(userName);

        private KeyValuePair<string, User> GetCallerConnectionFromConnections() =>
            _Connections.SingleOrDefault(x => x.Key == Context.ConnectionId);

        #endregion
    }
}
