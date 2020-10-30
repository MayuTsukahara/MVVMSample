using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleUnitConverter {
    class MainWindowViewModel : ViewModel{
        private double metricalValue, imperialValue;
        //▲ボタンで呼ばれるコマンド
        public ICommand ImperialUnitToMetric { get; private set; }
        //▼ボタンで呼ばれるコマンド
        public ICommand MetricToImperialUnit { get; private set; }

        //上のComboboxで選択される値
        public MetricUnit CurrentMetricUnit { get; set; }
        //下のComboboxで選択される値
        public ImperialUnit CurrentImperialUnit { get; set; }

        public double MetricValue {
            get { return this.metricalValue; }
            set {
                this.metricalValue = value;
                this.OnPropertyChanged();   //値に変化あり
            }
        }
        public double ImperialValue {
            get { return this.imperialValue; }
            set {
                this.imperialValue = value;
                this.OnPropertyChanged();   //値に変化あり
            }
        }
        public MainWindowViewModel() {
            this.CurrentMetricUnit = MetricUnit.Units.First();
            this.CurrentImperialUnit = ImperialUnit.Units.First();

            this.MetricToImperialUnit = new DelegateCommand(
                () => this.ImperialValue = this.CurrentImperialUnit.FromMetricUnit(
                    this.CurrentMetricUnit, this.metricalValue));

            this.ImperialUnitToMetric = new DelegateCommand(
            () => this.MetricValue = this.CurrentMetricUnit.FromImperialUnit(
                this.CurrentImperialUnit, this.imperialValue));
        }
    }
}
