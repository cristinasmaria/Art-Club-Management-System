using Prism.Regions;

namespace Desktop.Helpers
{
	public class AppRegionManager
	{
		public static string MainRegion = "MainRegion";

		private readonly IRegionManager _regionManager;

		public AppRegionManager(IRegionManager regionManager)
		{
			_regionManager = regionManager;
		}

		public void Load<T>()
		{
			_regionManager.RequestNavigate(MainRegion, typeof(T).Name);
		}

		public void RegisterView<T>()
		{
			_regionManager.RegisterViewWithRegion(MainRegion, typeof(T));
		}
	}
}
