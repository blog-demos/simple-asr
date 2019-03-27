
using proxy_asr_baidu;
using proxy_asr_ifly;
using proxy_asr_usc;
using System;
using System.Windows;

namespace simple_asr
{
    public partial class MainWindow : Window
    {
        private string appKey = "";
        private string appSecret = "";

        public MainWindow()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings(Providers p=Providers.iFly)
        {
            IniFile ini = new IniFile("settings.ini");
            switch (p)
            {
                case Providers.iFly:
                    appKey = ini.ReadString("iFly", "appid");
                    break;
                case Providers.Baidu:
                    appKey = ini.ReadString("baidu", "appkey");
                    appSecret = ini.ReadString("baidu", "appsecret");
                    break;
                case Providers.USC:
                    appKey = ini.ReadString("usc", "appkey");
                    appSecret = ini.ReadString("usc", "appsecret");
                    break;
            }
        }

        private void RecognitionButton_Click(object sender, RoutedEventArgs e)
        {
            if (true == iFlyRadioButton.IsChecked)
            {
                iFlyRecognition(DatapathTextBox.Text.Trim());
            }
            else if (true == BaiduRadioButton.IsChecked)
            {
                BaiduRecognition(DatapathTextBox.Text.Trim());
            }
            else if (true == UscRadioButton.IsChecked)
            {
                USCRecognition(DatapathTextBox.Text.Trim());
            }
        }

        private void iFlyRecognition(string path)
        {
            Console.WriteLine(String.Format("{0}{1}Recognition by iFly.", Environment.NewLine, Environment.NewLine));
            
            iFlyAsrProxy proxy = new iFlyAsrProxy(appKey);
            Console.WriteLine(String.Format("识别结果：{0}", proxy.Recognition(FileIO.Read(path))));
        }

        private void BaiduRecognition(string path)
        {
            Console.WriteLine(String.Format("{0}{1}Recognition by Baidu.", Environment.NewLine, Environment.NewLine));

            BaiduAsrProxy proxy = new BaiduAsrProxy(appKey, appSecret);
            Console.WriteLine(String.Format("识别结果：{0}", proxy.Recognition(FileIO.Read(path))));
        }

        private void USCRecognition(string path)
        {
            Console.WriteLine(String.Format("{0}{1}Recognition by USC.", Environment.NewLine, Environment.NewLine));

            USCAsrProxy proxy = new USCAsrProxy(appKey, appSecret);
            Console.WriteLine(String.Format("识别结果：{0}", proxy.Recognition(FileIO.Read(path))));
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (sender == iFlyRadioButton) LoadSettings(Providers.iFly);
            else if (sender == BaiduRadioButton) LoadSettings(Providers.Baidu);
            else if (sender == UscRadioButton) LoadSettings(Providers.USC);
        }
    }
}
