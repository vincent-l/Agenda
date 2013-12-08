using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfApplication5.View
{
    /// <summary>
    /// Interaction logic for EventFormView.xaml
    /// </summary>
    public partial class EventFormView : UserControl
    {
        double _fontHeight; 

        public EventFormView()
        {
            InitializeComponent();

            _fontHeight = notes.FontSize * notes.FontFamily.LineSpacing;
        }

        private void notes_LayoutUpdated(object sender, EventArgs e)
        {
            visualbrush.Viewport = new Rect(0, -notes.VerticalOffset, 1, _fontHeight);
        }
    }
}
