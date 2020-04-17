// Code written by Popescu Cristina
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommonServiceLocator;
using Desktop.Helpers;
using Desktop.Models;
using Prism.Regions;

namespace Desktop.ViewModels
{
    public abstract class AbstractViewModel : INotifyPropertyChanged, INavigationAware
	{
		#region Properties
		public CurrentUser CurrentUser { get; }

		public AppRegionManager RegionManager { get; }
		#endregion


		#region ctor
		public AbstractViewModel()
		{
			CurrentUser = ServiceLocator.Current.TryResolve<CurrentUser>();
			RegionManager = ServiceLocator.Current.TryResolve<AppRegionManager>();;
        }
		#endregion


		#region INotifyPropertyChanged implementation
		public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string name = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

        public bool ChangeAndNotify<T>(ref T backingFieldValue, T newValue, [CallerMemberName] string propertyName = null)
        {
            return ChangeAndNotify(ref backingFieldValue, newValue, null, propertyName);
        }

        public bool ChangeAndNotify<T>(ref T backingFieldValue, T newValue, IEqualityComparer<T> comparer, [CallerMemberName] string propertyName = null)
        {
            bool areDifferent;
            if (comparer != null)
            {
                areDifferent = !comparer.Equals(backingFieldValue, newValue);
            }
            else
            {
                areDifferent = !Equals(backingFieldValue, newValue);
            }

            if (areDifferent)
            {
                backingFieldValue = newValue;
                OnPropertyChanged(propertyName);
            }

            return areDifferent;
        }
        #endregion


        #region INavigationAware implementation
        public void OnNavigatedTo(NavigationContext navigationContext) { }

		public void OnNavigatedFrom(NavigationContext navigationContext) { }

		public bool IsNavigationTarget(NavigationContext navigationContext) => false;
		#endregion
	}
}
