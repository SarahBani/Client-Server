using System;
using System.Windows.Input;

namespace UserInterface.WPFClient.Commands
{
    public sealed class UpdateCommand : ICommand
    {

        #region Properties

        private readonly Action<object> _executeAction;

        #endregion /Properties

        #region Events

        public event EventHandler CanExecuteChanged;

        #endregion /Events

        #region Constructors

        public UpdateCommand(Action<object> executeAction)
        {
            this._executeAction = executeAction;
        }

        #endregion /Constructors

        #region Methods

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => this._executeAction(parameter);

        #endregion /Methods

    }
}
