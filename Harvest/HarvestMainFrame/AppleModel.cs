using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarvestMainFrame
{
	class AppleModel
	{
		// Координаты начала падения яблок, радиус, скорость падения.
		int _xAxesCoordinate;
		int _yAxesCoordinate;
		int _appleRadius;
		int _fallingSpeed;

		// Передаем в конструктор данные о яблоке.
		public AppleModel(
			int xAxesCoordinate,
			int yAxesCoordinate,
			int appleRadius,
			int fallingSpeed)
		{
			_xAxesCoordinate = xAxesCoordinate;
			_yAxesCoordinate = yAxesCoordinate;
			_appleRadius = appleRadius;
			_fallingSpeed = fallingSpeed;
		}
	}
}
