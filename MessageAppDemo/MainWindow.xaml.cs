using System;
using System.Windows;
using System.Windows.Input;

namespace MessageAppDemo
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void ExitButton_OnClick(object sender, RoutedEventArgs e)
		{
			Environment.Exit(0);
		}

		private void Border_OnMouseDown(object sender, MouseButtonEventArgs e)
		{
			if(e.LeftButton == MouseButtonState.Pressed)
				DragMove();
		}

		private void MinimizeButton_OnClick(object sender, RoutedEventArgs e)
		{
			WindowState = WindowState.Minimized;
		}

		private void MaximizeButton_OnClick(object sender, RoutedEventArgs e)
		{
			WindowState = WindowState == WindowState.Maximized
					? WindowState.Normal
					: WindowState.Maximized;
		}
	}
}