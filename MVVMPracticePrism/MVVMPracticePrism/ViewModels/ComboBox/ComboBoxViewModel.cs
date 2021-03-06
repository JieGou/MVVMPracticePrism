﻿using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace MVVMPracticePrism.ViewModels
{
    public class ComboBoxViewModel : BindableBase
    {
        public DelegateCommand<SelectionChangedEventArgs> SwitchItemCmd { get; private set; }

        private ObservableCollection<Person> _CmbItems = new ObservableCollection<Person>();
        public ObservableCollection<Person> CmbItems
        {
            get => _CmbItems;
            set => SetProperty(ref _CmbItems, value);
        }

        private string _SelectedText;
        public string SelectedText
        {
            get => _SelectedText;
            set => SetProperty(ref _SelectedText, value);
        }

        public ComboBoxViewModel()
        {
            SwitchItemCmd = new DelegateCommand<SelectionChangedEventArgs>(Switch);

            for (int i = 0; i < 10; i++)
            {
                CmbItems.Add(new Person { Name = $"Hello {i}", LName = "Bye!" });
            }

            DefaultItem = "Hello 3";
        }

        private void Switch(SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0)
            {
                return;
            }

            if (e.AddedItems[0] is Person item)
            {
                SelectedText = item.Name;
            }
        }

        #region Default Item Selected
        private string _DefaultItem;
        public string DefaultItem
        {
            get => _DefaultItem;
            set => SetProperty(ref _DefaultItem, value);
        }
        #endregion
    }
}
