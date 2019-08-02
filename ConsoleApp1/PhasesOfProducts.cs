using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class PhasesOfProducts
    {
        private List<string> phases = new List<string>();

        public PhasesOfProducts()
        {
            phases.Add("ready to serve.");
            phases.Add("forwarded.");
        }
        public void ShowAllPhases()
        {
            string result = "";

            foreach (var phase in phases)
            {
                result += $"{phase} \n";
            }
            Console.WriteLine(result);
        }
        public int GetPhaseIndex(string phase)
        {
            int result;
            try
            {
                result = phases.IndexOf(phase);
                return result;
            }
            catch (Exception)
            {
                return -1;
            }

        }
        public string GetPhaseName(int index)
        {
            try
            {
                string name = phases[index];
                return phases[index];

            }
            catch (Exception)
            {
                Console.WriteLine("inaccessible data");
                return "";
            }



        }
        public void AddPhase(string phase)
        {
            if (GetPhaseIndex(phase) != -1)
            {
                this.phases.Add(phase);
            }
            else
            {
                Console.WriteLine("This phase is already defined.");
            }
            return;

        }
        public void UpdatePhase(int index, string phase)
        {
            if (GetPhaseName(index) != "")
            {
                phases[index] = phase;
                Console.WriteLine("Update successful.");
            }
            else
            {
                Console.WriteLine("Update unsuccessful.");
            }
            return;
        }
    }
}
