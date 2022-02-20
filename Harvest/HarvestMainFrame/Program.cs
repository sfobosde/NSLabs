using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HarvestMainFrame
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// Создали объект формы, чтобы передать его в презентор.
			// Форма наследована от интерфейса формы.
			MainForm mainForm = new MainForm();

			// Создаем объект моделей и передаем в презентор.
			// Объект основной модели наследовани от интерфейса.
			ApplesModels appleModels = new ApplesModels();

			// Создали презентор, который будет управлять моделями и формой.
			Presentor presentor = new Presentor(mainForm, appleModels);

			// Делаем запуск формы.
			Application.Run(mainForm);
		}
	}
}
