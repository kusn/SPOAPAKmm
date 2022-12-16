namespace SPOAPAKmmReceiver.Interfaces
{
    public interface INetConnection
    {
        public delegate void Execute();

        void StartListen(Execute execute);
        void StopListen();
        void GetConnectionSettings(string sectionKey);
    }
}