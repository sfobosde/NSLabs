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

		// Счет упавших яблок.
		int falledApplesCount;

		// Событие и делегат для оповещения моделей о остановке.
		delegate void StopingAllModels();
		event StopingAllModels StopFalling;

		public ApplesModels()
		{
			falledApplesCount = 0;
		}

		public void AddNewApple(AppleModel appleModel)
		{
			// Включаем яблоко в список.
			appleModels.Add(appleModel);

			// Подписываемся на событие остановки приложения.
			StopFalling += appleModel.StopFalling;

			// Подписываемся на события падения яблока на землю.
			appleModel.AppleFalled += OnAppleFalled;
		}

		// Обработчик события падения какого то из яблок на землю.
		public void OnAppleFalled()
		{
			// На данный момент упало меньше 10 яблок.
			if (falledApplesCount < 10 )
			{
				falledApplesCount++;
			}
			else
			{
				// Упало 10 яблок.
				falledApplesCount = 0;

				// Вызыываем "сборку" урожая"
			}
		}

		// Остановка падения яблок (при закрытии приложения)
		public void StopFallingToAll()
		{
			// Отправляем всем яблокам оповещения об остановке
			StopFalling();
		}
	}
}
