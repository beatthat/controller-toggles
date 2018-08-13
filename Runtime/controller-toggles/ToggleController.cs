using BeatThat.Properties;
using BeatThat.UnityEvents;
using UnityEngine.Events;

namespace BeatThat.Controllers.Toggles
{
    public class ToggleController : Controller<NoModel, IToggleView>, IHasBool, IHasValueChangedEvent<bool>
	{
		public bool m_defaultValue = false;

		public bool value { 
			get { return this.hasView? this.view.value: m_defaultValue; } 
			set {
				if (this.hasView) {
					this.view.value = value;
				}
			}
		}

		public object valueObj { get { return this.value; } }

		public UnityEvent<bool> onValueChanged { get { return m_onValueChanged != null ? m_onValueChanged: (m_onValueChanged = new BoolEvent()); } }
		public BoolEvent m_onValueChanged;

		override protected void GoController()
		{
			Bind (this.view.onValueChanged, this.onViewValueChanged);
		}

		private UnityAction<bool> onViewValueChanged { get { return m_onViewValueChangedAction != null ? m_onViewValueChangedAction: (m_onViewValueChangedAction = this.OnViewValueChanged); } }
		private UnityAction<bool> m_onViewValueChangedAction;
		private void OnViewValueChanged(bool v)
		{
			if (m_onValueChanged == null) {
				return;
			}
			m_onValueChanged.Invoke (v);
		}

	}
}

