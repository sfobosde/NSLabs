using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarvestMainFrame.Interfaces
{
	// Перерисовка окна.
	delegate void RedrawingModels();

	interface IApplesModels
	{
		// Добавление нового яблока
		void AddNewApple(AppleModel appleModel);

		// Остановка потоков моделей.
		void StopFallingToAll();

		// Событие запроса на перерисовку.
		event RedrawingModels RedrawModels;

		// Получение параметров объектов.
		List<(int xAxesCoordinate, int yAxesCoordinate, int radius)> GetModelsParams();
	}
}
