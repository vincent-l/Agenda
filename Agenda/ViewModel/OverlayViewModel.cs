using System.Windows;

namespace WpfApplication5.ViewModel
{
    public class OverlayViewModel : ViewModelBase
    {
        private Visibility _visibility = Visibility.Collapsed;

        public Visibility Visibility
        {
            get
            {
                return _visibility;
            }
            set
            {
                if (value == _visibility)
                    return;

                _visibility = value;

                base.RaisePropertyChanged("Visibility");
            }
        }
    }
}
