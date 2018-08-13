using BeatThat.Properties;
namespace BeatThat.Controllers.Toggles
{
    public interface IToggleView : IView, IHasBool, IHasValueChangedEvent<bool> 
	{
		void SetProperty<T>(string name, T value);
	}
}

