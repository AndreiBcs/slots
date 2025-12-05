using Avalonia.Controls;
using System;
using System.Collections.Generic;

namespace JocDePacanele;

public partial class MainWindow : Window
{
    private Random _random = new();
    private List<(string emoji, string name)> _slots = new()
    {
        ("🍎", "Apple"),
        ("🍊", "Orange"),
        ("🍋", "Lemon")
    };

    public MainWindow()
    {
        InitializeComponent();
    }

    private void OnSpinClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (sender is not Button button) return;
        button.IsEnabled = false;

        // Generate random results for each slot
        int result1 = _random.Next(3);
        int result2 = _random.Next(3);
        int result3 = _random.Next(3);

        // Update UI
        if (Slot1 is TextBlock slot1) slot1.Text = _slots[result1].emoji;
        if (Slot2 is TextBlock slot2) slot2.Text = _slots[result2].emoji;
        if (Slot3 is TextBlock slot3) slot3.Text = _slots[result3].emoji;

        // Check for win
        bool isWin = result1 == result2 && result2 == result3;
        string resultMessage = isWin 
            ? $"🎉 YOU WIN! Three {_slots[result1].name}s!" 
            : $"Try again! {_slots[result1].name} - {_slots[result2].name} - {_slots[result3].name}";

        if (ResultText is TextBlock resultText)
        {
            resultText.Text = resultMessage;
            resultText.Foreground = new Avalonia.Media.SolidColorBrush(
                isWin ? Avalonia.Media.Colors.Green : Avalonia.Media.Colors.Red);
        }

        button.IsEnabled = true;
    }

    private void OnResetClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (Slot1 is TextBlock slot1) slot1.Text = "🍎";
        if (Slot2 is TextBlock slot2) slot2.Text = "🍊";
        if (Slot3 is TextBlock slot3) slot3.Text = "🍋";
        if (ResultText is TextBlock resultText) resultText.Text = "";
    }
}