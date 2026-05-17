using ScottPlot;
using MathNet.Numerics;
using System.Diagnostics;
namespace BPhO__Plotting_Planck_Spectrum_Task_3
{
    
    public partial class Form1 : Form
    {
        public double h = 6.626E-34;
        public double kB = 1.381E-23;
        public double c = 2.998E8;
        public Form1()
        {
            InitializeComponent();
            generatePlot(200E-9, 2500E-9, 4000);
            formsPlot1.Plot.XLabel("Wavelength / nm");
            formsPlot1.Plot.YLabel("Irradiance / Wm^-2/nm");
            formsPlot1.Refresh();
            
            
        }

        public double plankSpectrumEquation(double wavelength, double temp)
        {
            //Should return spectural Irradiance 
            return 1E-13*Math.PI*(2 * h * c * c) / (Math.Pow(wavelength,5)) * (1 / (Math.Exp(h * c / (wavelength * kB * temp))-1.0)); // return in nm *E4
        }

        private void generatePlot(double minWavelength, double maxWavelength, double temp)
        {
            double[] dataWalength = MathNet.Numerics.Generate.LinearSpaced(1000, minWavelength, maxWavelength);
            double[] dataWavelengthPlotting = MathNet.Numerics.Generate.LinearSpaced(1000, minWavelength, maxWavelength);
            double[] irradiance = new double[dataWalength.Length];

            for (int i = 0; i < dataWalength.Length; i++)
            {
                irradiance[i] = plankSpectrumEquation(dataWalength[i], temp);
                Debug.WriteLine(irradiance[i]);
            }

            formsPlot1.Plot.Add.Scatter(dataWavelengthPlotting, irradiance);
            formsPlot1.Refresh();
        }
    }
}
