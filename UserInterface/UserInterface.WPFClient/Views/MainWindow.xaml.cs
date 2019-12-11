using UserInterface.WPFClient.ViewModels;
using System.Windows;

namespace UserInterface.WPFClient.Views
{
    public partial class MainWindow : Window
    {

        #region Properties

        public MainViewModel NumberViewModel { get; set; }

        #endregion /Properties

        #region Constructors

        public MainWindow()
        {
            var viewModel = new MainViewModel();
            this.DataContext = viewModel;
            InitializeComponent();
        }

        #endregion /Constructors

    }
}
