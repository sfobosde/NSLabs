using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarvestMainFrame.Interfaces
{
	interface IApplesModels
	{
		// Добавление нового яблока
		void AddNewApple(AppleModel appleModel);

		void StopFallingToAll();
	}
}
