using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace M2Task17._1
{
    /// <summary>
    /// Логика взаимодействия для IndicatorRGB.xaml
    /// </summary>
    public partial class IndicatorRGB : UserControl
    {
        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register(
            nameof(Color),
            typeof(Color),
            typeof(IndicatorRGB),
            new FrameworkPropertyMetadata(
                Colors.Black,
                0,
                new PropertyChangedCallback(OnColorChanged)));

        private static void OnColorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)                    
        {
            Color newColor = (Color)e.NewValue;
            IndicatorRGB colorpicker = (IndicatorRGB)sender;
            colorpicker.Red = newColor.R;
            colorpicker.Green = newColor.G;
            colorpicker.Blue = newColor.B;
        }

        private static void OnColorRGBChanged(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            IndicatorRGB colorPicker = (IndicatorRGB)sender;
            Color color = colorPicker.Color;
            if (e.Property == RedProperty)
                color.R = (byte)e.NewValue;
            else if (e.Property == GreenProperty)
                color.G = (byte)e.NewValue;
            else if (e.Property == BlueProperty)
                color.B = (byte)e.NewValue;
            colorPicker.Color = color;
        }

        public static DependencyProperty RedProperty = DependencyProperty.Register(nameof(Red), typeof(byte), typeof(IndicatorRGB),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));

        public static DependencyProperty GreenProperty = DependencyProperty.Register(nameof(Green), typeof(byte), typeof(IndicatorRGB),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));

        public static DependencyProperty BlueProperty = DependencyProperty.Register(nameof(Blue), typeof(byte), typeof(IndicatorRGB),
                 new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));
         
        public Color Color
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }
        public byte Red
        {
            get => (byte)GetValue(RedProperty);
            set => SetValue(RedProperty, value);
        }
        public byte Green
        {
            get => (byte)GetValue(GreenProperty);
            set => SetValue(GreenProperty, value);
        }
        public byte Blue
        {
            get => (byte)GetValue(BlueProperty);
            set => SetValue(BlueProperty, value);
        }


        public static readonly RoutedEvent ColorChangedEvent = EventManager.RegisterRoutedEvent("ColorChanged", RoutingStrategy.Bubble,
        typeof(RoutedPropertyChangedEventHandler<Color>), typeof(ColorPicker));

        public event RoutedPropertyChangedEventHandler<Color> ColorChanged
        {
            add { AddHandler(ColorChangedEvent, value); }
            remove { RemoveHandler(ColorChangedEvent, value); }
        }
        public IndicatorRGB()
        {
            InitializeComponent();
        }
    }
}
