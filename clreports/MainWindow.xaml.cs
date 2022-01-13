using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace clreports
{
    // 2022 01 13 gg
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly int UNMI_COUNT = 4;
        private readonly int DRX_COUNT = 4;
        private readonly int JAY_COUNT = 1;
        private readonly int OC_COUNT = 4;
        private readonly int SANCTUARY_COUNT = 3;
        private readonly int MATERIAL_COUNT = 3;

        private int CharCnt = 0;
        private int CharRemain = 1;

        private int unmi = 0;
        private int drx = 0;
        private int jay = 0;
        private int overclock = 0;
        private int sanctuary = 0;
        private int material = 0;

        private int unmiRemain = 0;
        private int drxRemain = 0;
        private int jayRemain = 0;
        private int overclockRemain = 0;
        private int sanctuaryRemain = 0;
        private int materialRemain = 0;

        private int unmiMax = 0;
        private int drxMax = 0;
        private int jayMax = 0;
        private int overclockMax = 0;
        private int sanctuaryMax = 0;
        private int materialMax = 0;

        private int All = 0;
        private int AllRemain = 0;

        private Point fuckwpfstartpos;

        public MainWindow()
        {
            InitializeComponent();
            CharCnt = Properties.Settings.Default.CharCnt;
            CharTextBox.Text = CharCnt.ToString("D");
            MaxChar.Text = CharCnt.ToString("D");
            RemainChar.Text = CharRemain.ToString("D");
            SetCharCnt();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            this.Left = SystemParameters.WorkArea.Width - this.Width;
            this.Top = 0;
        }

        private void OpacitySlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.Opacity = OpacitySlider.Value;
        }

        private void MainWindow_OnPreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            fuckwpfstartpos = e.GetPosition(this);
        }

        private void MainWindow_OnPreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Pressed)
            {
                Point endPosition = e.GetPosition(this);
                Vector vector = endPosition - fuckwpfstartpos;
                this.Left += vector.X;
                this.Top += vector.Y;
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void UnmiBtn_Click(object sender, RoutedEventArgs e)
        {
            unmi++;
            unmiRemain++;
            AllRemain++;

            NowProgress.Value++;
            RemainReport.Text = AllRemain.ToString("D");
            UnmiText.Text = unmi.ToString("D");

            if (UNMI_COUNT == unmi)
                UnmiBtn.IsEnabled = false;
            if (unmiMax == unmiRemain)
                CChangeBtn.IsEnabled = false;
        }

        private void DrxBtn_Click(object sender, RoutedEventArgs e)
        {
            drx++;
            drxRemain++;
            AllRemain++;

            NowProgress.Value++;
            RemainReport.Text = AllRemain.ToString("D");
            DrxText.Text = drx.ToString("D");

            if (DRX_COUNT == drx)
                DrxBtn.IsEnabled = false;
            if (drxMax == drxRemain)
                CChangeBtn.IsEnabled = false;
        }

        private void JayBtn_Click(object sender, RoutedEventArgs e)
        {
            jay++;
            jayRemain++;
            AllRemain++;

            NowProgress.Value++;
            RemainReport.Text = AllRemain.ToString("D");
            JayText.Text = jay.ToString("D");

            if (JAY_COUNT == jay)
                JayBtn.IsEnabled = false;
            if (jayMax == jayRemain)
                CChangeBtn.IsEnabled = false;
        }

        private void OCBtn_Click(object sender, RoutedEventArgs e)
        {
            overclock++;
            overclockRemain++;
            AllRemain++;

            NowProgress.Value++;
            RemainReport.Text = AllRemain.ToString("D");
            OCText.Text = overclock.ToString("D");

            if (OC_COUNT == overclock)
                OCBtn.IsEnabled = false;
            if (overclockMax == overclockRemain)
                CChangeBtn.IsEnabled = false;
        }

        private void SanctuaryBtn_Click(object sender, RoutedEventArgs e)
        {
            sanctuary++;
            sanctuaryRemain++;
            AllRemain++;

            NowProgress.Value++;
            RemainReport.Text = AllRemain.ToString("D");
            SanctuaryText.Text = sanctuary.ToString("D");

            if (SANCTUARY_COUNT == sanctuary)
                SanctuaryBtn.IsEnabled = false;
            if (sanctuaryMax == sanctuaryRemain)
                CChangeBtn.IsEnabled = false;
        }

        private void MaterialBtn_Click(object sender, RoutedEventArgs e)
        {
            material++;
            materialRemain++;
            AllRemain++;

            NowProgress.Value++;
            RemainReport.Text = AllRemain.ToString("D");
            MaterialText.Text = material.ToString("D");

            if (MATERIAL_COUNT == material)
                MaterialBtn.IsEnabled = false;
            if (materialMax == materialRemain)
                CChangeBtn.IsEnabled = false;
        }

        private void CChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            UnmiBtn.IsEnabled = true;
            unmi = 0;
            UnmiText.Text = unmi.ToString("D");

            DrxBtn.IsEnabled = true;
            drx = 0;
            DrxText.Text = drx.ToString("D");

            JayBtn.IsEnabled = true;
            jay = 0;
            JayText.Text = jay.ToString("D");

            OCBtn.IsEnabled = true;
            overclock = 0;
            OCText.Text = overclock.ToString("D");

            SanctuaryBtn.IsEnabled = true;
            sanctuary = 0;
            SanctuaryText.Text = sanctuary.ToString("D");

            MaterialBtn.IsEnabled = true;
            material = 0;
            MaterialText.Text = material.ToString("D");

            CharRemain++;
            RemainChar.Text = CharRemain.ToString("D");
        }

        private void CharTextBox_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.IsDown && e.Key == Key.Enter)
            {
                try
                {
                    string text = CharTextBox.Text ?? "0";
                    CharCnt = Int32.Parse(text);
                }
                catch
                {
                    MessageBox.Show("값을 잘못입력하셨습니다.", string.Empty, MessageBoxButton.OK, MessageBoxImage.Error);
                    CharTextBox.Text = CharCnt.ToString("D");
                }

                SetCharCnt();

                if (AllRemain < All)
                    CChangeBtn.IsEnabled = true;
            }
        }

        private void SetCharCnt()
        {
            unmiMax = CharCnt * UNMI_COUNT;
            drxMax = CharCnt * DRX_COUNT;
            jayMax = CharCnt * JAY_COUNT;
            overclockMax = CharCnt * OC_COUNT;
            sanctuaryMax = CharCnt * SANCTUARY_COUNT;
            materialMax = CharCnt * MATERIAL_COUNT;

            All = unmiMax + drxMax + jayMax + overclockMax + sanctuaryMax + materialMax;
            MaxReport.Text = All.ToString("D");

            Properties.Settings.Default.CharCnt = CharCnt;
            Properties.Settings.Default.Save(); ;

            NowProgress.Minimum = 0;
            NowProgress.Maximum = All;
        }

        private void NowProgress_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Debug.WriteLine(NowProgress.Maximum);
        }
    }
}
