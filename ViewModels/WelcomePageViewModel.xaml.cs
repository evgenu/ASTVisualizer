

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AstVisualizerApp.Models;

namespace AstVisualizerApp.ViewModels {
	public partial class WelcomePageViewModel : ContentPage
{
 
	private WelcomePage _welcomePage;
    private ObservableCollection<string> _treeNodes;

	public ObservableCollection<string> TreeNodes
	{
		get => _treeNodes;
		set
		{
			_treeNodes = value;
			OnPropertyChanged();
		}
	}

	private string _debugInfoHolder;

	public string DebugInfoHolder
	{
		get => _debugInfoHolder;
		set
		{
			_debugInfoHolder = value;
			OnPropertyChanged();
		}
	}

	public WelcomePageViewModel()
	{
		TreeNodes = new ObservableCollection<string>();
		_welcomePage = new WelcomePage(TreeNodes);
		_welcomePage.LoadTreeFromDatabase();
	}


	public event PropertyChangedEventHandler PropertyChanged;

	protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
}
