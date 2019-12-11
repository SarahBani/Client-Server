using UserInterface.WPFClient.ServiceReferences;
using UserInterface.WPFClient.Commands;
using UserInterface.WPFClient.Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UserInterface.WPFClient.ViewModels
{
    public class MainViewModel
    {

        #region Properties

        public NumberConvertorModel NumberConvertorModel { get; set; }

        private readonly UpdateCommand _changeInputCommand;
        public ICommand ChangeInputCommand => this._changeInputCommand;

        private CancellationTokenSource _cancellationTokenSource;

        private ConvertorServiceReference _convertorServiceReference;

        #endregion /Properties

        #region Constructors

        public MainViewModel()
        {
            this.NumberConvertorModel = new NumberConvertorModel();
            this._changeInputCommand = new UpdateCommand(OnChangeInputAsync);
            this._convertorServiceReference = new ConvertorServiceReference();
        }

        #endregion /Constructors

        #region Methods

        private void OnChangeInputAsync(object parameter)
        {
            if (this._cancellationTokenSource != null)
            {
                this._cancellationTokenSource.Cancel();
                this._cancellationTokenSource.Dispose();
            }
            this.NumberConvertorModel.SetBusy();
            this._cancellationTokenSource = new CancellationTokenSource();
            ConvertNumberToWord(this._cancellationTokenSource.Token).ConfigureAwait(false);
        }

        private async Task ConvertNumberToWord(CancellationToken token)
        {
            try
            {
                string word = await this._convertorServiceReference.GetConvertedWordAsync(this.NumberConvertorModel.Input);
                token.ThrowIfCancellationRequested();
                this.NumberConvertorModel.SetOutput(word);
            }
            catch (OperationCanceledException)
            {
                // Do nothing
            }
            catch (Exception ex)
            {
                this.NumberConvertorModel.SetError(ex.Message);
            }
        }

        #endregion /Methods

    }
}
