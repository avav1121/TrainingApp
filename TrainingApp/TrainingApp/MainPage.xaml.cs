using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TrainingApp
{
    public partial class MainPage : ContentPage
    {
        private int preparationTime;
        private int workTime;
        private int restTime;
        private int cycleCount;

        private int currentCycle;
        private int currentTime;
        private bool isWorkTime;
        private bool isPaused;

        public MainPage()
        {
            InitializeComponent();
            this.BackgroundColor = new Color(0.14, 0.14, 0.16);
        }

        private void StartButton_Clicked(object sender, EventArgs e)
        {
            preparationTime = int.Parse(PreparationEntry.Text);
            workTime = int.Parse(WorkEntry.Text);
            restTime = int.Parse(RestEntry.Text);
            cycleCount = int.Parse(CycleEntry.Text);

            currentCycle = 1;
            currentTime = preparationTime;
            isWorkTime = true;
            isPaused = false;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                if (isPaused)
                    return true;

                currentTime--;

                if (currentTime > 0)
                {
                    TimerLabel.Text = TimeSpan.FromSeconds(currentTime).ToString(@"mm\:ss");
                    return true;
                }

                // Проверка на завершение тренировки
                if (currentCycle > cycleCount )
                {
                    TimerLabel.Text = "Тренировка завершена";
                    this.BackgroundColor = new Color(0.14, 0.14, 0.16);
                    return false;
                }

                // Смена состояния: работа или отдых
                if (isWorkTime)
                {
                    TimerLabel.Text = "Работа";
                    currentTime = workTime;
                    this.BackgroundColor = Color.Red;
                }
                else
                {
                    TimerLabel.Text = "Отдых";
                    currentTime = restTime;
                    this.BackgroundColor= Color.LightBlue;
                }

                if (!isWorkTime)
                {
                    currentCycle++;
                   
                }

                isWorkTime = !isWorkTime;

                return true;
            });
            
        }

        private void PauseButton_Clicked(object sender, EventArgs e)
        {
            isPaused = true;
        }

        private void ResumeButton_Clicked(object sender, EventArgs e)
        {
            isPaused = false;
        }
    }
}