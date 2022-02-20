using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HarvestMainFrame.Interfaces;

namespace HarvestMainFrame
{
	public partial class MainForm : Form, IMainForm
	{
		// Событие из интерфейса на закрытие формы.
		public event MainFormClosing MainFormClose;

		Graphics drawingController;

		public MainForm()
		{
			InitializeComponent();

			drawingController = CreateGraphics();
		}

		// Обработчик события закрытия формы.
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			// Уведомляем через событие презентор о закрытии формы.
			MainFormClose();
		}

		// Получить размеры окна.
		public (int windowHeight, int windowWight) GetWindowSize()
		{
			return (this.Size.Height, this.Size.Width);
		}

		// Обработчик события перерисовки окна.
		public void RedrawForm(List<(int xAxesCoordinate, int yAxesCoordinate, int radius)> modelParams)
		{
			// Отчистим форму.
			Invalidate();

			lock(modelParams)
			{
				// Перебирая рисуем по шару.
				foreach (var (xAxesCoordinate, yAxesCoordinate, radius) in modelParams)
				{
					// Рисуем эллипс.
					drawingController.DrawEllipse(
						new System.Drawing.Pen(System.Drawing.Color.Red),
						new Rectangle(xAxesCoordinate, yAxesCoordinate, radius, radius));
				}
			}
		}
	}
}
