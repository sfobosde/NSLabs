using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HarvestMainFrame
{
	class AppleModel
	{
		// Координаты начала падения яблок, радиус, скорость падения.
		int _xAxesCoordinate;
		int _yAxesCoordinate;
		int _appleRadius;
		int _fallingSpeed;
		int _groundLevel;

		// Делегат и событие о том что яблоко упало на землю.
		public delegate void AppleFalledOnGround();
		public event AppleFalledOnGround AppleFalled;

		// Передаем в конструктор данные о яблоке.
		public AppleModel(
			int xAxesCoordinate,
			int yAxesCoordinate,
			int appleRadius,
			int fallingSpeed,
			int groundLevel)
		{
			_xAxesCoordinate = xAxesCoordinate;
			_yAxesCoordinate = yAxesCoordinate;
			_appleRadius = appleRadius;
			_fallingSpeed = fallingSpeed;
			_groundLevel = groundLevel;
		}

		// Изменение координат яблок при падении.
		public void ChangeAppleCoordinates()
		{
			// Проверяем не упадет ли яблоко сквозь землю (не достигли ли координат края формы).
			if(_yAxesCoordinate + _appleRadius < _groundLevel)
			{
				// Продолжаем падать.
				_yAxesCoordinate += _fallingSpeed;

				// Ждем 0,5 секунды.
				Thread.Sleep(500);
			}
			else
			{
				// Извещаем о падении.
				AppleFalled();
			}
		}
	}
}
