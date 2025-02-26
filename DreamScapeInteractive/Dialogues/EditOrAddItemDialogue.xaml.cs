using DreamScapeInteractive.Data.Classes;
using DreamScapeInteractive.Data.Lists;
using DreamScapeInteractive.Utility;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Org.BouncyCastle.Asn1.Ess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DreamScapeInteractive.Dialogues
{
    internal sealed partial class EditOrAddItemDialogue : ContentDialog
    {
        private readonly AppDbContext _context;
        private Item _selectedItem;
        private List<Magic_Property> _magic_Properties = new List<Magic_Property>();
        private List<ItemType> _ItemTypes = new List<ItemType>();

        public EditOrAddItemDialogue(AppDbContext context, Item? selectedItem)
        {
            this.InitializeComponent();
            _context = context;
            _selectedItem = selectedItem;

            LoadItemValues();
            SetItemValues();
        }

        private void LoadItemValues()
        {
            _magic_Properties = _context.MagicProperties
                                 .Distinct()
                                 .ToList();
            _ItemTypes = _context.ItemTypes
                .Distinct()
                .ToList();
        }

        private void SetItemValues()
        {
            if (_selectedItem != null)
            {
                TitleBlock.Text = _selectedItem.Name;
                Typeblock.Text = _selectedItem.Type.Name;
                DescriptionBlock.Text = _selectedItem.Description;

                MagicPropertyListBox.SelectedValue = _selectedItem.MagicPropertyId;

                RaritySlider.Value = _selectedItem.Rarity;
                PowerSlider.Value = _selectedItem.Power;
                SpeedSlider.Value = _selectedItem.Speed;
                DurabilitySlider.Value = _selectedItem.Durability;

                AddItemPanel.Visibility = Visibility.Collapsed;
            }
            else
            {
                EditItemPanel.Visibility = Visibility.Collapsed;

                TypesListBox.ItemsSource = _ItemTypes;
                TypesListBox.DisplayMemberPath = "Name";
                TypesListBox.SelectedValuePath = "Id";
            }

            MagicPropertyListBox.ItemsSource = _magic_Properties;
            MagicPropertyListBox.DisplayMemberPath = "Name";
            MagicPropertyListBox.SelectedValuePath = "Id";

        }
        private void EditItemDialogueFrame_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            EditItemScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;

        }

        private void EditItemDialogueFrame_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            EditItemScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;

        }

        private bool IsItemTitleValid(string? title, string? description, bool isEditing)
        {
            var regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z0-9 ]+$");

            if (isEditing)
            {
                return !string.IsNullOrWhiteSpace(description) && regex.IsMatch(description);
            }
            else
            {
                return !string.IsNullOrWhiteSpace(title) && regex.IsMatch(title) &&
                       !string.IsNullOrWhiteSpace(description) && regex.IsMatch(description);
            }
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedItem != null)
            {
                var inputcontrols = new List<Control>
                {
                    DescriptionBlock,
                    RaritySlider,
                    PowerSlider,
                    SpeedSlider,
                    DurabilitySlider
                };

                bool hasEmptyFields = FormChecker.ValidateControls(inputcontrols);

                if (hasEmptyFields)
                {

                    var Labels = new List<TextBlock>
                    {
                        RarityLabel,
                        PowerLabel,
                        SpeedLabel,
                        DurabilityLabel,
                    };

                    foreach (var label in Labels)
                    {
                        label.Foreground = new SolidColorBrush(Colors.Red);
                        label.Text += " Required to choose a value!";
                    }
                    return;
                }

                if (!IsItemTitleValid(null, DescriptionBlock.Text, true))
                {
                    DescriptionBlock.Foreground = new SolidColorBrush(Colors.Red);
                    DescriptionBlock.Text = "Invalid description!";
                    return;
                }


                _selectedItem.Description = DescriptionBlock.Text;

                if (MagicPropertyListBox.SelectedItem is Magic_Property selectedProperty)
                {
                    _selectedItem.MagicPropertyId = selectedProperty.Id;
                }
                _selectedItem.Rarity = (int)RaritySlider.Value;
                _selectedItem.Power = (int)PowerSlider.Value;
                _selectedItem.Speed = (int)SpeedSlider.Value;
                _selectedItem.Durability = (int)DurabilitySlider.Value;

                _context.Items.Update(_selectedItem);
            }
            else
            {
                var inputcontrols = new List<Control>
                {
                    TitleBox,
                    DescriptionBox,
                    TypesListBox,
                    MagicPropertyListBox,
                    RaritySlider,
                    PowerSlider,
                    SpeedSlider,
                    DurabilitySlider
                };

                bool hasEmptyFields = FormChecker.ValidateControls(inputcontrols);

                if (hasEmptyFields)
                {
                    var Labels = new List<TextBlock>
                    {
                        RarityLabel,
                        PowerLabel,
                        SpeedLabel,
                        DurabilityLabel,
                    };

                    foreach (var label in Labels)
                    {
                        label.Foreground = new SolidColorBrush(Colors.Red);
                        label.Text += " Required to choose a value!";
                    }
                    return;
                }

                if (!IsItemTitleValid(TitleBox.Text, DescriptionBox.Text, false))
                {
                    TitleBox.Text = string.Empty;
                    TitleBox.Foreground = new SolidColorBrush(Colors.Red);
                    TitleBox.PlaceholderText = "Invalid Game Name or Game Description";

                    TitleBox.Foreground = new SolidColorBrush(Colors.Red);
                    DescriptionBox.Text = string.Empty;
                    DescriptionBox.PlaceholderText = "The game name and description can only contain letters and numbers.";

                    return;
                }

                Item newItem = new Item()
                {
                    Name = TitleBox.Text,
                    TypeId = TypesListBox.SelectedIndex,
                    Description = DescriptionBox.Text,
                    MagicPropertyId = MagicPropertyListBox.SelectedIndex,
                    Rarity = (int)RaritySlider.Value,
                    Power = (int)PowerSlider.Value,
                    Speed = (int)SpeedSlider.Value,
                    Durability = (int)DurabilitySlider.Value,
                };

                _context.Items.Add(newItem);

            }


            await _context.SaveChangesAsync();
            this.Hide();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
