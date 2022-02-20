﻿using System;
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
		IMainForm _mainForm;
		IApplesModels _applesModels;

		public Presentor(IMainForm mainForm, IApplesModels applesModels)
		{
			// Соединяем ссылки на объекты.
			_mainForm = mainForm;
			_applesModels = applesModels;

			// Подписываемся на событие закрытия обработчиком из презентора
			_mainForm.MainFormClose += MainFormClose;
		}

		public void MainFormClose()
		{
			// Остановить потоки при закрытии формы.
		}
	}
}
