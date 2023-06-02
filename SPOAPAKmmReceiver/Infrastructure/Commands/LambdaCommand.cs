using System;
using SPOAPAKmmReceiver.Infrastructure.Commands.Base;

namespace SPOAPAKmmReceiver.Infrastructure.Commands
{
    public class LambdaCommand : Command
    {
        private readonly Func<object, bool> _CanExecute;
        private readonly Action<object> _Execute;

        public LambdaCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _Execute = execute;
            _CanExecute = canExecute;
        }

        public override void Execute(object parameter)
        {
            if (CanExecute(parameter))
                _Execute(parameter);
        }

        public override bool CanExecute(object parameter)
        {
            return _CanExecute?.Invoke(parameter) ?? true;
        }
    }
}