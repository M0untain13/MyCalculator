﻿using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace СalculatorLib.ViewModels.Pages
{
    public class HomeViewModel : MvxViewModel
    {
        public IMvxCommand ResetTextCommand => new MvxCommand(ResetText);
        private void ResetText()
        {
            Text = "Hello MvvmCross";
        }

        private string _text = "Hello MvvmCross";
        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }
    }
}