using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Collections;

namespace VisualFacultyLocator
{

    class classinstance : IComparable<classinstance>
    {
        public string status;
        public string courseRefNumber;
        public string subject;
        public string course;
        public string section;
        public string campus;
        public string credits;
        public string title;
        public string prereq;
        public string coreq;
        public string xlist;
        public string rest;
        public string days;
        public string time;
        public string roomCap;
        public string openSeats;
        public string proj;
        public string cap;
        public string act;
        public string wLCap;
        public string wLAct;
        public string wLRem;
        public string resvCap;
        public string resvAct;
        public string resvRem;
        public string instructor;
        public string date;
        public string location;

        // Implement the generic CompareTo method with the Temperature  
        // class as the Type parameter.  
        // 01234567890123456
        // 11:15 am-12:05 pm
        public int CompareTo(classinstance other)
        {
            // If other is not a valid object reference, this instance is greater. 
            if (other == null) return 1;

            // Compare afternoon vs morning on start time
         //   if (other.time.Substring(0, 2).Equals("08"))
           //     return -1;
         //   else
           // {
                if (time.Substring(6, 2).Equals("am") && other.time.Substring(6, 2).Equals("pm"))
                    return -1;
                else if (time.Substring(6, 2).Equals("pm") && other.time.Substring(6, 2).Equals("am"))
                    return 1;
           // }

            // Compare start time hour
            if ((time.Substring(0, 2) == "12") && (int.Parse(other.time.Substring(0, 2)) < 12))
                return -1;
            else if ((other.time.Substring(0, 2) == "12") && (int.Parse(time.Substring(0, 2)) < 12))
                return 1;
            else if (int.Parse(time.Substring(0, 2)) < int.Parse(other.time.Substring(0, 2)))
                return -1;
            else if (time.Substring(0, 2) == other.time.Substring(0, 2))
                // Hours same, compare minutes
                if (int.Parse(time.Substring(3, 2)) < int.Parse(other.time.Substring(3, 2)))
                    return -1;
                else if (int.Parse(time.Substring(3, 2)) == int.Parse(other.time.Substring(3, 2)))
                {
                    //Minutes same, compare stop times
                    // Compare afternoon vs morning on stop time
                    if (time.Substring(15, 2).Equals("am") && other.time.Substring(15, 2).Equals("pm"))
                        return -1;
                    else if (time.Substring(15, 2).Equals("pm") && other.time.Substring(15, 2).Equals("am"))
                        return 1;

                    // Compare stop time hour
                    if ((time.Substring(9, 2) == "12") && (int.Parse(other.time.Substring(9, 2)) < 12))
                        return -1;
                    else if ((other.time.Substring(9, 2) == "12") && (int.Parse(time.Substring(9, 2)) < 12))
                        return 1;
                    else if (int.Parse(time.Substring(9, 2)) < int.Parse(other.time.Substring(9, 2)))
                        return -1;
                    else if (time.Substring(9, 2) == other.time.Substring(9, 2))
                        // Hours same, compare minutes
                        if (int.Parse(time.Substring(12, 2)) < int.Parse(other.time.Substring(12, 2)))
                            return -1;
                        else if (int.Parse(time.Substring(12, 2)) == int.Parse(other.time.Substring(12, 2)))
                            return 0;
                }

            return 1;
            // The temperature comparison depends on the comparison of  
            // the underlying Double values.  
            //return time.CompareTo(other.time);
        }
    }

    public class Engine
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

    }


}

