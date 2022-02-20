using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarvestMainFrame.Interfaces
{
	// Делегат для события закрытия формы.
	public delegate void MainFormClosing();

	interface IMainForm
	{
		// Событие закрытия формы.
		event MainFormClosing MainFormClose;

		// Получим данные о размерах окна.
		(int windowHeight, int windowWight) GetWindowSize();

		// Перерисовка окна.
		void RedrawForm(List<(int xAxesCoordinate, int yAxesCoordinate, int radius)> modelParams);
	}
}
