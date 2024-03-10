using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingApp
{
    public class TrainingResult
    {
        public int Id { get; set; }
        public int CyclesCount { get; set; }

        public int TimeOfTraining { get; set; }

        public int TimeOfChill {  get; set; }

        public int TotalTime { get; set; }

    }
}
