using BeatThat.GetComponentsExt;
using BeatThat.Properties;
using BeatThat.Properties.UnityUI;
using UnityEngine.Events;
using UnityEngine.UI;

namespace BeatThat.Controllers.Toggles
{
    public class ToggleView : View, IToggleView
	{
		public bool value {
			get {
				return (this.toggle != null) ? this.toggle.value : false;
			}
			set {
				if (this.toggle != null) {
					this.toggle.value = value; 
				}
			}
		}

		public object valueObj { get { return this.value; } } 

		public UnityEvent<bool> onValueChanged { get { return this.toggle != null ? this.toggle.onValueChanged: null; } }

		public void SetProperty<T> (string name, T value)
		{
			if (this.properties == null) {
				return;
			}
			this.properties.Set (name, value);
		}
			
		public PropertiesBase m_properties;
		public IProperties properties { get { return m_properties; } }

		public BoolProp m_toggle;
		public BoolProp toggle
		{ 
			get { 
				if (m_toggle != null || (m_toggle = GetComponent<BoolProp> ()) != null) {
					return m_toggle;
				}
					
				var b = GetComponentInChildren<Toggle> (true);
				return (b != null) ? m_toggle = b.AddIfMissing<BoolProp, ToggleValue> () : null;
			}
		}
	}
}



