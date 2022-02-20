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

		public MainForm()
		{
			InitializeComponent();
		}

		// Обработчик события закрытия формы.
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			// Уведомляем через событие презентор о закрытии формы.
			MainFormClose();
		}
	}
}
