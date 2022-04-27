using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ca4_practice
{
    class graduate
    {
        private string _graduateName; //change to private
        private int _average;
        private int _graduateNumber;
        public string _finalProject;

        private static int _lastNumber;

        public string Name
        {
            get
            {
                return _graduateName;
            }
            set
            {
                _graduateName = value;
            }
        }
        public int Average
        {
            get
            {
                return _average;
            }
            set
            {
                _average = value;
            }
        }
        public string FinalProject
        {
            get
            {
                return _finalProject;
            }
            set
            {
                _finalProject = value;
            }
        }
        public int GraduateNumber
        {
            get
            {
                return this._graduateNumber;
            }
            set
            {
                this._graduateNumber = value;
            }
        }

        public graduate()
        {
            _lastNumber++;
            _graduateNumber = _lastNumber;
        }

        public graduate(string name, int average, string project)
        {
            _graduateName = name;
            _average = average;
            _finalProject = project;
            _lastNumber++;
            _graduateNumber = _lastNumber;
        }

        public string GetDegreeClassification(int mark)
        {
            string classification = "";

            if (mark >= 70)
            {
                classification = "Distinction";
            }
            else if (mark >= 60 && mark <= 69)
            {
                classification = "Merit";
            }
            else if (mark >= 40 && mark <= 59)
            {
                classification = "Pass";
            }
            else if (mark < 40)
            {
                classification = "FAIL";
            }

            return classification;
        }

        public override string ToString()
        {
            return ($"{GraduateNumber,-20}{Name,-10}{Average,-10}{GetDegreeClassification(Average),-25}{FinalProject,-20}");
        }
    }
}
