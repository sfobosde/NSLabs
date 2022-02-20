using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarvestMainFrame.Interfaces;

namespace HarvestMainFrame
{
	class Presentor
	{
		// Создаем внутренний объект интерфейса формы, чтобы можно было ей управлять из презентора.
		IMainForm mainForm;

		public Presentor(IMainForm mainForm)
		{
			this.mainForm = mainForm;
		}
	}
}
