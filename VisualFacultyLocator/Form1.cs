using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Web;
using System.Net;



namespace VisualFacultyLocator
{
    public partial class Form1 : Form
    {
        StreamWriter outputFile;
        string inputFile;

        public Form1()
        {
            InitializeComponent();
        }

        private void dialogButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Select an Output File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            outputFileBox.Text = saveFileDialog1.FileName;
 
        }

        private void chooseInputFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Select an Input File";
            openFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            inputFileBox.Text = openFileDialog1.FileName;
 
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            if (outputFileBox.Text != "" && inputFileBox.Text != "")
            {
                inputFile =  System.IO.File.ReadAllText(inputFileBox.Text);
                outputFile = new StreamWriter(outputFileBox.Text);
              //  outputFile = new StreamWriter("debug.txt");
                run();
                outputFile.Close();
                
            }
        }

        /*
So if they ever decide to change how the page is laid out, this won't work.  Hopefully that's a slim chance.
However, there's a reasonable chance that they'll change numbering when it comes to the *81's and the 950's.  
I made an exception for those in the code- if you search for "81" or "950" you'll find it.  Essentially it
looks at the previous class number to decide if it needs to keep both the old class number and name, or just
the number.  Have fun with that one.

TBA Classes don't print.  If you want to display them, write an additional piece into the sorting/printing
function that sort through for TBA's and prints them up.
*/
        
        void printbytime(List<classinstance> classes) {
            int i = 0;

            List<classinstance> monday = new List<classinstance>();
            List<classinstance> tuesday = new List<classinstance>();
            List<classinstance> wednesday = new List<classinstance>();
            List<classinstance> thursday = new List<classinstance>();
            List<classinstance> friday = new List<classinstance>();

            textBox1.Text = textBox1.Text + "Sorting and Printing to File."+ Environment.NewLine;

            while (i < classes.Count)
            {
                if (classes[i].time != "TBA" && !classes[i].title.Contains("Laboratory"))
                {
                    if (classes[i].days.Contains("M"))
                        monday.Add(classes[i]);
                    if (classes[i].days.Contains("T"))
                        tuesday.Add(classes[i]);
                     if (classes[i].days.Contains("W"))
                        wednesday.Add(classes[i]);
                    if (classes[i].days.Contains("R"))
                        thursday.Add(classes[i]);
                    if (classes[i].days.Contains("F"))
                        friday.Add(classes[i]);
                }
                i++;
            }

            List<classinstance> day = monday;
            string daystr = "";
            for (int ii = 0; ii < 5; ii++)
            {
                if (ii == 0)
                {
                    day = monday;
                    daystr = "MONDAY";
                }
                else if (ii == 1)
                {
                    day = tuesday;
                    daystr = "TUESDAY";
                }
                else if (ii == 2)
                {
                    day = wednesday;
                    daystr = "WEDNESDAY";
                }
                else if (ii == 3)
                {
                    day = thursday;
                    daystr = "THURSDAY";
                }
                else if (ii == 4)
                {
                    day = friday;
                    daystr = "FRIDAY";
                }
                


                outputFile.Write("----------------------------" + daystr + "----------------------------");
                outputFile.Write(Environment.NewLine);

                day.Sort();

                foreach (classinstance cls in day)
                {
                    outputFile.Write(cls.time + ",  ");
                   outputFile.Write(cls.subject.PadLeft(4) + ' ');
                   outputFile.Write(cls.course + ", ");
                    outputFile.Write(cls.location.PadLeft(11) + ",  ");
                    outputFile.Write(cls.instructor);
                    outputFile.Write(Environment.NewLine);
                }
                

                //while (time != 1) //starts at 5 am, end before 1 pm
                //{
                //    i = 0;
                //    while (i < day.Count)
                //    {
                //        if (!day[i].time.Contains("pm")) //during the morning
                //        {
                //            if (day[i].time.StartsWith(time.ToString().PadLeft(2, '0'))) //find things starting this hour
                //            {
                //                outputFile.Write(day[i].subject.PadLeft(4) + ' ');
                //                outputFile.Write(day[i].course + ",  ");
                //                outputFile.Write(day[i].time + ", ");
                //                outputFile.Write(day[i].location.PadLeft(11) + ",  ");
                //                outputFile.Write(day[i].instructor);
                //                outputFile.Write(Environment.NewLine);
                //                day.RemoveAt(i);
                //                found = true;
                //            }
                //        }
                //        if (found == false)
                //            i++;
                //        found = false;
                //    }
                //    time++;
                //    if (time > 12)
                //        time = 1;
                //}

                //time = 11;
                //while (time != 10) //starts at 11 am, ends before 10 pm
                //{
                //    i = 0;
                //    while (i < day.Count)
                //    {
                //        if (day[i].time.StartsWith(time.ToString().PadLeft(2, '0'))) //find things starting this hour
                //        {
                //            outputFile.Write(day[i].subject.PadLeft(4) + ' ');
                //            outputFile.Write(day[i].course + ",  ");
                //            outputFile.Write(day[i].time + ", ");
                //            outputFile.Write(day[i].location.PadLeft(11) + ",  ");
                //            outputFile.Write(day[i].instructor);
                //            outputFile.Write(Environment.NewLine);
                //            day.RemoveAt(i);
                //            found = true;
                //        }
                //        if (found == false)
                //            i++;
                //        found = false;
                //    }
                //    time++;
                //    if (time > 12)
                //        time = 1;
                //}
             //   outputFile.Write(Environment.NewLine);
            }

            //found = false;
            //time = 6; //start at 5 am
            //outputFile.Write( "----------------------------TUESDAY----------------------------");
            //outputFile.Write( Environment.NewLine + Environment.NewLine);

            //while (time != 1) //starts at 5 am, end before 1 pm
            //{
            //    i = 0;
            //    while (i < tuesday.Count)
            //    {
            //        if (!tuesday[i].time.Contains("PM")) //during the morning
            //        {
            //            if (tuesday[i].time.StartsWith(Convert.ToString(time))) //find things starting this hour
            //            {
            //                outputFile.Write(tuesday[i].course + ',');
            //                //outputFile.Write( tuesday[i].classname + Environment.NewLine);
            //                //outputFile.Write( tuesday[i].section + Environment.NewLine);
            //                //outputFile.Write( tuesday[i].hours + Environment.NewLine);
            //                outputFile.Write( tuesday[i].time + ',');
            //                outputFile.Write( tuesday[i].location + ',');
            //                outputFile.Write( tuesday[i].instructor + ',');
            //                //outputFile.Write( tuesday[i].code + Environment.NewLine);
            //                outputFile.Write( Environment.NewLine);
            //                tuesday.RemoveAt(i);
            //                found = true;
            //            }
            //        }
            //        if (found == false)
            //            i++;
            //        found = false;
            //    }
            //    time++;
            //    if (time > 12)
            //        time = 1;
            //}

            //while (time != 12) //starts at 1 pm, ends before 12 pm
            //{
            //    i = 0;
            //    while (i < tuesday.Count)
            //    {
            //        if (tuesday[i].time.StartsWith(Convert.ToString(time))) //find things starting this hour
            //        {
            //            outputFile.Write(tuesday[i].course + ',');
            //            //outputFile.Write( tuesday[i].classname + Environment.NewLine);
            //            //outputFile.Write( tuesday[i].section + Environment.NewLine);
            //            //outputFile.Write( tuesday[i].hours + Environment.NewLine);
            //            outputFile.Write( tuesday[i].time + ',');
            //            outputFile.Write( tuesday[i].location + ',');
            //            outputFile.Write( tuesday[i].instructor + ',');
            //            //outputFile.Write( tuesday[i].code + Environment.NewLine);
            //            outputFile.Write( Environment.NewLine);
            //            tuesday.RemoveAt(i);
            //            found = true;
            //        }
            //        if (found == false)
            //            i++;
            //        found = false;
            //    }
            //    time++;
            //    if (time > 12)
            //        time = 1;
            //}
            
            //found = false;
            //time = 6; //start at 5 am
            //outputFile.Write( "----------------------------WEDNESDAY----------------------------");
            //outputFile.Write( Environment.NewLine + Environment.NewLine);

            //while (time != 1) //starts at 5 am, end before 1 pm
            //{
            //    i = 0;
            //    while (i < wednesday.Count)
            //    {
            //        if (!wednesday[i].time.Contains("PM")) //during the morning
            //        {
            //            if (wednesday[i].time.StartsWith(Convert.ToString(time))) //find things starting this hour
            //            {
            //                outputFile.Write(wednesday[i].course + ',');
            //                //outputFile.Write( wednesday[i].classname + Environment.NewLine);
            //                //outputFile.Write( wednesday[i].section + Environment.NewLine);
            //                //outputFile.Write( wednesday[i].hours + Environment.NewLine);
            //                outputFile.Write( wednesday[i].time + ',');
            //                outputFile.Write( wednesday[i].location + ',');
            //                outputFile.Write( wednesday[i].instructor + ',');
            //                //outputFile.Write( wednesday[i].code + Environment.NewLine);
            //                outputFile.Write( Environment.NewLine);
            //                wednesday.RemoveAt(i);
            //                found = true;
            //            }
            //        }
            //        if (found == false)
            //            i++;
            //        found = false;
            //    }
            //    time++;
            //    if (time > 12)
            //        time = 1;
            //}

            //while (time != 12) //starts at 1 pm, ends before 12 pm
            //{
            //    i = 0;
            //    while (i < wednesday.Count)
            //    {
            //        if (wednesday[i].time.StartsWith(Convert.ToString(time))) //find things starting this hour
            //        {
            //            outputFile.Write(wednesday[i].course + ',');
            //            //outputFile.Write( wednesday[i].classname + Environment.NewLine);
            //            //outputFile.Write( wednesday[i].section + Environment.NewLine);
            //            //outputFile.Write( wednesday[i].hours + Environment.NewLine);
            //            outputFile.Write( wednesday[i].time + ',');
            //            outputFile.Write( wednesday[i].location + ',');
            //            outputFile.Write( wednesday[i].instructor + ',');
            //            //outputFile.Write( wednesday[i].code + Environment.NewLine);
            //            outputFile.Write( Environment.NewLine);
            //            wednesday.RemoveAt(i);
            //            found = true;
            //        }
            //        if (found == false)
            //            i++;
            //        found = false;
            //    }
            //    time++;
            //    if (time > 12)
            //        time = 1;
            //}
            
            //found = false;
            //time = 6; //start at 5 am
            //outputFile.Write( "----------------------------THURSDAY----------------------------");
            //outputFile.Write( Environment.NewLine + Environment.NewLine);

            //while (time != 1) //starts at 5 am, end before 1 pm
            //{
            //    i = 0;
            //    while (i < thursday.Count)
            //    {
            //        if (!thursday[i].time.Contains("PM")) //during the morning
            //        {
            //            if (thursday[i].time.StartsWith(Convert.ToString(time))) //find things starting this hour
            //            {
            //                outputFile.Write(thursday[i].course + ',');
            //                //outputFile.Write( thursday[i].classname + Environment.NewLine);
            //                //outputFile.Write( thursday[i].section + Environment.NewLine);
            //                //outputFile.Write( thursday[i].hours + Environment.NewLine);
            //                outputFile.Write( thursday[i].time + ',');
            //                outputFile.Write( thursday[i].location + ',');
            //                outputFile.Write( thursday[i].instructor + ',');
            //                //outputFile.Write( thursday[i].code + Environment.NewLine);
            //                outputFile.Write( Environment.NewLine);
            //                thursday.RemoveAt(i);
            //                found = true;
            //            }
            //        }
            //        if (found == false)
            //            i++;
            //        found = false;
            //    }
            //    time++;
            //    if (time > 12)
            //        time = 1;
            //}

            //while (time != 12) //starts at 1 pm, ends before 12 pm
            //{
            //    i = 0;
            //    while (i < thursday.Count)
            //    {
            //        if (thursday[i].time.StartsWith(Convert.ToString(time))) //find things starting this hour
            //        {
            //            outputFile.Write(thursday[i].course + ',');
            //            //outputFile.Write( thursday[i].classname + Environment.NewLine);
            //            //outputFile.Write( thursday[i].section + Environment.NewLine);
            //            //outputFile.Write( thursday[i].hours + Environment.NewLine);
            //            outputFile.Write( thursday[i].time + ',');
            //            outputFile.Write( thursday[i].location + ',');
            //            outputFile.Write( thursday[i].instructor + ',');
            //            //outputFile.Write( thursday[i].code + Environment.NewLine);
            //            outputFile.Write( Environment.NewLine);
            //            thursday.RemoveAt(i);
            //            found = true;
            //        }
            //        if (found == false)
            //            i++;
            //        found = false;
            //    }
            //    time++;
            //    if (time > 12)
            //        time = 1;
            //}
            
            //found = false;
            //time = 6; //start at 5 am
            //outputFile.Write( "----------------------------FRIDAY----------------------------");
            //outputFile.Write( Environment.NewLine + Environment.NewLine);

            //while (time != 1) //starts at 5 am, end before 1 pm
            //{
            //    i = 0;
            //    while (i < friday.Count)
            //    {
            //        if (!friday[i].time.Contains("PM")) //during the morning
            //        {
            //            if (friday[i].time.StartsWith(Convert.ToString(time))) //find things starting this hour
            //            {
            //                outputFile.Write(friday[i].course + ',');
            //                //outputFile.Write( friday[i].classname + Environment.NewLine);
            //                //outputFile.Write( friday[i].section + Environment.NewLine);
            //                //outputFile.Write( friday[i].hours + Environment.NewLine);
            //                outputFile.Write( friday[i].time + ',');
            //                outputFile.Write( friday[i].location + ',');
            //                outputFile.Write( friday[i].instructor + ',');
            //                //outputFile.Write( friday[i].code + Environment.NewLine);
            //                outputFile.Write( Environment.NewLine);
            //                friday.RemoveAt(i);
            //                found = true;
            //            }
            //        }
            //        if (found == false)
            //            i++;
            //        found = false;
            //    }
            //    time++;
            //    if (time > 12)
            //        time = 1;
            //}

            //while (time != 12) //starts at 1 pm, ends before 12 pm
            //{
            //    i = 0;
            //    while (i < friday.Count)
            //    {
            //        if (friday[i].time.StartsWith(Convert.ToString(time))) //find things starting this hour
            //        {
            //            outputFile.Write(friday[i].course + ',');
            //            //outputFile.Write( friday[i].classname + Environment.NewLine);
            //            //outputFile.Write( friday[i].section + Environment.NewLine);
            //            //outputFile.Write( friday[i].hours + Environment.NewLine);
            //            outputFile.Write( friday[i].time + ',');
            //            outputFile.Write( friday[i].location + ',');
            //            outputFile.Write( friday[i].instructor + ',');
            //            //outputFile.Write( friday[i].code + Environment.NewLine);
            //            outputFile.Write( Environment.NewLine);
            //            friday.RemoveAt(i);
            //            found = true;
            //        }
            //        if (found == false)
            //            i++;
            //        found = false;
            //    }
            //    time++;
            //    if (time > 12)
            //        time = 1;
            //}
        }

        void printbyinstructor(classinstance[] classes) {
            //unfinished
        }

        void run()
        {
            textBox1.Visible = true;
            textBox1.Text = textBox1.Text + "Loading file..." + Environment.NewLine;

            string source = inputFile.ToString();
            
            textBox1.Text = textBox1.Text + "File Loaded, now parsing..." + Environment.NewLine;

            string temp;

            int progress = 0;
            int progress2 = 0;
            int href1, href2 = 0;
            Boolean stop = false;
            List<classinstance> classes = new List<classinstance>();
            int currentclass = -1;
            int number = 0;
            const string startTag = "<TD CLASS=\"dddefault\">";
            const string endTag = "</TD>";
                
           
            do {
                progress = source.IndexOf(startTag, progress); // find the first opening font tag

                if (progress != -1 && progress != 0) // if found opening font tag
                {
                    number += 1;
                    
                    progress2 = source.IndexOf(endTag, progress);
                    temp = source.Substring(progress + startTag.Length, progress2 - progress - startTag.Length); //pull everything out of font tag
                    if (temp.StartsWith("<ABBR"))
                    {
                        href1 = temp.IndexOf(">", 0);
                        href2 = temp.IndexOf("</ABBR>", href1);
                        temp = temp.Substring(href1 + 1, href2 - href1 - 1);
                        
                    }
                    else if (temp == "")
                        temp = " ";
                    else if (temp == "&nbsp;")
                        temp = " ";
                    else if (temp.StartsWith("<A HREF=")) //remove formatting and links
                    {
                        href1 = temp.IndexOf(">", 0);
                        href2 = temp.IndexOf("</A>", href1);
                        temp = temp.Substring(href1 + 1, href2 - href1 - 1);
                    }
                    else if (temp.Contains("(") ) //remove formatting and links
                    {
                        href1 = temp.IndexOf("(", 0);
                        temp = temp.Substring(0, href1 - 1);
                    }
                    //The successful execution of this code is based on the 24 fields per single line entry of a course.\
                    //If the banner group adds or subtracts additional fields this code will break.   
                    //Best recommendation for finding this is to uncomment the line below and run a test case.
                    //number will tell you which part of the structure should be executing.
                    //the fields inside the class are pretty well named and should align

                    //outputFile.Write(temp + "XXXX" + number + "YYYY" + Environment.NewLine);
                   
                    if ((number == 1) || temp.Length.Equals(5))
                    {
                        if (number == 1){
                    //        outputFile.Write(Environment.NewLine);
                        currentclass += 1;
                        classes.Add(new classinstance());
                        classes[currentclass].courseRefNumber = temp;
                        }
                    }
                    else if (number == 2)
                    {
                  //      outputFile.Write(Environment.NewLine);
                            classes[currentclass].subject = temp;
                    }
                    else if (number == 3)
                        classes[currentclass].course = temp;
                    else if (number == 4)
                        classes[currentclass].section = temp;
                    else if (number == 5)
                        classes[currentclass].campus = temp;
                    else if (number == 6)
                        classes[currentclass].credits = temp;
                    else if (number == 7)
                        classes[currentclass].title = temp;
                    else if (number == 8)
                        classes[currentclass].xlist = temp;
                    else if (number == 9)
                        classes[currentclass].rest = temp;
                    else if (number == 10)
                        classes[currentclass].prereq = temp;
                    else if (number == 11)
                        classes[currentclass].coreq = temp;
                    else if (number == 12)
                        classes[currentclass].days = temp;
                    else if (number == 13)
                        classes[currentclass].time = temp;
                    else if (number == 14)
                        classes[currentclass].roomCap = temp;
                    else if (number == 15)
                        classes[currentclass].openSeats = temp;
                    else if (number == 16)
                        classes[currentclass].proj = temp;
                    else if (number == 17)
                        classes[currentclass].act = temp;
                    else if (number == 18)
                        classes[currentclass].wLCap = temp;
                    else if (number == 19)
                        classes[currentclass].wLAct = temp;
                    else if (number == 20)
                        classes[currentclass].wLRem = temp;
                    else if (number == 21)
                        classes[currentclass].resvRem = temp;
                    else if (number == 22)
                        classes[currentclass].instructor = temp;
                    else if (number == 23)
                    {
                        classes[currentclass].date = temp;
                       // number = 0;
                    }
                    else if (number == 24)
                    {
                        classes[currentclass].location = temp;
                        number = 0;
                    }

                    progress = progress2;
                    
                }
                else
                {
                    stop = true;
                }
            } while (stop == false);

            printbytime(classes);
            //Console.Write(Environment.NewLine);
            //Console.WriteLine("Done, please press enter");
            //Console.ReadLine();
            textBox1.Text = textBox1.Text + "Output Finished" + Environment.NewLine;
        }
    }
}
