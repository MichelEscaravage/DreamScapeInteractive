using DreamScapeInteractive.Data.Classes;
using DreamScapeInteractive.Dialogues;
using DreamScapeInteractive.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DreamScapeInteractive
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CatalogusPage : Page
    {
        private readonly AppDbContext _context = new AppDbContext();
        private FilterState _currentFilters = new FilterState();

        public CatalogusPage()
        {
            this.InitializeComponent();
            LoadItems();
            if (!User.LoggedInUser.IsAdmin)
            {
                AddItemButton.Visibility = Visibility.Collapsed;
            }
        }

        private void ItemCatalogusGrid_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            ItemCatalogusScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
        }

        private void ItemCatalogusGrid_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            ItemCatalogusScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
        }
        public void LoadItems()
        {
            var items = _context.Items
                 .Include(i => i.MagicProperty)
                 .Include(i => i.Type)
                 .ToList();

            var magicProperties = items
                .Where(i => i.MagicProperty != null)
                .Select(i => i.MagicProperty)
                .Distinct()
                .ToList();

            ItemCatalogusGrid.ItemsSource = items;
            FilterBox.ItemsSource = magicProperties;
            FilterBox.DisplayMemberPath = "Name";
        }

        public void LoadFilteredItems(FilterState filters)
        {
            var filteredItems = _context.Items.AsQueryable();

            if (!string.IsNullOrEmpty(filters.MagicProperty))
            {
                filteredItems = filteredItems.Where(i => i.MagicProperty.Name == filters.MagicProperty);
            }

            if (!string.IsNullOrEmpty(filters.ItemNameOrType))
            {
                filteredItems = filteredItems.Where(i =>
                i.Name.Contains(filters.ItemNameOrType) ||
                i.Type.Name.Contains(filters.ItemNameOrType));
            }

            if (filters.Rarity.HasValue)
            {
                filteredItems = filteredItems.Where(i => i.Rarity >= filters.Rarity);
            }

            if (filters.Power.HasValue)
            {
                filteredItems = filteredItems.Where(i => i.Power >= filters.Power);
            }

            if (filters.Speed.HasValue)
            {
                filteredItems = filteredItems.Where(i => i.Speed >= filters.Speed);
            }

            if (filters.Durability.HasValue)
            {
                filteredItems = filteredItems.Where(i => i.Durability >= filters.Durability);
            }

            ItemCatalogusGrid.ItemsSource = filteredItems.ToList();
        }

        private void SearchItemsBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = SearchItemsBox.Text;
            _currentFilters.ItemNameOrType = filter;
            LoadFilteredItems(_currentFilters);
        }

        private void FilterBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listbox = (ListBox)sender;
            var selectedItems = listbox.SelectedItems.Cast<Magic_Property>().ToList();

            if (selectedItems.Any())
            {
                var selectedMagicProperty = selectedItems.First();
                _currentFilters.MagicProperty = selectedMagicProperty.Name;
            }
            else
            {
                _currentFilters.MagicProperty = null;
            }
            LoadFilteredItems(_currentFilters);
        }


        private void FilterSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            var slider = (Slider)sender;
            var value = e.NewValue;

            if (slider.Name.Contains("Rarity"))
            {
                _currentFilters.Rarity = value;
            }
            else if (slider.Name.Contains("Power"))
            {
                _currentFilters.Power = value;
            }
            else if (slider.Name.Contains("Speed"))
            {
                _currentFilters.Speed = value;
            }
            else if (slider.Name.Contains("Durability"))
            {
                _currentFilters.Durability = value;
            }

            LoadFilteredItems(_currentFilters);
        }

        private void ResetFiltersButton_Click(object sender, RoutedEventArgs e)
        {
            _currentFilters = new FilterState();
            FilterBox.SelectedItem = null;

            DurabilitySlider.Value = 0;
            SpeedSlider.Value = 0;
            PowerSlider.Value = 0;
            RaritySlider.Value = 0;

            LoadItems();
        }

        private async void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            EditOrAddItemDialogue contentDialog = new EditOrAddItemDialogue(_context, null)
            {
                XamlRoot = this.XamlRoot
            };

            await contentDialog.ShowAsync();
            LoadItems();
        }

        private async void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Item selectedItem = (sender as Button).CommandParameter as Item;

            EditOrAddItemDialogue contentDialog = new EditOrAddItemDialogue(_context, selectedItem)
            {
                XamlRoot = this.XamlRoot
            };

            await contentDialog.ShowAsync();
            LoadItems();

        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Item selectedItem = (sender as Button).CommandParameter as Item;
            if (selectedItem != null)
            {
                var confirmDialog = new ContentDialog()
                {
                    Title = $"Delete {selectedItem.Name}",
                    Content = $"Are you sure you want to delete {selectedItem.Name}",
                    PrimaryButtonText = "Delete",
                    CloseButtonText = "Cancel",
                    DefaultButton = ContentDialogButton.Close,
                    XamlRoot = this.XamlRoot
                };

                var result = await confirmDialog.ShowAsync();
                if (result == ContentDialogResult.Primary)
                {
                    var gameToDelete = await _context.Items.FindAsync(selectedItem.Id);

                    _context.Items.Remove(gameToDelete);
                    await _context.SaveChangesAsync();

                    LoadItems();
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
            {
                if (!User.LoggedInUser.IsAdmin)
                {
                    User.LoggedInUser = null;
                }
                this.Frame.GoBack();
            }
        }

        private void DeleteButton_Loaded(object sender, RoutedEventArgs e)
        {
            var deleteButton = (Button)sender;
            if (!User.LoggedInUser.IsAdmin)
            {
                deleteButton.Visibility = Visibility.Collapsed;
            }
        }

        private void EditButton_Loaded(object sender, RoutedEventArgs e)
        {
            var editButton = (Button)sender;
            if (!User.LoggedInUser.IsAdmin)
            {
                editButton.Visibility = Visibility.Collapsed;
            }
        }

        private void BackButton_Loaded(object sender, RoutedEventArgs e)
        {
            if (!User.LoggedInUser.IsAdmin)
            {
                BackButton.Content = "Logout";
            }
        }
    }
}
