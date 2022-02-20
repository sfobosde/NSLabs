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
		(int windowHeight, int windowWight) GetWindowSize();
	}
}
