using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarvestMainFrame.Interfaces;

namespace HarvestMainFrame
{
	class ApplesModels: IApplesModels
	{
		// Список (массив) из объектов - яблок.
		List<AppleModel> appleModels = new List<AppleModel>();

		public void AddNewApple(AppleModel appleModel)
		{
			// Включаем яблоко в список.
			appleModels.Add(appleModel);
		}
	}
}
