using System;

namespace AdapterRealExample.Devices
{
    class Program
    {
        static void Main(string[] args)
        {
            // Нам надо отрисовать изображение на бумаге и холсте
            // Запускаем класс для отрисовки
            var imageDrawer = new ImageDrawer();
          
            // Создаем класс для работы с бумажным принтером
            PaperPrinter paperPrinter = new PaperPrinter();
            // Запускаем отрисовку на бумаге
            imageDrawer.DrawWith(paperPrinter);
          
            // Теперь нужна печать на холсте
            CanvasPainter canvasPainter = new CanvasPainter();
          
            // используем адаптер
            IPrinter imagePrinter = new CanvasPainterToPrinterAdapter(canvasPainter);
            // Запускаем печать на холсте
            imageDrawer.DrawWith(imagePrinter);
            Console.Read();
        }
    }

    interface IPrinter
    {
        void Print();
    }

    interface IPainter
    {
        void Paint();
    }

    class PaperPrinter : IPrinter
    {
        public void Print()
        {
            Console.WriteLine("Печатаем на бумаге");
        }
    }

    class CanvasPainter : IPainter
    {
        public void Paint()
        {
            Console.WriteLine("Рисуем на холсте");
        }
    }

    class ImageDrawer
    {
        // Метод, запускающий печать с помощью внешнего устройства
        public void DrawWith(IPrinter printer)
        {
            printer.Print();
        }
    }

    class CanvasPainterToPrinterAdapter : IPrinter
    {
        private readonly IPainter _painter;

        public CanvasPainterToPrinterAdapter(IPainter painter)
        {
            _painter = painter;
        }

        public void Print()
        {
            _painter.Paint();
        }
    }
}