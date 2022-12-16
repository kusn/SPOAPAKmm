using System.Windows;
using SPOAPAKmmReceiver.Infrastructure.Commands.Base;

namespace SPOAPAKmmReceiver.Infrastructure.Commands
{
    public class CloseAppCommand : Command
    {
        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            Application.Current.Shutdown();
        }
    }
}