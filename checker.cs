using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checker
{
    class VitalsChecker
    {
        public Vitals vit = new Vitals();
        public bool VitalsAreOk(float bpm, float spo2, float respRate) {
            bool checkBPM;
            bool checkSpo2;
            bool checkRespRate;
            IChecker o1 = new BPMChecker();
            IChecker o2 = new Spo2Checker();
            IChecker o3 = new RespRateChecker();
            vit.SetIChecker(o1);
            checkBPM = vit.obj.Check(bpm);
            vit.SetIChecker(o2);
            checkSpo2 = vit.obj.Check(spo2);
            vit.SetIChecker(o3);
            checkRespRate = vit.obj.Check(respRate);
            return checkBPM && checkRespRate && checkSpo2;
        }
    }

    class Program
    {
        static void ExpectTrue(bool expression)
        {
            if (!expression)
            {
                Console.WriteLine("Expected true, but got false");
                Environment.Exit(1);
            }
        }

        static void ExpectFalse(bool expression)
        {
            if (expression)
            {
                Console.WriteLine("Expected false, but got true");
                Environment.Exit(1);
            }
        }
        static void Main(string[] args)
        {
            VitalsChecker v1 = new VitalsChecker();
            ExpectTrue(v1.VitalsAreOk(100, 95, 60));
            ExpectFalse(v1.VitalsAreOk(40, 91, 92));
            Console.WriteLine("All ok");
        }
    }
}
