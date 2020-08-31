using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Vitals
    {
        public IChecker obj;
        public void SetIChecker(IChecker instance) {
            this.obj = instance;
        }
    }
    public interface IChecker
    {
        bool Check(float reading);
    }

    class BPMChecker : IChecker
    {
        public bool Check(float reading)
        {
            if (reading < 70 || reading > 150) {
                return false;
            }
            return true;
        }
    }

    class Spo2Checker : IChecker
    {
        public bool Check(float reading)
        {
            if (reading < 90)
            {
                return false;
            }
            return true;
        }
    }

    class RespRateChecker : IChecker
    {
        public bool Check(float reading)
        {
            if (reading < 30 || reading > 95)
            {
                return false;
            }
            return true;
        }
    }

