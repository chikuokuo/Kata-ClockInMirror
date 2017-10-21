using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClockInMirror
{
    [TestClass]
    public class ClockInMirrorTest
    {
        //in the same manner:

        //05:25 --> 06:35

        //01:50 --> 10:10

        //11:58 --> 12:02

        //12:01 --> 11:59

        //Please complete the method which is provided with mirror time as string, and return the real time as string.

        //The return time value should always be between 1<= time< 13. This is the convenient way that human read the clock.

        //So there is no 00:20, instead it is 12:20.

        //There is no 13:20, instead it is 01:20.

        [TestMethod]
        public void Input_0525_ShouldReturn_0635()
        {
            ClockInMirror clockInMirror = new ClockInMirror();
            var result = clockInMirror.MirrorTheClock("05:25");

            Assert.AreEqual("06:35", result);
        }

        [TestMethod]
        public void Input_1158_ShouldReturn_1202()
        {
            ClockInMirror clockInMirror = new ClockInMirror();
            var result = clockInMirror.MirrorTheClock("11:58");

            Assert.AreEqual("12:02", result);
        }

        [TestMethod]
        public void Input_1259_ShouldReturn_1101()
        {
            ClockInMirror clockInMirror = new ClockInMirror();
            var result = clockInMirror.MirrorTheClock("12:59");

            Assert.AreEqual("11:01", result);
        }

        [TestMethod]
        public void Input_0005_ShouldReturn_1155()
        {
            ClockInMirror clockInMirror = new ClockInMirror();
            var result = clockInMirror.MirrorTheClock("00:05");

            Assert.AreEqual("11:55", result);
        }

        [TestMethod]
        public void Input_2305_ShouldReturn_1255()
        {
            ClockInMirror clockInMirror = new ClockInMirror();
            var result = clockInMirror.MirrorTheClock("23:05");

            Assert.AreEqual("12:55", result);
        }
    }

    public class ClockInMirror
    {
        public string MirrorTheClock(string mirroTime)
        {
            var time = DateTime.Today.AddDays(1);
            var mirrorTime = Convert.ToDateTime(mirroTime);

            var mirrorTimeHour = ModfiyHour((time - mirrorTime).Hours);

            return $"{ModfiyTheTimeDisplay(mirrorTimeHour)}:{ModfiyTheTimeDisplay((time - mirrorTime).Minutes)}";
        }

        private int ModfiyHour(int hours)
        {
            if (hours < 1)
            {
                return hours + 12;
            }

            if (hours >= 13)
            {
                return hours - 12;
            }
            return hours;
        }

        private string ModfiyTheTimeDisplay(int number)
        {
            return number < 10 ? "0" + number : number.ToString();
        }
    }
}
