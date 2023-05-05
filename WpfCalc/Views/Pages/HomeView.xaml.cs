using System;
using System.Windows.Controls;
using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.ViewModels;
using СalculatorLib.ViewModels.Pages;

namespace WpfCalc.Views.Pages
{
    [MvxViewFor(typeof(HomeViewModel))]
    public partial class HomeView : MvxWpfView
    {
        public HomeView() => InitializeComponent();

        /// <summary>
        /// Этот метод передаёт выделенный текст вьюмодели при отпускании ЛКМ.
        /// Из-за того что SelectedText не привязывается, приходится использовать вот такой костыль... 
        /// </summary>
        /// <param name="sender"> TextBox </param>
        /// <param name="e"></param>
        /// <exception cref="ArgumentException"> sender должен быть Textbox, а DataContext - HomeViewModel </exception>
        private void TextBox_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (sender is not TextBox textBox 
                || DataContext is not HomeViewModel viewModel)
                throw new ArgumentException("sender должен быть Textbox, а DataContext - HomeViewModel");

            viewModel.SelLen = textBox.SelectionLength;
            viewModel.SelStartInd = textBox.SelectionStart;
        }
    }
}
