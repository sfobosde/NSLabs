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

		// Событие на запрос перерисовки окна.
		public event RedrawingModels RedrawModels;

		public ApplesModels()
		{
			falledApplesCount = 0;
		}

		public void AddNewApple(AppleModel appleModel)
		{
			// Подписываемся на событие остановки приложения.
			StopFalling += appleModel.StopFalling;

			// Подписываемся на события падения яблока на землю.
			appleModel.AppleFalled += OnAppleFalled;

			// Подписываемся на событие изменения координат.
			appleModel.ChangingCoordinates += CoordinatesChanged;

			// Включаем яблоко в список.
			appleModels.Add(appleModel);

			// Начинаем падение яблок.
			appleModel.StartFalling();
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

				// Вызыываем "сборку" урожая".
			}
		}

		// Остановка падения яблок (при закрытии приложения).
		public void StopFallingToAll()
		{
			// Отправляем всем яблокам оповещения об остановке.
			StopFalling();
		}

		// Обработчик события изменения координат.
		public void CoordinatesChanged()
		{
			RedrawModels();
		}

		// Получение данных о моделях.
		public List<(int xAxesCoordinate, int yAxesCoordinate, int radius)> GetModelsParams()
		{
			// Внутренний список, в него будем вносить все.
			List<(int xAxesCoordinate, int yAxesCoordinate, int radius)> modelParams = 
				new List<(int xAxesCoordinate, int yAxesCoordinate, int radius)>();

			foreach (var appleModel in appleModels)
			{
				modelParams.Add(appleModel.GetParamsData());
			}

			return modelParams;
		}
	}
}
