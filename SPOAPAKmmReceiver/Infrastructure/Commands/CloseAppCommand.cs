using SPOAPAKmmReceiver.Infrastructure.Commands.Base;
using System.Windows;

namespace SPOAPAKmmReceiver.Infrastructure.Commands
{
    public class CloseAppCommand : Command
    {
        public override bool CanExecute(object? parameter) => true;
        
        public override void Execute(object? parameter)
        {
            Application.Current.Shutdown();
        }
    }
}
