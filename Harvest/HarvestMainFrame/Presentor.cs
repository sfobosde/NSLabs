using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarvestMainFrame.Interfaces;
using System.Threading;

namespace HarvestMainFrame
{
	class Presentor
	{
		// Создаем внутренний объект интерфейса формы, чтобы можно было ей управлять из презентора.
		IMainForm _mainForm;
		IApplesModels _applesModels;

		// Поток, функция которого будет генерировать яблоки.
		Thread appleGeneratingThread;

		// Время задержки между созданиями двух яблок.
		int appleGenratingPauseTime;

		// Проверка на возможность генерации.
		bool isAbleToGenerateModels;

		// Размеры окна.
		int windowHeight;
		int windowWight;

		public Presentor(IMainForm mainForm, IApplesModels applesModels)
		{
			// Соединяем ссылки на объекты.
			_mainForm = mainForm;
			_applesModels = applesModels;

			// Подписываемся на событие закрытия обработчиком из презентора
			_mainForm.MainFormClose += MainFormClose;

			// Получим размеры окна.
			(windowHeight, windowWight) = _mainForm.GetWindowSize();

			// Задержка между созданиями двух яблок - 2 секунды.
			appleGenratingPauseTime = 2000;

			// Разрешаем генерацию моделей.
			isAbleToGenerateModels = true;

			// Начинаем создание яблок через поток.
			appleGeneratingThread = new Thread(new ThreadStart(StartGenerateAppleModels));
			appleGeneratingThread.Start();
		}

		// Остановить потоки при закрытии формы.
		public void MainFormClose()
		{
			// Останавливаем поток генерации моделей.
			isAbleToGenerateModels = false;

			// Останавливаем модели.
			_applesModels.StopFallingToAll();
		}

		public void StartGenerateAppleModels()
		{
			while(isAbleToGenerateModels)
			{
				// Создаем новое яблоко.
				_applesModels.AddNewApple(new AppleModel(
					400, 
					50, 
					20, 
					20,
					windowHeight));

				Thread.Sleep(appleGenratingPauseTime);
			}
		}
	}
}
