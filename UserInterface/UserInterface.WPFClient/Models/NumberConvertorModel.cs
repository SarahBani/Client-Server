namespace UserInterface.WPFClient.Models
{
    public class NumberConvertorModel : BaseModel
    {

        #region Properties

        public string Input { get; set; }

        private string _output;
        public string Output
        {
            get => this._output;
            private set => SetProperty(ref this._output, value);
        }

        private bool _hasError;
        public bool HasError
        {
            get => this._hasError;
            private set => SetProperty(ref this._hasError, value);
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => this._isBusy;
            private set => SetProperty(ref this._isBusy, value);
        }

        #endregion /Properties

        #region Methods

        public void SetOutput(string output)
        {
            this.Output = output;
            this.HasError = false;
            this.IsBusy = false;
        }

        public void SetError(string message)
        {
            this.Output = message;
            this.HasError = true;
            this.IsBusy = false;
        }

        public void SetBusy()
        {
            this.IsBusy = true;
        }

        #endregion /Methods

    }
}
