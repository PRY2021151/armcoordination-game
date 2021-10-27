using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Entities
{
    [Serializable]
    public class session
    {
        public int score;
        public int maximum_response;
        public int minimum_response;
        public float average_response;
        public int hits_left_arm;
        public int hits_right_arm;
        public float accuracy_percentage;
        public int failures_right_arm;
        public int failures_left_arm;
        public int child_id;
    }
}
