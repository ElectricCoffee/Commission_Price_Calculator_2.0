using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.FSharp.Core;
using Microsoft.FSharp.Collections;

namespace CommishCalculatorV2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ComboBox _additionalItems;
        public MainWindow()
        {
            InitializeComponent();
            _additionalItems = AdditionalCombo;
        }

        private void SaveMenu_Click(object sender, RoutedEventArgs e)
        {
            var price =  0.0;
            var additChar = 0.0;
            if(
                double.TryParse (PriceBox.Text, out price) 
                && 
                double.TryParse (AdditionalBox.Text, out additChar))
            {
                var strings = Logic.saveButtonClick(price, CurrencyBox.Text, _additionalItems.SelectedValue as String, additChar).ToList();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AdditionalCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _additionalItems = sender as ComboBox;
            AdditionalLabel.Content = Logic.selectionChanged(_additionalItems.SelectedValue as String, CurrencyBox.Text);
        }
    }
}
