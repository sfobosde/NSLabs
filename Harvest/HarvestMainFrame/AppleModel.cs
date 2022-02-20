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

		// Разрешение на падения яблока.
		bool isAppleAbleToFall;

		// Делегат и событие о том что яблоко упало на землю.
		public delegate void AppleFalledOnGround();
		public event AppleFalledOnGround AppleFalled;

		// Делегат и событие о необходимости перерисовки.
		public delegate void CoordinatesChanged();
		public event CoordinatesChanged ChangingCoordinates;

		// Поток для вычисления координат яблока.
		Thread calculateCoordinatesThread;

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
			while(isAppleAbleToFall)
			{
				// Проверяем не упадет ли яблоко сквозь землю (не достигли ли координат края формы).
				if (_yAxesCoordinate + _appleRadius < _groundLevel)
				{
					// Продолжаем падать.
					_yAxesCoordinate += _fallingSpeed;

					// Ждем 0,1 секунды и запрашиваем перерисовку.
					Thread.Sleep(10);
					ChangingCoordinates();
				}
				else
				{
					// Останавливаем поток.
					isAppleAbleToFall = false;

					// Извещаем о падении.
					AppleFalled();
				}
			}
		}

		// Обработчик события остановки падения яблока.
		public void StopFalling()
		{
			// Запрещаем падать яблоку и поток остановится.
			isAppleAbleToFall = false;
		}

		// Получить данные о модели.
		public (int xAxesCoordinate, int yAxesCoordinate, int radius) GetParamsData()
		{
			return (_xAxesCoordinate, _yAxesCoordinate, _appleRadius);
		}

		// Начинаем падение.
		public void StartFalling()
		{
			// Разрешаем падение.
			isAppleAbleToFall = true;

			// Инициализируем и запускаем поток.
			calculateCoordinatesThread = new Thread(new ThreadStart(ChangeAppleCoordinates));
			calculateCoordinatesThread.Start();
		}
	}
}
