using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using MathNet.Numerics;
using System.Numerics;
using MathNet.Numerics.IntegralTransforms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace cw
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            for (int i = 0; i < WaveIn.DeviceCount; i++)
            {
                var deviceInfo = WaveIn.GetCapabilities(i);
                this.micname.Text = String.Format("Device {0}: {1}, {2} channels",
                    i, deviceInfo.ProductName, deviceInfo.Channels);
            }

            // グラフ初期化
            InitPlot();
        }
        private void recording_Click(object sender, EventArgs e)
        {
            WaveIn waveIn = new WaveIn()
            {
                DeviceNumber = 0, // Default
            };
            waveIn.DataAvailable += WaveIn_DataAvailable;
            waveIn.WaveFormat = new WaveFormat(sampleRate: 8000, channels: 1);
            waveIn.StartRecording();
        }
        private void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            // 32bitで最大値1.0fにする
            for (int index = 0; index < e.BytesRecorded; index += 2)
            {
                short sample = (short)((e.Buffer[index + 1] << 8) | e.Buffer[index + 0]);

                float sample32 = sample / 32768f;
                ProcessSample(sample32);
                ProcessSample2(sample32);
            }
        }
        # region  "波形表示"

        // グラフ1の設定
        private PlotModel _plotmodel1 = new PlotModel();
        private LinearAxis _linearaxis1_1 = new LinearAxis
        {
            Position = AxisPosition.Bottom
        };
        private LinearAxis _linearaxis1_2 = new LinearAxis
        {
            Minimum = -1.0,
            Maximum = 1.0,
            Position = AxisPosition.Left
        };

        private LineSeries _lineSeries1 = new LineSeries();
        List<float> _recorded1 = new List<float>(); // 音声データ

        // グラフ2の設定
        private PlotModel _plotmodel2 = new PlotModel();
        private LinearAxis _linearaxis2_1 = new LinearAxis
        {
            Position = AxisPosition.Bottom
        };
        private LinearAxis _linearaxis2_2 = new LinearAxis
        {
            Minimum = -1.0,
            Maximum = 1.0,
            Position = AxisPosition.Left
        };

        private LineSeries _lineSeries2 = new LineSeries();
        List<float> _recorded2 = new List<float>(); // 音声データ

        /// <summary>
        /// グラフの表示
        /// </summary>
        private void InitPlot()
        {
            _plotmodel1.Axes.Add(_linearaxis1_1);
            _plotmodel1.Axes.Add(_linearaxis1_2);
            _plotmodel1.Series.Add(_lineSeries1);
            this.plotView1.Model = _plotmodel1;

            _plotmodel2.Axes.Add(_linearaxis2_1);
            _plotmodel2.Axes.Add(_linearaxis2_2);
            _plotmodel2.Series.Add(_lineSeries2);
            this.plotView2.Model = _plotmodel2;
        }

        /// <summary>
        /// 波形の表示
        /// </summary>
        /// <param name="sample"></param>
        private void ProcessSample(float sample)
        {
            _recorded1.Add(sample);

            if (_recorded1.Count == 1024)
            {
                var points = _recorded1.Select((v, index) =>
                        new DataPoint((double)index, v)
                    ).ToList();
                _lineSeries1.Points.Clear();
                _lineSeries1.Points.AddRange(points);

                this.plotView1.InvalidatePlot(true);

                _recorded1.Clear();
            }

        }

        /// <summary>
        /// 波形の表示2
        /// </summary>
        /// <param name="sample"></param>
        private void ProcessSample2(float sample)
        {
            var windowsize = _recorded2.Count;

            _recorded2.Add(sample);

            if (_recorded2.Count == 1024)
            {

                var window = Window.Hamming(windowsize);
                _recorded2 = _recorded2.Select((v, i) => v * (float)window[i]).ToList();

                Complex[] complexData = _recorded2.Select(v => new Complex(v, 0.0)).ToArray();

                Fourier.Forward(complexData, FourierOptions.Matlab); //

                var s = windowsize * (1.0 / 8000.0);

                var point = complexData.Take(complexData.Count() / 2).Select((v, index) =>
                 new DataPoint((double)index / s,
                 Math.Sqrt(v.Real * v.Real + v.Imaginary * v.Imaginary))).ToList();

                _lineSeries2.Points.Clear();
                _lineSeries2.Points.AddRange(point);
                this.plotView2.InvalidatePlot(true);

            }

        }


        #endregion

    }
}